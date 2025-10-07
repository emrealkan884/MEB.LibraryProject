using Application.Features.EserlerYazarlar.Commands.Create;
using Application.Features.EserlerYazarlar.Commands.Delete;
using Application.Features.EserlerYazarlar.Commands.Update;
using Application.Features.EserlerYazarlar.Queries.GetById;
using Application.Features.EserlerYazarlar.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EserlerYazarlarController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEserYazarResponse>> Add([FromBody] CreateEserYazarCommand command)
    {
        CreatedEserYazarResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEserYazarResponse>> Update([FromBody] UpdateEserYazarCommand command)
    {
        UpdatedEserYazarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEserYazarResponse>> Delete([FromRoute] Guid id)
    {
        DeleteEserYazarCommand command = new() { Id = id };

        DeletedEserYazarResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEserYazarResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdEserYazarQuery query = new() { Id = id };

        GetByIdEserYazarResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListEserYazarListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEserYazarQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEserYazarListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}