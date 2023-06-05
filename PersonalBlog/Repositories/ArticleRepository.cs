using System.Text.RegularExpressions;
using PersonalBlog.Data;
using PersonalBlog.Exceptions;
using PersonalBlog.Models;
using PersonalBlog.Repositorys;

namespace PersonalBlog.Repositories;

public class ArticleRepository : RepositoryBase<Article,BlogDbContext>, IArticleRepository
{
    
    public ArticleRepository(BlogDbContext context) : base(context)
    {
    }

    public List<Article> GetAllArticles()
    {
        var articles = All();
        articles.ForEach(x =>
        {
            if (x.Summary == null) AddArticleSummaryIfNotExist(x);
        });
        return articles;
    }

    public List<string?> GetCategories()
    {
        return All().Select(x => x.Category).Distinct().ToList();
    }

    public List<Article> GetArticlesByCategories(List<string> categories)
    {
        var results = new List<Article>();
        categories.ForEach(x => results.AddRange(All().Where(y => y.Category == x).ToList()));
        results.ForEach(x =>
        {
            if (x.Summary == null) AddArticleSummaryIfNotExist(x);
        });
        return results;
    }

    public List<Article> GetArticlesByKeywords(List<string> keywords)
    {
        var results = new List<Article>();

        var allArticles = All();
        
        foreach (var article in allArticles)
        {
            foreach (var keyword in keywords)
            {
                if (article.Title.Contains(keyword) | article.Content.Contains(keyword))
                {
                    results.Add(article);
                }
            }
        }

        results.ForEach(x =>
        {
            if (x.Summary == null) AddArticleSummaryIfNotExist(x);
        });
        return results;
    }

    public List<Article> GetDisplayArticles()
    {
        var articles = All().Where(x => x.IsDisplay).ToList();
        articles.ForEach(x =>
            {
                if (x.Summary == null) AddArticleSummaryIfNotExist(x);
            });
        return articles;
    }

    public Article GetArticle(int articleId)
    {
        var article = Get(articleId);
        if (article == null) throw new ArticleNullException("Article is null");
        return article;
    }
    
    private void AddArticleSummaryIfNotExist(Article? article)
    {
        if (article == null) throw new ArticleNullException("Article is null");
        if (article.Summary == null)
        {
            var sentences = Regex.Split(article.Content, @"(?<=[.。])");
            var firstTwoSentences = new string[Math.Min(sentences.Length, 2)];
            Array.Copy(sentences, firstTwoSentences, firstTwoSentences.Length);
            article.Summary = firstTwoSentences[0] + firstTwoSentences[1];
        }
    }
    
}