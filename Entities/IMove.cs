namespace StriveAPI.Entities;

public interface IMove
{
   public int Id { get; set; }
   public string MoveName { get; set; }
   public int CharacterId { get; set; }
}