
using Application.feature.Post.Delete;
using Application.feature.Post.GetById;
using Application.feature.Post.Create;

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
using Application.feature.Post.Update;


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
        public async Task<IActionResult> CreatePost([FromBody] BlogCreateDto request)
        {
            
            return HandleResponse(await _mediator.Send(new CreatePostRequest { Model=request}));
            
          
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdateBlogDto model)
        {
            return HandleResponse(await _mediator.Send(new UpdatePostRequest { Model=model}));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletePost([FromBody] int id)
        {
            return HandleResponse(await _mediator.Send(new DeletePostRequest { Id=id}));
       
        }

            [HttpGet("GetById/{id}")]
            public async Task<IActionResult> GetPostById(int id)
            {

            return HandleResponse(await _mediator.Send(new GetPostByIdRequest { Id = id }));
           
        }
    }
}
