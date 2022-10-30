using StriveAPI.Models;

namespace StriveAPI.Services;

public class CharacterRepository
{
    public IEnumerable<CharacterNoMovesDto> GetCharacters()
    {
        return new List<CharacterNoMovesDto>();
    }

    public CharacterDto GetCharacter(int id)
    {
        return new CharacterDto()
        {
            Id = id,
            CharacterName = "Ramlethal",
        };
    }
}
