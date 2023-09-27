using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/tags")]
public class TagsController : Controller
{
    [HttpGet]
    public IReadOnlyCollection<TagDTO> getTags()
    {
        var tags = new List<TagDTO>
        {
            new(1, "Audi", 1),
            new(2, "Ferrari", 1),
            new(3, "Omoda", 1),
            new(4, "Lamborghini", 1),
            new(5, "зима", 2),
            new(6, "лето", 2),
            new(7, "резина", 3),
            new(8, "полный привод", 3),
            new(9, "Формула 1", 3),
            new(10, "спорткар", 3),
            new(11, "разное", 3),
        };
        return tags;
    }
}