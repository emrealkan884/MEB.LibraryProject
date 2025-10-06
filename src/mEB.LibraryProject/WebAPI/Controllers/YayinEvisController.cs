using Application.Features.YayinEvis.Commands.Create;
using Application.Features.YayinEvis.Commands.Delete;
using Application.Features.YayinEvis.Commands.Update;
using Application.Features.YayinEvis.Queries.GetById;
using Application.Features.YayinEvis.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YayinEvisController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedYayinEviResponse>> Add([FromBody] CreateYayinEviCommand command)
    {
        CreatedYayinEviResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedYayinEviResponse>> Update([FromBody] UpdateYayinEviCommand command)
    {
        UpdatedYayinEviResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedYayinEviResponse>> Delete([FromRoute] Guid id)
    {
        DeleteYayinEviCommand command = new() { Id = id };

        DeletedYayinEviResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdYayinEviResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdYayinEviQuery query = new() { Id = id };

        GetByIdYayinEviResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListYayinEviListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListYayinEviQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListYayinEviListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}