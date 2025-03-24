using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokedexApi.Mappers;
using PokedexApi.Services;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HobbiesController : ControllerBase
{
    private readonly IHobbyService _hobbyService;

    public HobbiesController(IHobbyService hobbyService)
    {
        _hobbyService = hobbyService;
    }
    //localhost/api/v1/hobbies/123524-1234
    [HttpGet("{id}")]
    public async Task<ActionResult<HobbyResponse>> GetHobbyById(Guid id, CancellationToken cancellationToken)
    {
        var hobby = await _hobbyService.GetHobbyByIdAsync(id, cancellationToken);
        if (hobby == null){
            return NotFound();
        }
        return Ok(hobby.ToDto());
    }

    /* MALA PRACTICA
    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<List<HobbyResponse>>> GetHobbyByName(string name, CancellationToken cancellationToken)
    {
        var hobby = await _hobbyService.GetHobbyByNameAsync(name, cancellationToken);
        if (hobby == null){
            return NotFound();
        }
        return Ok(hobby.ToDtoList());
    }*/

    [HttpGet]
    public async Task<ActionResult<List<HobbyResponse>>> GetHobbyByName([FromQuery]string name, CancellationToken cancellationToken)
    {
        var hobby = await _hobbyService.GetHobbyByNameAsync(name, cancellationToken);
        return Ok(hobby.ToDtoList());
    }

    [HttpDelete("{id}")]
    //204 - NoContent (Se encontro y se elimino el hobby de manera correcta pero el body de respuesta esta vacio)
    //200 - ok (se encontro y se elimino y en el body de respuesta se manda un mensaje de exito)
    public async Task<ActionResult> DeleteHobbyById(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _hobbyService.DeleteHobbyByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent(); //204
        }
        return NotFound(); //404
    }
}