using Application.Features.Oduncler.Commands.Create;
using Application.Features.Oduncler.Commands.Delete;
using Application.Features.Oduncler.Commands.TeslimEt;
using Application.Features.Oduncler.Commands.Update;
using Application.Features.Oduncler.Queries.Dtos;
using Application.Features.Oduncler.Queries.GetById;
using Application.Features.Oduncler.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OdunclerController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedOduncResponse>> Add([FromBody] CreateOduncCommand command)
    {
        CreatedOduncResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedOduncResponse>> Update([FromBody] UpdateOduncCommand command)
    {
        UpdatedOduncResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedOduncResponse>> Delete([FromRoute] Guid id)
    {
        DeleteOduncCommand command = new() { Id = id };

        DeletedOduncResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdOduncResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdOduncQuery query = new() { Id = id };

        GetByIdOduncResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListOduncListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOduncQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListOduncListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    // 2. Teslim Etme (Ödünç -> TeslimEdildi)
    [HttpPut("{id}/teslim")]
    public async Task<ActionResult<TeslimEdildiOduncResponse>> TeslimEt([FromRoute] Guid id)
    {
        TeslimEtOduncCommand command = new() { OduncId = id };
        TeslimEdildiOduncResponse response = await Mediator.Send(command);
        return Ok(response);
    }
    
    // 7. Müsait Kopyalar (kullanıcıya seçenek sunmak için)
    [HttpGet("musait-kopyalar/{eserId}")]
    public async Task<ActionResult<List<MusaitKopyaDto>>> GetMusaitKopyalar([FromRoute] Guid eserId)
    {
        GetListMusaitKopyalarQuery query = new() { EserId = eserId };
        List<MusaitKopyaDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}