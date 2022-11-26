using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/xrd/characters")]
[ApiController]
public class XrdCharacterController : ControllerBase, ICharacterController
{
    private readonly XrdRepository _repository;
    private readonly IMapper _mapper;

    public XrdCharacterController(XrdRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ICharacterDto>>> GetCharacters()
    {
        var characterEntities = await _repository.GetAllCharactersAsync();
        return Ok(_mapper.Map<IEnumerable<XrdCharacterDto>>(characterEntities));
    }

    [HttpGet]
    public async Task<ActionResult<ICharacterDto>> GetCharacterById(int id)
    {
        var characterEntity = await _repository.GetCharacterByIdAsync(id);
        if (!await _repository.CharacterExists(id))
            return NotFound();
        return Ok(_mapper.Map<XrdCharacterDto>(characterEntity));
    }

    [HttpGet]
    public Task<ActionResult<ICharacterDto>> GetCharacterByName(string name)
    {
        throw new InvalidOperationException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(int characterId)
    {
        throw new InvalidOperationException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(string characterName)
    {
        throw new InvalidOperationException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(int characterId, string moveName)
    {
        throw new InvalidOperationException();
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(string characterName, string moveName)
    {
        throw new InvalidOperationException();
    }
}