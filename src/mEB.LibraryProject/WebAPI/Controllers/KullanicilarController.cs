using Microsoft.AspNetCore.Mvc;
using Application.Features.Kullanicilar.Commands.Create;
using Application.Features.Kullanicilar.Commands.Update;
using Application.Features.Kullanicilar.Commands.Delete;
using Application.Features.Kullanicilar.Queries.GetById;
using Application.Features.Kullanicilar.Queries.GetList;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KullanicilarController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedKullaniciResponse>> Create([FromBody] CreateKullaniciCommand command)
    {
        var res = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedKullaniciResponse>> Update([FromBody] UpdateKullaniciCommand command)
    {
        var res = await Mediator.Send(command);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedKullaniciResponse>> Delete([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new DeleteKullaniciCommand { Id = id });
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdKullaniciResponse>> GetById([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new GetByIdKullaniciQuery { Id = id });
        return Ok(res);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetListKullaniciItemDto>>> GetList()
    {
        var res = await Mediator.Send(new GetListKullaniciQuery());
        return Ok(res);
    }
}


