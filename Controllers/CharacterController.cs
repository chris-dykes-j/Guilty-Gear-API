using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("characters")]
[ApiController]
public class CharacterController : ControllerBase 
{
    private readonly CharacterService _service;

    public CharacterController(CharacterService service)
    {
        _service = service;
    }
    
    public IEnumerable<Character> GetCharacters()
    {
        return _service.GetCharacters();
    }

    [Route("{id:int}")]
    public Character GetCharacter(int id)
    {
        return _service.GetCharacter(id);
    }
}