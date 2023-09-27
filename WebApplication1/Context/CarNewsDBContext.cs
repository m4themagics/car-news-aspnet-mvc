using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Context;

public class CarNewsDBContext : DbContext
{

    private static readonly string ConnectionString =
        "Data Source=SQL8003.site4now.net;Initial Catalog=db_a9820b_carnews;User Id=db_a9820b_carnews_admin;Password=20012009Ob";
    public CarNewsDBContext()
    {
    }

    public DbSet<Article> Articles { get; set; } = null!;

    public CarNewsDBContext(DbContextOptions<CarNewsDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "carnews.db" };
        
        // var connectionString = connectionStringBuilder.ToString();

        optionsBuilder.UseSqlServer(ConnectionString);
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder
    //         .Entity<Article>()
    //         .HasKey(j => j.Id);
    //     
    //     
    //     modelBuilder
    //         .Entity<Article>()
    //         .HasData
    //         (
    //             new Article
    //             {
    //                 Id = 1,
    //                 Title = "Какие шины выбрать на зиму — с шипами или без? Мнение эксперта",
    //                 Image = "winter-tyres.jpg",
    //                 Annotation = "Известно, что по использованию зимних шин автомобилисты делятся на две полярные группы."
    //                     + "Одна категорична в том, что на льду лишь шипы «спасут мир»."
    //                     + "Другая ратует за фрикционки, обзывая пользователей шиповок «штроборезами»,"
    //                     + "намекая на выфрезерованные такими шинами колеи на асфальте.",
    //                 Author = "Иванов",
    //                 Date = DateTime.Today,
    //                 Type = 2,
    //                 Tags = "зима, резина"
    //             },
    //             new Article
    //             {
    //                 Id = 2,
    //                 Title = "Роберт Шварцман проведёт первую тренировку в Остине",
    //                 Image = "robert.jpg",
    //                 Annotation = "Роберт Шварцман примет участие в первой сессии свободных заездов Гран При США."
    //                              + "Тест-пилот Ferrari сядет за руль машины Шарля Леклера. Во второй тренировке монегаск вернётся в кокпит.",
    //                 Author = "Иванов",
    //                 Date = DateTime.Today,
    //                 Type = 3,
    //                 Tags = "Формула 1, Ferrari"
    //             },
    //             new Article
    //             {
    //                 Id = 3,
    //                 Title = "Audi отметит 25-летие TT особой серией из 100 автомобилей",
    //                 Image = "example-image-carousel.PNG",
    //                 Annotation = "Фирма Audi отметит 25-летие спорткара TT, выпустив лимитированную спецверсию Iconic Edition. "
    //                 +"Основой для новой модификации послужит купе TT RS; технических изменений не заявлено. "
    //                 +"Снаружи спецверсия отличится глянцевыми 20-дюймовыми легкосплавными дисками с направленным рисунком, "
    //                 +"углепластиковым задним антикрылом, видоизменённым диффузором и накладками на бамперах. "
    //                 +"Всего сделают 100 экземпляров Audi TT RS Iconic Edition для европейского рынка.",
    //                 Author = "Иванов",
    //                 Date = DateTime.Today,
    //                 Type = 1,
    //                 Tags = "Audi, TT"
    //             },
    //             new Article
    //             {
    //                 Id = 4,
    //                 Title = "Omoda C5 AWD",
    //                 Image = "article-5.PNG",
    //                 Annotation = "Добавить привод на все четыре можно по-разному. Простой подход состоит в том, чтобы установить муфту подключения задней оси и ещё пару сопутствующих железок. Так делает большинство производителей, чтобы обеспечить автомобилю уверенный старт на скользком покрытии и возможность запарковаться в снегопад.",
    //                 Author = "Королёв",
    //                 Date = DateTime.Today,
    //                 Type = 1,
    //                 Tags = "Omoda, Полный привод"
    //             }
    //         );
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}