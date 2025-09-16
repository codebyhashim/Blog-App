
using Application.feature.Post.GetById;
using Application.model.Dto;
using Application.model.ResponseWrapper;
using Application.Repositories;
using BlogApi.Controllers.Common;
using Dapper;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using static Domain.Constants.BlogConstants;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class BlogPostController : BasiApiController
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly IMediator _mediator;

        public IGenericRepository<BlogModel> _repository { get; }
      

        public BlogPostController(IGenericRepository<BlogModel> repository , ILogger<BlogPostController> logger , IMediator mediator )
        {
            _repository = repository;
            _logger = logger;
            this._mediator = mediator;
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
                
                _logger.LogError(ex, "controller: blogpost action : createPost message:error occured while creating post");
                return StatusCode(500,new {message =ex.StackTrace});
            }
          
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdateBlogDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var blogModel = new BlogModel
                {
                    BlogPostId = model.BlogPostId,
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = model.CategoryId,
                    ImageUrl=model.ImageUrl,
                    Status= Domain.Model.PostStatus.Draft,
                    UserId=model.UserId
                     
    };
                var post = await _repository.UpdateAsync(blogModel, "updateBlog", model.BlogPostId);
                return Ok(new { message = "message : post create succefully CreatedPost : " });

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ControllerName: blogpost ActionName : UpdatePost message:doest create post");
                return StatusCode(500, "an error occured while updating post");
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletePost([FromBody] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var post = await _repository.DeleteAsync(id, "delete_blog");
                return Ok(new { message = "message : post deleted succefully " });

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "ControllerName: blogpost ActionName : DeletePost message:doesnt delete post");
                return StatusCode(500, "an error occured while deleting post");
            }
        }

            [HttpGet("GetById/{id}")]
            public async Task<IActionResult> GetPostById(int id)
            {

            return HandleResponse(await _mediator.Send(new GetPostByIdRequest { Id = id }));
            //return Ok(await _mediator.Send(new GetPostByIdRequest { Id = id }));



            //if (!ModelState.IsValid)
            //{

            //    return BadRequest(ErrorResult.Failure(CustomStatusKey.validationError, CustomStatusCodes.InternalServerError));

            //}
            //var postObj = await _repository.GetByIdAsync(id, "getPostById");

            //if (postObj == null)
            //{
            //    _logger.LogError("record are not exist");

            //    return NotFound(ErrorResult.Failure(CustomStatusKey.NotExist, CustomStatusCodes.InternalServerError));

            //}
            //return Ok(new { message = "message : get successfully post", postObj });
        }
    }
}
