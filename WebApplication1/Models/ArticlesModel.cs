using WebApplication1.DTO;

namespace WebApplication1.Models;

public class ArticlesModel
{
    private IReadOnlyCollection<ArticleDTO> ArticleDtos { get; set; }
}