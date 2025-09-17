using Application.feature.Post.Delete;
using Application.model.Dto;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Controllers.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using MediatR;
using Application.feature.Tag.Create;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTagDto model)
        {
            //return HandleResponse(await _mediator.Send(new CreateTagRequest { Tag=model}));
            return View();

        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            return View();
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] TagModel model)
        {
            return View();
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] int id)
        {
            return View();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return View();
        }

    }
}
