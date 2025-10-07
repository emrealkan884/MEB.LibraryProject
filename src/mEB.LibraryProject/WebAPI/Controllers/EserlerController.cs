using Application.Features.Eserler.Commands.Create;
using Application.Features.Eserler.Commands.Delete;
using Application.Features.Eserler.Commands.Update;
using Application.Features.Eserler.Queries.GetById;
using Application.Features.Eserler.Queries.GetListByCategory;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EserlerController : BaseController
{
    /*[HttpPost]
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
    */
    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEserResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdEserQuery query = new() { Id = id };

        GetByIdEserResponse response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("kategori/{kategori}")]
    public async Task<IActionResult> GetByKategori(EserKategorisi kategori)
    {
        var query = new GetListEserByKategoriQuery { Kategori = kategori };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
}