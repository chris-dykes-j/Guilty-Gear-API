using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public interface IGameRepository
{
    Task<IEnumerable<ICharacter>> GetAllCharactersAsync();
    Task<ICharacter?> GetCharacterByIdAsync(int characterId);
    Task<ICharacter?> GetCharacterByNameAsync(string characterName);
    Task<IEnumerable<IMove>> GetMovesForCharacterAsync(int characterId);
    Task<IEnumerable<IMove>> GetMovesForCharacterAsync(string characterName);
    Task<IMove?> GetMoveDataForCharacterAsync(int characterId, string moveName);
    Task<IMove?> GetMoveDataForCharacterAsync(string characterName, string moveName);
    Task<bool> CharacterExists(int id);
    Task<bool> CharacterExists(string name);
    Task<bool> MoveExists(string name);
}