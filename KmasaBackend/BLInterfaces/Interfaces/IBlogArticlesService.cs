using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.BlogArticles;

namespace BLInterfaces.Interfaces
{
    public interface IBlogArticlesService
    {
        Task<PagedModel<GetBlogArticleDto>> GetAllBlogArticles(int currentPage, int pageSize);

        Task<GetBlogArticleDto> GetArticleById(int id);

        Task<int> AddBlogArticle(AddBlogArticleDto dto);

        Task<bool> UpdateBlogArticle(int id, AddBlogArticleDto dto);

        Task<bool> UpdatePicture(int id, PhotoDto dto);

        Task<bool> DeleteBlogArticle(int id);
    }
}
