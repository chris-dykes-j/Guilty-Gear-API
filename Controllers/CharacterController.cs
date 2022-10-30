using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("characters")]
[ApiController]
public class CharacterController : ControllerBase 
{
    private readonly CharacterRepository _repository;
    private readonly IMapper _mapper;

    public CharacterController(CharacterRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterNoMovesDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<CharacterNoMovesDto>>(characterEntities));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
    {
        var characterEntity = await _repository.GetCharacterAsync(id);
        var characterMoves = await _repository.GetMovesForCharacterAsync(id); // idk how it knows to map onto the character entity; without this line, it is empty. It must be magic.
        return Ok(_mapper.Map<CharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{characterId:int}/moves")]
    public async Task<ActionResult<IEnumerable<MoveDto>>> GetMoveListNoData(int characterId)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterId);
        return Ok(_mapper.Map<IEnumerable<MoveDto>>(characterMoves));
    }
}