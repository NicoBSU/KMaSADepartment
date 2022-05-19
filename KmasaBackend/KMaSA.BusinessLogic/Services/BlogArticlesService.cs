using AutoMapper;
using BLInterfaces.Interfaces;
using DAInterfaces.Repositories;
using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.BlogArticles;

namespace KMaSA.BusinessLogic.Services
{
    public class BlogArticlesService : IBlogArticlesService
    {
        private readonly IMapper _mapper;
        private readonly IBlogArticlesRepository _blogArticlesRepository;
        public BlogArticlesService(IBlogArticlesRepository blogArticlesRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _blogArticlesRepository = blogArticlesRepository;
        }

        public async Task<PagedModel<GetBlogArticleDto>> GetAllBlogArticles(int currentPage, int pageSize)
        {
            var result = await _blogArticlesRepository.GetAsync(currentPage, pageSize);
            return result;
        }

        public async Task<GetBlogArticleDto> GetArticleById(int id)
        {
            var result = await _blogArticlesRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<int> AddBlogArticle(AddBlogArticleDto dto)
        {
            var articleId = await _blogArticlesRepository.AddAsync(dto);
            return articleId;
        }

        public async Task<bool> UpdateBlogArticle(int id, AddBlogArticleDto dto)
        {
            var result = await _blogArticlesRepository.UpdateAsync(id, dto);
            return result;
        }

        public async Task<bool> UpdatePicture(int id, PhotoDto dto)
        {
            var result = await _blogArticlesRepository.UpdatePicture(id,dto);
            return result;
        }

        public async Task<bool> DeleteBlogArticle(int id)
        {
            var result = await _blogArticlesRepository.DeleteAsync(id);
            return result;
        }
    }
}
