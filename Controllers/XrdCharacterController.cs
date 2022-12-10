using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/xrd/characters")]
[ApiController]
public class XrdCharacterController : ControllerBase
{
    private readonly XrdRepository _repository;
    private readonly IMapper _mapper;

    public XrdCharacterController(XrdRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<XrdCharacterDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<XrdCharacterDto>>(characterEntities));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<XrdCharacterDto>> GetCharacterById(int id)
    {
        var characterEntity = await _repository.GetCharacterByIdAsync(id);
        if (!await _repository.CharacterExists(id))
            return NotFound();
        return Ok(_mapper.Map<XrdCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<XrdCharacterDto>> GetCharacterByName(string name)
    {
        var characterEntity = await _repository.GetCharacterByNameAsync(name);
        if (!await _repository.CharacterExists(name))
            return NotFound();
        return Ok(_mapper.Map<XrdCharacterDto>(characterEntity));
    }

    [HttpGet]
    [Route("{characterId:int}/moves")]
    public async Task<ActionResult<IEnumerable<XrdMoveDto>>> GetMoveListNoData(int characterId)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterId);
        if (!await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<XrdMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route("{characterName}/moves")]
    public async Task<ActionResult<IEnumerable<XrdMoveDto>>> GetMoveListNoData(string characterName)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterName);
        if (!await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<XrdMoveDto>>(characterMoves));
    }

    [HttpGet]
    [Route(template: "{characterId:int}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<XrdMoveDto>>> GetMoveData(int characterId, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterId, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterId))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<XrdMoveDto>>(moveData));
    }

    [HttpGet]
    [Route(template: "{characterName}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<XrdMoveDto>>> GetMoveData(string characterName, string moveName)
    {
        var moveData = await _repository.GetMoveDataForCharacterAsync(characterName, moveName);
        if (!await _repository.MoveExists(moveName) || !await _repository.CharacterExists(characterName))
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<AccentCoreMoveDto>>(moveData));
    }
}