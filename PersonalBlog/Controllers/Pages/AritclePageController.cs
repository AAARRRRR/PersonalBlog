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
    public IActionResult Index()
    {
        var allCategories = _articleService.GetAllCategories();
        var allArticles = _articleService.GetAllArticles();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = allArticles};
        
        return View("ArticleCategoryPage",articlePageViewModel);
    }

    [Route("category/{category}")]
    public IActionResult ArticlesByCategory(string category)
    {
        var categories = new List<string?>();
        categories.Add(category);
        var articles = _articleService.GetAllArticlesByCategories(categories);
        var allCategories = _articleService.GetAllCategories();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = articles};
        
        return View("ArticleCategoryPage",articlePageViewModel);
    }
    
    [HttpPost]
    [Route("keywords/{keyword}")]
    public IActionResult ArticlesByKeywords(KeywordForm model)
    {
        var keywords = model.key.Split(@"/\s+/").ToList();
        var articles = _articleService.GetAllArticlesByKeywords(keywords);
        var allCategories = _articleService.GetAllCategories();
        var articlePageViewModel = new ArticlePageViewModel
            { AllCategories = allCategories, AllArticles = articles};
        
        return View("ArticleCategoryPage", articlePageViewModel);
    }
    
    [Route("article/{articleId}")]
    public IActionResult ArticleDetailPage(string articleId)
    {
        var urlStrings = HttpContext.Request.GetDisplayUrl().Split("/");
        int Id;
        if (int.TryParse(urlStrings[urlStrings.Length - 1], out Id))
        {
            var article = _articleService.GetArticle(Id);
            return View(article);
        }
        //Todo:处理异常情况
        return View();
    }
    

}