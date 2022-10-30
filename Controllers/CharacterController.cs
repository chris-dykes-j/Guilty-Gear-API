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
    public IEnumerable<CharacterNoMovesDto> GetCharacters()
    {
        return _repository.GetCharacters();
    }

    [HttpGet]
    [Route("{id:int}")]
    public CharacterDto GetCharacter(int id)
    {
        return _repository.GetCharacter(id);
    }
}