using Microsoft.AspNetCore.Mvc;
using Application.Features.KitapBaskilar.Commands.Create;
using Application.Features.KitapBaskilar.Commands.Update;
using Application.Features.KitapBaskilar.Commands.Delete;
using Application.Features.KitapBaskilar.Queries.GetById;
using Application.Features.KitapBaskilar.Queries.GetList;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KitapBaskilariController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKitapBaskiResponse>> Create([FromBody] CreateKitapBaskiCommand command)
    {
        var res = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKitapBaskiResponse>> Update([FromBody] UpdateKitapBaskiCommand command)
    {
        var res = await Mediator.Send(command);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKitapBaskiResponse>> Delete([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new DeleteKitapBaskiCommand { Id = id });
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKitapBaskiResponse>> GetById([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new GetByIdKitapBaskiQuery { Id = id });
        return Ok(res);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetListKitapBaskiItemDto>>> GetList()
    {
        var res = await Mediator.Send(new GetListKitapBaskiQuery());
        return Ok(res);
    }
}


