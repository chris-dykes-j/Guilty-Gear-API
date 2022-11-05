using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/moves")]
[ApiController]
public class MoveController : ControllerBase
{
    private readonly CharacterRepository _repository;
    private readonly IMapper _mapper;

    public MoveController(CharacterRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [Route("{moveName}")]
    public async Task<ActionResult<List<MoveWithCharacterNameDto>>> GetMoveByInput(string moveName)
    {
        var moveData = await _repository.GetMovesByInput(moveName);
        if (moveData == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<MoveDto>>(moveData));
    }
}