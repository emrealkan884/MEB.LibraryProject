using Application.Features.Esers.Commands.Create;
using Application.Features.Esers.Commands.Delete;
using Application.Features.Esers.Commands.Update;
using Application.Features.Esers.Queries.GetById;
using Application.Features.Esers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EsersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEserResponse>> Add([FromBody] CreateEserCommand command)
    {
        CreatedEserResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEserResponse>> Update([FromBody] UpdateEserCommand command)
    {
        UpdatedEserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEserResponse>> Delete([FromRoute] Guid id)
    {
        DeleteEserCommand command = new() { Id = id };

        DeletedEserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEserResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdEserQuery query = new() { Id = id };

        GetByIdEserResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListEserListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEserQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}