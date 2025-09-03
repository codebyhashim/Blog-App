using Application.Repositories;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Application;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class BlogPostController : Controller
    {
        private readonly ILogger<BlogModel> _logger;

        public IGenericRepository<BlogPostController> _repository { get; }
      

        public BlogPostController(IGenericRepository<BlogPostController> repository , ILogger<BlogModel> logger )
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePost([FromBody] BlogCreateDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _repository.AddAsync("blog_create",model);
                return Ok("row insert successfully");

            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "controller: blogpost action : createPost message:doest create post");
                return StatusCode(500,new {message =ex.StackTrace});
            }
          
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdatePost([FromBody] BlogPostController model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var post = await _repository.UpdateAsync(model);
                return Ok($"message : post create succefully CreatedPost : {post}");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ControllerName: blogpost ActionName : UpdatePost message:doest create post");
                return StatusCode(500, "an error occured while updating post");
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var post = await _repository.DeleteAsync(id);
                return Ok($"message : post create succefully DeletedPost : {post}");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ControllerName: blogpost ActionName : DeletePost message:doest create post");
                return StatusCode(500, "an error occured while deleting post");
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var post = await _repository.GetByIdAsync(id);
                return Ok($"message : succefully , Post : {post}");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ControllerName: blogpost ActionName : GetPostById  message:doest create post");
                return StatusCode(500, "an error occured while deleting post");
            }
        }
    }
}
