using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/plusr/characters")]
[ApiController]
public class AccentCoreCharacterController : ControllerBase
{
    private readonly AccentCoreRepository _repository;
    private readonly IMapper _mapper;

    public AccentCoreCharacterController(AccentCoreRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccentCoreCharacterDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<AccentCoreCharacterDto>>(characterEntities));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<AccentCoreCharacterDto>> GetCharacterById(int id)
    {
        var characterEntity = await _repository.GetCharacterByIdAsync(id);
        if (!await _repository.CharacterExists(id))
            return NotFound();
        return Ok(_mapper.Map<AccentCoreCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<AccentCoreCharacterDto>> GetCharacterByName(string name)
    {
        var characterEntity = await _repository.GetCharacterByNameAsync(name);
        if (!await _repository.CharacterExists(name))
            return NotFound();
        return Ok(_mapper.Map<AccentCoreCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{characterId:int}/moves")]
    public async Task<ActionResult<IEnumerable<AccentCoreMoveDto>>> GetMoveListNoData(int characterId)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterId);
        if (!await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<AccentCoreMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route("{characterName}/moves")]
    public async Task<ActionResult<IEnumerable<AccentCoreMoveDto>>> GetMoveListNoData(string characterName)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterName);
        if (!await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<AccentCoreMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route(template: "{characterId:int}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<AccentCoreMoveDto>>> GetMoveData(int characterId, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterId, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<AccentCoreMoveDto>>(moveData));
    }

    [HttpGet]
    [Route(template: "{characterName}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<AccentCoreMoveDto>>> GetMoveData(string characterName, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterName, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<AccentCoreMoveDto>>(moveData));
    }
}