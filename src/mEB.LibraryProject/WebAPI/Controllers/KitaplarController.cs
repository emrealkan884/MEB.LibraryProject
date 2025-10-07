using Application.Features.Kitaplar.Commands.Delete;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KitaplarController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKitapResponse>> Add([FromBody] CreateKitapCommand command)
    {
        CreatedKitapResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKitapResponse>> Update([FromBody] UpdateKitapCommand command)
    {
        UpdatedKitapResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKitapResponse>> Delete([FromRoute] Guid id)
    {
        DeleteKitapCommand command = new() { Id = id };

        DeletedKitapResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKitapResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdKitapQuery query = new() { Id = id };

        GetByIdKitapResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListKitapListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListKitapQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListKitapListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}