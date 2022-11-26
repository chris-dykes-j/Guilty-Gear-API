using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/strive/characters")]
[ApiController]
public class StriveCharacterController : ControllerBase, ICharacterController
{
    private readonly StriveRepository _repository;
    private readonly IMapper _mapper;

    public StriveCharacterController(StriveRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ICharacterDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<StriveCharacterDto>>(characterEntities));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ICharacterDto>> GetCharacterById(int id)
    {
        var characterEntity = await _repository.GetCharacterByIdAsync(id);
        if (!await _repository.CharacterExists(id))
            return NotFound();
        return Ok(_mapper.Map<StriveCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<ICharacterDto>> GetCharacterByName(string name)
    {
        var characterEntity = await _repository.GetCharacterByNameAsync(name);
        if (!await _repository.CharacterExists(name))
            return NotFound();
        return Ok(_mapper.Map<StriveCharacterDto>(characterEntity));
    }
    
    [HttpGet]
    [Route("{characterId:int}/moves")]
    public async Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(int characterId)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterId);
        if (!await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route("{characterName}/moves")]
    public async Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(string characterName)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterName);
        if (!await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(characterMoves));
    }
    
    [HttpGet]
    [Route(template: "{characterId:int}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(int characterId, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterId, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(moveData));
    }
    
    [HttpGet]
    [Route(template: "{characterName}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(string characterName, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterName, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveDto>>(moveData));
    }
}
