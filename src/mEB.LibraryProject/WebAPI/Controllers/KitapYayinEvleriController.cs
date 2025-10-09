using Microsoft.AspNetCore.Mvc;
using Application.Features.KitapYayinEvleri.Commands.Create;
using Application.Features.KitapYayinEvleri.Commands.Update;
using Application.Features.KitapYayinEvleri.Commands.Delete;
using Application.Features.KitapYayinEvleri.Queries.GetById;
using Application.Features.KitapYayinEvleri.Queries.GetList;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KitapYayinEvleriController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKitapYayinEviResponse>> Create([FromBody] CreateKitapYayinEviCommand command)
    {
        var res = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKitapYayinEviResponse>> Update([FromBody] UpdateKitapYayinEviCommand command)
    {
        var res = await Mediator.Send(command);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKitapYayinEviResponse>> Delete([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new DeleteKitapYayinEviCommand { Id = id });
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKitapYayinEviResponse>> GetById([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new GetByIdKitapYayinEviQuery { Id = id });
        return Ok(res);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetListKitapYayinEviItemDto>>> GetList()
    {
        var res = await Mediator.Send(new GetListKitapYayinEviQuery());
        return Ok(res);
    }
}


