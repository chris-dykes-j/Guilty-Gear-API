namespace StriveAPI.Models;

public class MoveDto
{
    public int MoveId { get; set; }
    public int CharacterId { get; set; }
    public string MoveName { get; set; } = string.Empty;
    public string? Input { get; set; }
    public string? Damage { get; set; }
    public string? Guard { get; set; }
    public string? Startup { get; set; }
    public string? Active { get; set; }
    public string? Recovery { get; set; }
    public string? Block { get; set; }
    public string? Invulnerability { get; set; }
}
