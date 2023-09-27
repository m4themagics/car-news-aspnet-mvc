using WebApplication1.DTO;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public interface IArticleRepository
{
    IEnumerable<Article> GetAll();
    Article GetArticle(int id);
    // void push();
    void Add(ArticleDTO articleDto);
}