namespace KMaSA.Models.Entities;

public class BlogArticleEntity
{
    public int Id { get; set; }

    public DateTime PublicationDate { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string? PicturesLinks { get; set; }
}