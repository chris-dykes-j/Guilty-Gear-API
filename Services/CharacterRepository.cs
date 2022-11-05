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
            .OrderBy(character => character.Id)
            .ToListAsync();
    }

    public async Task<Character?> GetCharacterByIdAsync(int characterId)
    {
        return await _context.Characters
            .Where(c => characterId == c.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<Character?> GetCharacterByNameAsync(string characterName)
    {
        return await _context.Characters
            .Where(c => characterName == c.CharacterName) 
            .FirstOrDefaultAsync();
    }
    public async Task<ICollection<Move>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.Moves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    // Overloaded methods
    public async Task<ICollection<Move>> GetMovesForCharacterAsync(string characterName)
    {
        var characterId = _context.Characters
            .Where(c => characterName == c.CharacterName)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.Moves
            .Where(m => characterId.Result == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }
    
    public async Task<Move?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        return await _context.Moves
            .Where(m => moveName == m.MoveName && m.CharacterId == characterId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Move?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        var characterId = _context.Characters
            .Where(c => characterName == c.CharacterName)
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.Moves
            .Where(m => moveName == m.MoveName && m.CharacterId == characterId.Result)
            .FirstOrDefaultAsync();
    }

    // For now it's fine
    public async Task<List<Move>> GetMovesByInput(string moveName)
    {
        return await _context.Moves
            .Where(m => moveName == m.MoveName)
            .ToListAsync();
    }

    /*
    public Task<List<(Move, Character)>?> GetMovesByInput(string moveName)
    {
        var moveList =
            from moves in _context.Moves
            join characters in _context.Characters on moves.CharacterId equals characters.Id
            where moveName == moves.MoveName
            select new
            {
                Move = moves,
                Character = characters,
            };

        var result = moveList.ToListAsync();
        return result;
    }
    */
}
