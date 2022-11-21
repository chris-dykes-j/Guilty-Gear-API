using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public interface ICharacterRepository
{
    Task<IEnumerable<StriveCharacter>> GetAllCharactersAsync();
    Task<StriveCharacter?> GetCharacterByIdAsync(int characterId);
    Task<StriveCharacter?> GetCharacterByNameAsync(string characterName);
    Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(int characterId);
    Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(string characterName);
    Task<StriveMove?> GetMoveDataForCharacterAsync(int characterId, string moveName);
    Task<StriveMove?> GetMoveDataForCharacterAsync(string characterName, string moveName);
    Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByName(string moveName);
    Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByInput(string moveInput);
    Task<bool> CharacterExists(int id);
    Task<bool> CharacterExists(string name);
    Task<bool> MoveExists(string name);
}