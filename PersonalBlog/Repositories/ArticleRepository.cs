using System.Text.RegularExpressions;
using LinqKit;
using PersonalBlog.Data;
using PersonalBlog.Exceptions;
using PersonalBlog.Infrastruture;
using PersonalBlog.Models;

namespace PersonalBlog.Repositories;

public class ArticleRepository : RepositoryBase<Article,BlogDbContext>, IArticleRepository
{
    
    public ArticleRepository(BlogDbContext context) : base(context)
    {
    }

    public async Task<List<Article>> GetAllArticles()
    {
        var articles = await All();
        await AddArticleSummaryIfNotExist();
        return articles;
    }

    public async Task<List<string?>> GetCategories()
    {
        var allArticles = await All();
        return allArticles.Select(x => x.Category).Distinct().ToList();
    }

    public async Task<List<Article>> GetArticlesByCategories(List<string?> categories)
    {
        var results = new List<Article>();
        var predicate = PredicateBuilder.False<Article>();

        foreach (var category in categories)
        {
            var keywordPredicate = predicate.Or(article => article.Category == category);
            var partialResult = await Where(keywordPredicate);
            results.AddRange(partialResult);
        }

        await AddArticleSummaryIfNotExist();
        
        return results;
    }

    public async Task<List<Article>> GetArticlesByKeywords(List<string> keywords)
    {
        var predicate = PredicateBuilder.False<Article>();
        
        foreach (var keyword in keywords)
        {
            predicate = predicate.Or(article => article.Title.Contains(keyword) || article.Content.Contains(keyword));
        }
        var results = await Where(predicate);
        
        await AddArticleSummaryIfNotExist();
            
        return results;
    }

    public async Task<List<Article>> GetDisplayArticles()
    {
        var predicate = PredicateBuilder.False<Article>();
        var displayArticlePredicate = predicate.Or(article => article.IsDisplay);
        var articles = await Where(displayArticlePredicate);
        
        await AddArticleSummaryIfNotExist();
        
        return articles;
    }

    public async Task<Article?> GetArticle(int articleId)
    {
        var article = await Get(articleId);
        if (article == null) throw new ArticleNullException("Article is null");
        return article;
    }
    
    private async Task AddArticleSummaryIfNotExist()
    {
        var predicate = PredicateBuilder.False<Article>();
        var ifSummaryExistPredicate = predicate.Or(article => article.Summary == null);
        var articlesWithoutSummary = await Where(ifSummaryExistPredicate);

        foreach (var article in articlesWithoutSummary)
        {
            var sentences = Regex.Split(article.Content, @"(?<=[.。])");
            var firstTwoSentences = new string[Math.Min(sentences.Length, 2)];
            Array.Copy(sentences, firstTwoSentences, firstTwoSentences.Length);
            article.Summary = firstTwoSentences[0] + firstTwoSentences[1];
            Update(article);
        }
    }
}