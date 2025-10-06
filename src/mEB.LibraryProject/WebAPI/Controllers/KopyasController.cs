using Application.Features.Kopyas.Commands.Create;
using Application.Features.Kopyas.Commands.Delete;
using Application.Features.Kopyas.Commands.Update;
using Application.Features.Kopyas.Queries.GetById;
using Application.Features.Kopyas.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KopyasController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKopyaResponse>> Add([FromBody] CreateKopyaCommand command)
    {
        CreatedKopyaResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKopyaResponse>> Update([FromBody] UpdateKopyaCommand command)
    {
        UpdatedKopyaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKopyaResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKopyaCommand command = new() { Id = id };

        DeletedKopyaResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKopyaResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKopyaQuery query = new() { Id = id };

        GetByIdKopyaResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListKopyaListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKopyaQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKopyaListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}