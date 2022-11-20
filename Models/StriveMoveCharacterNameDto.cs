namespace StriveAPI.Models;

public class StriveMoveCharacterNameDto
{
    public int Id { get; set; }
    public string CharacterName { get; set; } = null!;
    public string MoveName { get; set; } = string.Empty;
    public string Input { get; set; } = string.Empty;
    public string Damage { get; set; } = string.Empty;
    public string Guard { get; set; } = string.Empty;
    public string Startup { get; set; } = string.Empty;
    public string Active { get; set; } = string.Empty;
    public string Recovery { get; set; } = string.Empty;
    public string Block { get; set; } = string.Empty;
    public string? Invulnerability { get; set; } = string.Empty;
}