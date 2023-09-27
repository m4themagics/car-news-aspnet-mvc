namespace WebApplication1.Entities;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
    public long ParentId { get; set; }
}