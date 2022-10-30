using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("characters")]
[ApiController]
public class CharacterController : ControllerBase 
{
    private readonly CharacterRepository _repository;

    public CharacterController(CharacterRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<CharacterDto> GetCharacters()
    {
        return _repository.GetCharacters();
    }

    [Route("{id:int}")]
    public CharacterDto GetCharacter(int id)
    {
        return _repository.GetCharacter(id);
    }
}