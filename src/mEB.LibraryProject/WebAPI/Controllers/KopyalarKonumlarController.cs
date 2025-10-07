using Application.Features.KopyalarKonumlar.Commands.Create;
using Application.Features.KopyalarKonumlar.Commands.Delete;
using Application.Features.KopyalarKonumlar.Commands.Update;
using Application.Features.KopyalarKonumlar.Queries.GetById;
using Application.Features.KopyalarKonumlar.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KopyalarKonumlarController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKopyaKonumResponse>> Add([FromBody] CreateKopyaKonumCommand command)
    {
        CreatedKopyaKonumResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKopyaKonumResponse>> Update([FromBody] UpdateKopyaKonumCommand command)
    {
        UpdatedKopyaKonumResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKopyaKonumResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKopyaKonumCommand command = new() { Id = id };

        DeletedKopyaKonumResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKopyaKonumResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKopyaKonumQuery query = new() { Id = id };

        GetByIdKopyaKonumResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListKopyaKonumListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKopyaKonumQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKopyaKonumListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}