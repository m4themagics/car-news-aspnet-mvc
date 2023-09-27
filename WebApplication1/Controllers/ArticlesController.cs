using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/get-articles")]
public class ArticlesController : Controller
{
    private readonly IArticleRepository _articleRepository;

    public ArticlesController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public IReadOnlyCollection<ArticleDTO> getArticles(int loadPerClick, int loaded)
    {
        
        var allArticles = _articleRepository.GetAll();
        var articles = new List<ArticleDTO>();
        for (var i = loaded; i < loaded + loadPerClick; i++)
        {
            if (allArticles.Count() > i)
            {
                articles.Add(new ArticleDTO(
                    allArticles.ElementAt(i).Id,
                    allArticles.ElementAt(i).Title,
                    allArticles.ElementAt(i).Image,
                    allArticles.ElementAt(i).Annotation,
                    allArticles.ElementAt(i).Author,
                    DateTime.Now,
                    allArticles.ElementAt(i).Type,
                    allArticles.ElementAt(i).Tags
                ));
            }
            
        }

        return articles;
    }
    
    [HttpGet("search")]
    public IReadOnlyCollection<ArticleDTO> getFullSearchArticles(string name = "", string checkboxes = "")
    {
        var allArticles = _articleRepository.GetAll();
        var articles = new List<ArticleDTO>();
        for (var i = 0; i < allArticles.Count(); i++)
        {
            // allArticles.ElementAt(i).Title.ToLower().Contains(name.ToLower());
            if (name.Length > 0 && allArticles.ElementAt(i).Title.ToLower().Contains(name.ToLower()) 
                && checkboxes.Length > 0 && isContainsTags( allArticles.ElementAt(i).Tags, checkboxes.Split(",")))
            {
                articles.Add(new ArticleDTO(
                    allArticles.ElementAt(i).Id,
                    allArticles.ElementAt(i).Title,
                    allArticles.ElementAt(i).Image,
                    allArticles.ElementAt(i).Annotation,
                    allArticles.ElementAt(i).Author,
                    DateTime.Parse(allArticles.ElementAt(i).Date),
                    allArticles.ElementAt(i).Type,
                    allArticles.ElementAt(i).Tags
                ));
            }
            
        }

        return articles;
    }
    
    [HttpGet("search-name")]
    public IReadOnlyCollection<ArticleDTO> getNameSearchArticles(string name = "")
    {
        var allArticles = _articleRepository.GetAll();
        var articles = new List<ArticleDTO>();
        for (var i = 0; i < allArticles.Count(); i++)
        {
            // allArticles.ElementAt(i).Title.ToLower().Contains(name.ToLower());
            if (name.Length > 0 && allArticles.ElementAt(i).Title.ToLower().Contains(name.ToLower()))
            {
                articles.Add(new ArticleDTO(
                    allArticles.ElementAt(i).Id,
                    allArticles.ElementAt(i).Title,
                    allArticles.ElementAt(i).Image,
                    allArticles.ElementAt(i).Annotation,
                    allArticles.ElementAt(i).Author,
                    DateTime.Parse(allArticles.ElementAt(i).Date),
                    allArticles.ElementAt(i).Type,
                    allArticles.ElementAt(i).Tags
                ));
            }
            
        }

        return articles;
    }
    
    [HttpGet("search-checkboxes")]
    public IReadOnlyCollection<ArticleDTO> getCheckboxesSearchArticles(string checkboxes = "")
    {
        var allArticles = _articleRepository.GetAll();
        var articles = new List<ArticleDTO>();
        for (var i = 0; i < allArticles.Count(); i++)
        {
            // allArticles.ElementAt(i).Title.ToLower().Contains(name.ToLower());
            if (checkboxes.Length > 0 && isContainsTags( allArticles.ElementAt(i).Tags, checkboxes.Split(",")))
            {
                articles.Add(new ArticleDTO(
                    allArticles.ElementAt(i).Id,
                    allArticles.ElementAt(i).Title,
                    allArticles.ElementAt(i).Image,
                    allArticles.ElementAt(i).Annotation,
                    allArticles.ElementAt(i).Author,
                    DateTime.Parse(allArticles.ElementAt(i).Date),
                    allArticles.ElementAt(i).Type,
                    allArticles.ElementAt(i).Tags
                ));
            }
            
        }

        return articles;
    }
    
    [HttpPost("add")]
    public ArticleDTO Add([FromForm] ArticleDTO articleDto
        // ,
        // [FromBody] string image,
        // [FromBody] string annotation,
        // [FromBody] string tags,
        // [FromBody] string author,
        // [FromBody] string date,
        // [FromBody] int type
        )
    {
        // var articleDto = new ArticleDTO(0, title, image, annotation, author, DateTime.Today, type, tags);
        _articleRepository.Add(articleDto);

        return articleDto;
    }

    private bool isContainsTags(string entityTags, string[] searchTags)
    {
        foreach (var tag in searchTags)
        {
            if (entityTags.ToLower().Contains(tag.ToLower()))
                return true;
        }

        return false;
    }
}