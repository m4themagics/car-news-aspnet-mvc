namespace WebApplication1.Entities;

public class Article
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Annotation { get; set; }
    public string Author { get; set; }
    public string Date { get; set; }
    public int Type { get; set; }
    public string Tags  { get; set; }
}