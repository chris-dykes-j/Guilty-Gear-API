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
            // ToUpper() actually works since it's an SQL query. Throws a fit if you use String.Equals()
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper()) 
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Move>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.Moves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    // Overloaded methods
    public async Task<IEnumerable<Move>> GetMovesForCharacterAsync(string characterName)
    {
        var characterId = _context.Characters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
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
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Move?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        var characterId = _context.Characters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.Moves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId.Result)
            .FirstOrDefaultAsync();
    }

    // Not ideal, as it's breaking the pattern from before, but it works just fine.
    public async Task<IEnumerable<MoveWithCharacterName>?> GetMovesByInput(string moveName)
    {
        var moveList =
            from moves in _context.Moves
            join characters in _context.Characters on moves.CharacterId equals characters.Id
            where moveName.ToUpper() == moves.MoveName.ToUpper()
            select new MoveWithCharacterName()
            {
                Id = moves.Id,
                CharacterName = characters.CharacterName,
                MoveName = moves.MoveName,
                Input = moves.Input,
                Damage = moves.Damage,
                Guard = moves.Guard,
                Startup = moves.Startup,
                Active = moves.Active,
                Recovery = moves.Recovery,
                Block = moves.Block,
                Invulnerability = moves.Invulnerability,
            };

        var result = await moveList.ToListAsync();
        return result;
    }
    
    /* Previous temporary implementation.
    public async Task<List<Move>?> GetMovesByInput(string moveName)
    {
        return await _context.Moves
            .Where(m => moveName == m.MoveName)
            .ToListAsync();
    }
    */
}
