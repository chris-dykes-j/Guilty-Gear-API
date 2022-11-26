using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;

namespace StriveAPI.Controllers;

public interface ICharacterController
{
    Task<ActionResult<IEnumerable<ICharacterDto>>> GetCharacters();
    Task<ActionResult<ICharacterDto>> GetCharacterById(int id);
    Task<ActionResult<ICharacterDto>> GetCharacterByName(string name);
    Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(int characterId);
    Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveListNoData(string characterName);
    Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(int characterId, string moveName);
    Task<ActionResult<IEnumerable<IMoveDto>>> GetMoveData(string characterName, string moveName);
}