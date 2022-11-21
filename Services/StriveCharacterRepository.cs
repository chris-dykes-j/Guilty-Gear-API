using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Entities;
using StriveAPI.Models;

namespace StriveAPI.Services;

public class StriveCharacterRepository : ICharacterRepository
{
    private readonly GuiltyGearDb _context;
    public StriveCharacterRepository(GuiltyGearDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<StriveCharacter>> GetAllCharactersAsync()
    {
        return await _context.StriveCharacters
            .OrderBy(character => character.Id)
            .ToListAsync();
    }

    public async Task<StriveCharacter?> GetCharacterByIdAsync(int characterId)
    {
        return await _context.StriveCharacters
            .Where(c => characterId == c.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<StriveCharacter?> GetCharacterByNameAsync(string characterName)
    {
        return await _context.StriveCharacters
            // ToUpper() works since it's an SQL query. Throws a fit if you use String.Equals()
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper()) 
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(int characterId)
    {
        return await _context.StriveMoves
            .Where(m => characterId == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }

    // Overloaded methods
    public async Task<IEnumerable<StriveMove>> GetMovesForCharacterAsync(string characterName)
    {
        var characterId = _context.StriveCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.StriveMoves
            .Where(m => characterId.Result == m.CharacterId)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }
    
    public async Task<StriveMove?> GetMoveDataForCharacterAsync(int characterId, string moveName)
    {
        return await _context.StriveMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<StriveMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        var characterId = _context.StriveCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper())
            .Select(c => c.Id)
            .FirstOrDefaultAsync();
        
        return await _context.StriveMoves
            .Where(m => moveName.ToUpper() == m.MoveName.ToUpper() && m.CharacterId == characterId.Result)
            .FirstOrDefaultAsync();
    }

    // Not ideal, as it's breaking the pattern from before, but it works just fine.
    public async Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByName(string moveName)
    {
        string move = moveName.Replace(" ", "_");
        var moveList =
            from moves in _context.StriveMoves
            join characters in _context.StriveCharacters on moves.CharacterId equals characters.Id
            where move.ToUpper() == moves.MoveName.ToUpper()
            select new StriveMoveCharacterNameDto()
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
    
    public async Task<IEnumerable<StriveMoveCharacterNameDto>?> GetMovesByInput(string moveInput)
    {
        string move = moveInput.ToUpper();
        var moveList =
            from moves in _context.StriveMoves
            join characters in _context.StriveCharacters on moves.CharacterId equals characters.Id
            where move == moves.Input
            select new StriveMoveCharacterNameDto()
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

    public async Task<bool> CharacterExists(int id)
    { 
        return await _context.StriveCharacters
            .Where(c => c.Id == id)
            .AnyAsync();
    }
    
    public async Task<bool> CharacterExists(string name)
    {
        return await _context.StriveCharacters
            .Where(c => c.CharacterName == name)
            .AnyAsync();
    }

    public async Task<bool> MoveExists(string name)
    {
        return await _context.StriveMoves
            .Where(m => m.MoveName == name)
            .AnyAsync();
    }
}
