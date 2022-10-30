using StriveAPI.Models;

namespace StriveAPI.Services;

public class CharacterService
{
    public IEnumerable<Character> GetCharacters()
    {
        return new List<Character>();
    }

    public Character GetCharacter(int id)
    {
        return new Character()
        {
            CharacterId = id,
            CharacterName = "Ramlethal",
        };
    }
}

