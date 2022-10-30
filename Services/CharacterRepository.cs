using StriveAPI.Models;

namespace StriveAPI.Services;

public class CharacterRepository
{
    public IEnumerable<CharacterDto> GetCharacters()
    {
        return new List<CharacterDto>();
    }

    public CharacterDto GetCharacter(int id)
    {
        return new CharacterDto()
        {
            CharacterId = id,
            CharacterName = "Ramlethal",
        };
    }
}
