using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Entities;

namespace StriveAPI.Services;

public class AccentCoreRepository 
{
    private readonly GuiltyGearDb _context;
    
    public AccentCoreRepository(GuiltyGearDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<AccentCoreCharacter>> GetAllCharactersAsync()
    {
        return await _context.AccentCoreCharacters
            .OrderBy(character => character.Id)
            .ToListAsync();
    }
    
    public async Task<AccentCoreCharacter?> GetCharacterByIdAsync(int characterId)
    {
        return await _context.AccentCoreCharacters
            .Where(c => characterId == c.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<AccentCoreCharacter?> GetCharacterByNameAsync(string characterName)
    {
        return await _context.AccentCoreCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper()) 
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<AccentCoreMove>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.AccentCoreMoves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<AccentCoreMove>> GetMovesForCharacterAsync(string characterName)
    {
        var characterId = _context.AccentCoreCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.AccentCoreMoves
            .Where(m => characterId.Result == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    public async Task<AccentCoreMove?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        return await _context.AccentCoreMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId)
            .FirstOrDefaultAsync();
    }

    public async Task<AccentCoreMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        var characterId = _context.AccentCoreCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.AccentCoreMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId.Result)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CharacterExists(int id)
    {
        return await _context.AccentCoreCharacters
            .Where(c => c.Id == id)
            .AnyAsync();
    }

    public async Task<bool> CharacterExists(string name)
    {
        return await _context.AccentCoreCharacters
            .Where(c => c.CharacterName.ToUpper() == name.ToUpper())
            .AnyAsync();
    }

    public async Task<bool> MoveExists(string name)
    {
        return await _context.AccentCoreMoves
            .Where(m => m.MoveName.ToUpper() == name.ToUpper())
            .AnyAsync();
    }
}