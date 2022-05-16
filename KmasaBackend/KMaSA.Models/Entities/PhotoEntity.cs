namespace KMaSA.Models.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public UserEntity User { get; set; }
        public int UserId { get; set; }
    }
}
