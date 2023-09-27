namespace WebApplication1.DTO;

public record TagDTO(
    long id,
    string name,
    long parentId);