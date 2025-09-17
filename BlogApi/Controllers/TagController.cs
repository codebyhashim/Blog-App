using System.Threading.Tasks;
using Application.feature.Post.Create;
using Application.feature.Post.Delete;
using Application.feature.Post.GetById;
using Application.feature.Tag.Create;
using Application.feature.Tag.Delete;
using Application.feature.Tag.GetById;
using Application.feature.Tag.Update;
using Application.model.Dto;
using Azure.Core;
using BlogApi.Controllers.Common;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class TagController : BasiApiController
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTagDto model)
        {
            return HandleResponse(await _mediator.Send(new CreateTagRequest { Model = model }));
           

        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            return HandleResponse(await _mediator.Send(new DeleteTagRequest { TagId = id }));

        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] TagModel model)
        {
            return HandleResponse(await _mediator.Send(new UpdateTagRequest { TagModel=model }));

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById( int id)
        {
            return HandleResponse(await _mediator.Send(new GetTagByIdRequest { Id= id }));

        }

        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    return View();
        //}

    }
}
