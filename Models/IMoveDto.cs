namespace StriveAPI.Models;

public interface IMoveDto
{
    public int Id { get; set; }
    public string MoveName { get; set; }
    public string Input { get; set; }
}