namespace KMaSA.Models.DTO;

public class BlogArticleDto : IDto
{
    public int Id { get; set; }

    public DateTime PublicationDate { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string PicturesLinks { get; set; }
}