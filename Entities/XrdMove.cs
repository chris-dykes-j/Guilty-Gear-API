namespace StriveAPI.Entities;

public class XrdMove : IMove
{
    public int Id { get; set; }
    public string MoveName { get; set; }
    public int CharacterId { get; set; }

    public XrdMove(string moveName)
    {
        MoveName = moveName;
    }
}