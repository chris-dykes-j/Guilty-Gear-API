using StriveAPI.Entities;

namespace StriveAPI.Models;

public class XrdMoveDto : IMove
{
    public int Id { get; set; }
    public string MoveName { get; set; }
    public int CharacterId { get; set; }
}