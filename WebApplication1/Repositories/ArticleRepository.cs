using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly CarNewsDBContext _context;
    // private readonly DalOptions _dalSettings;
    public ArticleRepository(CarNewsDBContext context)
    {
        _context = context;
    }
    public IEnumerable<Article> GetAll()
    {
        return _context.Articles.ToList();
    }

    public Article GetArticle(int id)
    {
        return _context.Articles.Where(article => article.Id == id).SingleOrDefault() ?? null;
    }

    public void Add(ArticleDTO articleDto)
    {
        var article = new Article()
        {
            //Id = _context.Articles.ToList().Max(x => x.Id) + 1,
            Title = articleDto.title,
            Image = articleDto.image,
            Annotation = articleDto.annotation,
            Author = articleDto.author,
            Date = articleDto.date.ToString(),
            Type = articleDto.type,
            Tags = articleDto.tags
        };
        _context.Articles.Add(article);
        _context.SaveChanges();
    }

    // public void push()
    // {
    //     _context.Articles.Add(new Article
    //     {
    //         Id = 3,
    //         Title = "Audi отметит 25-летие TT особой серией из 100 автомобилей",
    //         Image = "example-image-carousel.PNG",
    //         Annotation = "Фирма Audi отметит 25-летие спорткара TT, выпустив лимитированную спецверсию Iconic Edition. "
    //                      + "Основой для новой модификации послужит купе TT RS; технических изменений не заявлено. "
    //                      + "Снаружи спецверсия отличится глянцевыми 20-дюймовыми легкосплавными дисками с направленным рисунком, "
    //                      + "углепластиковым задним антикрылом, видоизменённым диффузором и накладками на бамперах. "
    //                      + "Всего сделают 100 экземпляров Audi TT RS Iconic Edition для европейского рынка.",
    //         Author = "Иванов",
    //         Date = DateTime.Today,
    //         Type = 1,
    //         Tags = "Audi, TT"
    //     });
    //     _context.Articles.Add(new Article
    //     {
    //         Id = 4,
    //         Title = "Omoda C5 AWD",
    //         Image = "article-5.PNG",
    //         Annotation = "Добавить привод на все четыре можно по-разному. Простой подход состоит в том, чтобы установить муфту подключения задней оси и ещё пару сопутствующих железок. Так делает большинство производителей, чтобы обеспечить автомобилю уверенный старт на скользком покрытии и возможность запарковаться в снегопад.",
    //         Author = "Королёв",
    //         Date = DateTime.Today,
    //         Type = 1,
    //         Tags = "Omoda, Полный привод"
    //     });
    // }
}