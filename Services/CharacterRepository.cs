using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Entities;

namespace StriveAPI.Services;

public class CharacterRepository
{
    private readonly StriveDb _context;
    public CharacterRepository(StriveDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters
            .OrderBy(character => character!.Id)
            .ToListAsync();
    }

    public async Task<Character?> GetCharacterAsync(int characterId)
    {
        return await _context.Characters
            .Where(c => characterId == c!.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<Move>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.Moves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m!.Id)
            .ToListAsync();
    }
    
}
