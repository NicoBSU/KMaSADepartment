using AutoMapper;
using BLInterfaces.Interfaces;
using KMaSA.Models;
using KMaSA.Models.DTO;
using KMaSA.Models.DTO.BlogArticles;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogArticlesController : ControllerBase
    {
        private readonly IBlogArticlesService _blogArticlesService;
        private readonly IMapper _mapper;

        public BlogArticlesController(IBlogArticlesService blogArticlesService,
            IMapper mapper)
        {
            _blogArticlesService = blogArticlesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Blog Articles
        /// </summary>
        [HttpGet("allBlogArticles")]
        public async Task<ActionResult<PagedModel<GetBlogArticleDto>>> GetAllBlogArticles(int currentPage, int pageSize)
        {
            var result = await _blogArticlesService.GetAllBlogArticles(currentPage,pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Get blog article by id
        /// </summary>
        [HttpGet("blogArticle/{id}")]
        public async Task<ActionResult<GetBlogArticleDto>> GetBlogArticleById(int id)
        {
            var result = await _blogArticlesService.GetArticleById(id);
            if (result is null) return NotFound("Article not found");
            return Ok(result);
        }

        /// <summary>
        /// Add new blog article
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddBlogArticle(AddBlogArticleDto dto)
        {
            var result = await _blogArticlesService.AddBlogArticle(dto);
            if (result == 0) return NotFound("Failed to add blog article");
            return Ok(result);
        }

        /// <summary>
        /// Update blog article
        /// </summary>
        [HttpPut("updateBlogArticle/{id}")]
        public async Task<ActionResult> UpdateBlogArticle(int id, AddBlogArticleDto dto)
        {
            var result = await _blogArticlesService.UpdateBlogArticle(id,dto);
            if (result) return Ok(dto);
            return BadRequest("Failed to update article");
        }

        /// <summary>
        /// Update blog article picture
        /// </summary>
        [HttpPut("updateBlogArticle/{id}/updatePicture")]
        public async Task<ActionResult> UpdateBlogArticlePicture(int id, PhotoDto dto)
        {
            var result = await _blogArticlesService.UpdatePicture(id, dto);
            if (result) return Ok(dto);
            return BadRequest("Failed to update article's picture");
        }

        /// <summary>
        /// delete blog article
        /// </summary>
        [HttpDelete("deleteBlogArticle/{id}")]
        public async Task<ActionResult> DeleteBlogArticle(int id)
        {
            var result = await _blogArticlesService.DeleteBlogArticle(id);
            if (result) return Ok();
            return BadRequest("Failed to delete article");
        }
    }
}
