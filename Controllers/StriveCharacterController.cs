using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/strive/characters")]
[ApiController]
public class StriveCharacterController : ControllerBase 
{
    private readonly StriveCharacterRepository _repository;
    private readonly IMapper _mapper;

    public StriveCharacterController(StriveCharacterRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StriveCharacterNoMovesDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<StriveCharacterNoMovesDto>>(characterEntities));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<StriveCharacterDto>> GetCharacterById(int id)
    {
        var characterEntity = await _repository.GetCharacterByIdAsync(id);
        if (characterEntity == null) NotFound();
        var characterMoves = await _repository.GetMovesForCharacterAsync(id); // idk how it knows to map onto the character entity; without this line, it is empty. It must be magic.
        return Ok(_mapper.Map<StriveCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<StriveCharacterDto>> GetCharacterByName(string name)
    {
        var characterEntity = await _repository.GetCharacterByNameAsync(name);
        if (characterEntity == null) NotFound();
        var characterMoves = await _repository.GetMovesForCharacterAsync(name); // more magic.
        return Ok(_mapper.Map<StriveCharacterDto>(characterEntity));
    }
    [HttpGet]
    [Route("{characterId:int}/moves")]
    public async Task<ActionResult<IEnumerable<StriveMoveDto>>> GetMoveListNoData(int characterId)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterId);
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route(template: "{characterId:int}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<StriveMoveDto>>> GetMoveData(int characterId, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterId, moveName);
        if (moveData == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(moveData));
    }
    
    [HttpGet]
    [Route(template: "{characterName}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<StriveMoveDto>>> GetMoveData(string characterName, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterName, moveName);
        if (moveData == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(moveData));
    }
}
