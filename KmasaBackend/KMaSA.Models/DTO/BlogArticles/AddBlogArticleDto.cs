namespace KMaSA.Models.DTO.BlogArticles;

public class AddBlogArticleDto
{
    public DateTime PublicationDate { get; set; } = DateTime.Now;

    public string Title { get; set; }

    public string Content { get; set; }

    public PhotoDto Picture { get; set; }
}