using Microsoft.AspNetCore.Mvc;
using Application.Features.DijitalIcerikler.Commands.Create;
using Application.Features.DijitalIcerikler.Commands.Update;
using Application.Features.DijitalIcerikler.Commands.Delete;
using Application.Features.DijitalIcerikler.Queries.GetById;
using Application.Features.DijitalIcerikler.Queries.GetList;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DijitalIceriklerController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDijitalIcerikResponse>> Create([FromBody] CreateDijitalIcerikCommand command)
    {
        var res = await Mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = res.Id }, res);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDijitalIcerikResponse>> Update([FromBody] UpdateDijitalIcerikCommand command)
    {
        var res = await Mediator.Send(command);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDijitalIcerikResponse>> Delete([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new DeleteDijitalIcerikCommand { Id = id });
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDijitalIcerikResponse>> GetById([FromRoute] Guid id)
    {
        var res = await Mediator.Send(new GetByIdDijitalIcerikQuery { Id = id });
        return Ok(res);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GetListDijitalIcerikItemDto>>> GetList()
    {
        var res = await Mediator.Send(new GetListDijitalIcerikQuery());
        return Ok(res);
    }
}


