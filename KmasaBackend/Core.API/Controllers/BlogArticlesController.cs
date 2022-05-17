using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogArticlesController : ControllerBase
    {

        /// <summary>
        /// Get All Blog Articles
        /// </summary>
        [HttpGet("allBlogArticles")]
        public async Task<ActionResult> GetAllBlogArticles(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Get blog article by id
        /// </summary>
        [HttpGet("blogArticle/{id}")]
        public async Task<ActionResult> GetBlogArticleById(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Add new blog article
        /// </summary>
        [HttpPost("addnew")]
        public async Task<ActionResult> AddBlogArticle(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update blog article
        /// </summary>
        [HttpPut("updateBlogArticle/{id}")]
        public async Task<ActionResult> UpdateBlogArticle(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// Update blog article picture
        /// </summary>
        [HttpPut("updateBlogArticle/{id}/updatePicture")]
        public async Task<ActionResult> UpdateBlogArticlePicture(int currentPage, int pageSize)
        {
            return Ok();
        }

        /// <summary>
        /// delete blog article
        /// </summary>
        [HttpDelete("deleteBlogArticle/{id}")]
        public async Task<ActionResult> Delete(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}
