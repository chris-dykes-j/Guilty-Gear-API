using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Entities;
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
        return Ok(_mapper.Map<CharacterDto>(characterEntity));
    }
}