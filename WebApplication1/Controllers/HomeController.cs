using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IArticleRepository _articleRepository;

    public HomeController(ILogger<HomeController> logger, IArticleRepository repository)
    {
        _logger = logger;
        _articleRepository = repository;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        /* using (CarNewsDBContext db = new CarNewsDBContext())
        {
            // создаем два объекта User
           Article user1 = new Article {
                Id = 1,
                Title = "Какие шины выбрать на зиму — с шипами или без? Мнение эксперта",
                Image = "winter-tyres.jpg",
                 Annotation = "Известно, что по использованию зимних шин автомобилисты делятся на две полярные группы."
                             + "Одна категорична в том, что на льду лишь шипы «спасут мир»."
                              + "Другая ратует за фрикционки, обзывая пользователей шиповок «штроборезами»,"
                             + "намекая на выфрезерованные такими шинами колеи на асфальте.",
                Author = "Иванов",
                Date = DateTime.Today.ToString(),
                Type = 2,
                Tags = "зима, резина"
            };
            Article user2 = new Article {
                Id = 2,
                Title = "Роберт Шварцман проведёт первую тренировку в Остине",
                Image = "robert.jpg",
                Annotation = "Роберт Шварцман примет участие в первой сессии свободных заездов Гран При США."
                             + "Тест-пилот Ferrari сядет за руль машины Шарля Леклера. Во второй тренировке монегаск вернётся в кокпит.",
                Author = "Иванов",
                Date = DateTime.Today.ToString(),
                Type = 3,
                Tags = "Формула 1, Ferrari"
            };
            Article user3 = new Article {
                Id = 3,
                Title = "Audi отметит 25-летие TT особой серией из 100 автомобилей",
                Image = "example-image-carousel.PNG",
                Annotation = "Фирма Audi отметит 25-летие спорткара TT, выпустив лимитированную спецверсию Iconic Edition. "
                             +"Основой для новой модификации послужит купе TT RS; технических изменений не заявлено. "
                             +"Снаружи спецверсия отличится глянцевыми 20-дюймовыми легкосплавными дисками с направленным рисунком, "
                             +"углепластиковым задним антикрылом, видоизменённым диффузором и накладками на бамперах. "
                             +"Всего сделают 100 экземпляров Audi TT RS Iconic Edition для европейского рынка.",
                Author = "Иванов",
                Date = DateTime.Today.ToString(),
                Type = 1,
                Tags = "Audi, TT"
            };
             Article user4 = new Article {
                Id = 4,
                 Title = "Omoda C5 AWD",
                Image = "article-5.PNG",
                 Annotation = "Добавить привод на все четыре можно по-разному. Простой подход состоит в том, чтобы установить муфту подключения задней оси и ещё пару сопутствующих железок. Так делает большинство производителей, чтобы обеспечить автомобилю уверенный старт на скользком покрытии и возможность запарковаться в снегопад.",
                 Author = "Королёв",
                 Date = DateTime.Today.ToString(),
                Type = 1,
                Tags = "Omoda, Полный привод"
            };
        
            // добавляем их в бд
            db.Articles.AddRange(user1, user2, user3, user4);
            db.SaveChanges();
        }*/
        //_articleRepository.push();
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("/Articles")]
    public IActionResult Articles()
    {
        return View("Articles");
    }
    
    [HttpGet("/AddArticle")]
    public IActionResult AddArticle()
    {
        return View("AddArticle");
    }
    
    [HttpGet("/Article/{id}")]
    public IActionResult Article(int id)
    {
        var article = _articleRepository.GetArticle(id);
        
        var viewModel = new ArticleViewModel
        {
            title = article.Title,
            // image = "https://autotuni.ru/uploads/posts/2019-10/1571776755_c982bf1e-audi-tt-rs-abt-3.jpg",
            image = article.Image,
            annotation = article.Annotation
        };
        return View("Article", viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}