using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Catagory;
using Application.Features.Catagories.Requests.Commands;
using Application.Features.Catagories.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatagoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatagoriesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        [HttpGet("{catagoryId:Guid}")]
        public async Task<ActionResult<CatagoryDto>> GetCatagory(Guid catagoryId)
        {
            var catagory = await _mediator.Send(new GetCatagoryDetailRequest{ Id = catagoryId });
            return Ok(catagory);
        }

        [HttpGet]
        public async Task<ActionResult<List<CatagoryListDto>>> GetAllCatagories(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Invalid page index or page size.");
            }
            
            var catagories = await _mediator.Send(new GetAllCatagoriesRequest { PageIndex = pageIndex, PageSize = pageSize });
            return Ok(catagories);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCatagoryDto catagory)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new CreateCatagoryCommand { CreateCatagoryDto = catagory };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCatagoryDto catagory)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new UpdateCatagoryCommand { UpdateCatagoryDto = catagory };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid commentId)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new DeleteCatagoryCommand { Id = commentId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}