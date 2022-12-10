using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Entities;

namespace StriveAPI.Services;

public class XrdRepository 
{
    private readonly GuiltyGearDb _context;

    public XrdRepository(GuiltyGearDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<XrdCharacter>> GetAllCharactersAsync()
    {
        return await _context.XrdCharacters
            .OrderBy(character => character.Id)
            .ToListAsync();
    }

    public async Task<XrdCharacter?> GetCharacterByIdAsync(int characterId)
    {
        return await _context.XrdCharacters
            .Where(c => characterId == c.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<XrdCharacter?> GetCharacterByNameAsync(string characterName)
    {
        return await _context.XrdCharacters
            // ToUpper() works since it's an SQL query. Throws a fit if you use String.Equals()
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper()) 
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<XrdMove>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.XrdMoves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<XrdMove>> GetMovesForCharacterAsync(string characterName)
    {
        var characterId = _context.XrdCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.XrdMoves
            .Where(m => characterId.Result == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    public async Task<XrdMove?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        
        return await _context.XrdMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId)
            .FirstOrDefaultAsync();
    }

    public async Task<XrdMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        var characterId = _context.XrdCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.XrdMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId.Result)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CharacterExists(int id)
    {
        return await _context.XrdCharacters
            .Where(c => c.Id == id)
            .AnyAsync();
    }

    public async Task<bool> CharacterExists(string name)
    {
        return await _context.XrdCharacters
            .Where(c => c.CharacterName.ToUpper() == name.ToUpper())
            .AnyAsync();
    }

    public async Task<bool> MoveExists(string name)
    {
        return await _context.XrdMoves
            .Where(m => m.MoveName.ToUpper() == name.ToUpper())
            .AnyAsync();
    }
}