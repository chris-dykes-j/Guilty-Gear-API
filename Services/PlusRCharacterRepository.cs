using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public class PlusRCharacterRepository : ICharacterRepository
{
    public Task<IEnumerable<StriveCharacter>> GetAllCharactersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StriveCharacter?> GetCharacterByIdAsync(int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<StriveCharacter?> GetCharacterByNameAsync(string characterName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(int characterId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(string characterName)
    {
        throw new NotImplementedException();
    }

    public Task<StriveMove?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        throw new NotImplementedException();
    }

    public Task<StriveMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByName(string moveName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByInput(string moveInput)
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