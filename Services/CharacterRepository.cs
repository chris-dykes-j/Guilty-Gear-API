using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public class CharacterRepository
{
    private readonly StriveDb _context;
    public CharacterRepository(StriveDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<List<Character?>> GetAllCharactersAsync()
    {
        return await _context.Characters.OrderBy(character => character!.Id).ToListAsync();
    }

    public async Task<Character?> GetCharacterAsync(int id)
    {
        return await _context.Characters
            .Where(c => id == c!.Id)
            .FirstOrDefaultAsync();
    }
}
