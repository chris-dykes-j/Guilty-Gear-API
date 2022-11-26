using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public class XrdCharacterRepository : ICharacterRepository
{
    public Task<IEnumerable<ICharacter>> GetAllCharactersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICharacter?> GetCharacterByIdAsync(int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<ICharacter?> GetCharacterByNameAsync(string characterName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IMove>> GetMovesForCharacterAsync(int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IMove>> GetMovesForCharacterAsync(string characterName)
    {
        throw new NotImplementedException();
    }

    public Task<IMove?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        throw new NotImplementedException();
    }

    public Task<IMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CharacterExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CharacterExists(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> MoveExists(string name)
    {
        throw new NotImplementedException();
    }
}