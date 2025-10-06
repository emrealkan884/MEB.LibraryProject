using Application.Features.Konums.Commands.Create;
using Application.Features.Konums.Commands.Delete;
using Application.Features.Konums.Commands.Update;
using Application.Features.Konums.Queries.GetById;
using Application.Features.Konums.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KonumsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKonumResponse>> Add([FromBody] CreateKonumCommand command)
    {
        CreatedKonumResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKonumResponse>> Update([FromBody] UpdateKonumCommand command)
    {
        UpdatedKonumResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKonumResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKonumCommand command = new() { Id = id };

        DeletedKonumResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKonumResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKonumQuery query = new() { Id = id };

        GetByIdKonumResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListKonumListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKonumQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKonumListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}