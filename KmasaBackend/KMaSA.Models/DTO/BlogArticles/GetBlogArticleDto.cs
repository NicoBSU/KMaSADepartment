namespace KMaSA.Models.DTO.BlogArticles
{
    public class GetBlogArticleDto : IDto
    {
        public int Id { get; set; }

        public DateTime PublicationDate { get; set; } = DateTime.Now;

        public string Title { get; set; }

        public string Content { get; set; }

        public PhotoDto Picture { get; set; }
    }
}
