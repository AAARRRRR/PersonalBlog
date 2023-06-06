using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers.Pages;


public class ArticlePageController : Controller
{
    private readonly IArticleService _articleService;

    public ArticlePageController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [Route("articles")]
    public async Task<IActionResult> Index()
    {
        var allCategories = await _articleService.GetAllCategories();
        var allArticles = await _articleService.GetAllArticles();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = allArticles};
        
        return View("ArticleCategoryPage",articlePageViewModel);
    }

    [Route("category/{category}")]
    public async Task<IActionResult> ArticlesByCategory(string category)
    {
        var categories = new List<string?> { category };
        var articles = await _articleService.GetAllArticlesByCategories(categories);
        var allCategories = await _articleService.GetAllCategories();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = articles};
        
        return View("ArticleCategoryPage",articlePageViewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> ArticlesByKeywords(KeywordForm keywordForm)
    {
        var keywords = keywordForm.key.Split(@"/\s+/").ToList();
        var articles = await _articleService.GetAllArticlesByKeywords(keywords);
        var allCategories = await _articleService.GetAllCategories();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = articles};
        
        return View("ArticleCategoryPage", articlePageViewModel);
    }
    
    [Route("article/{articleId}")]
    public async Task<IActionResult> ArticleDetailPage(string articleId)
    {
        if (int.TryParse(articleId, out var Id))
        {
            var article = await _articleService.GetArticle(Id);
            return View(article);
        }
        //Todo:处理异常情况
        return View();
    }
    

}