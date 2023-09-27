namespace WebApplication1.DTO;

public record ArticleDTO(
    long id,
    string title,
    string image,
    string annotation,
    string author,
    DateTime date,
    int type,
    string tags);