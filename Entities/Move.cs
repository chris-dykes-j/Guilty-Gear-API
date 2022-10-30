using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

public class Move
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
   
    [Required]
    [MaxLength(50)]
    public string MoveName { get; set; }
   
    [ForeignKey("CharacterId")]
    public Character? Character { get; set; }
    public int CharacterId { get; set; }

    public string Input { get; set; }
    public string Damage { get; set; }
    public string Guard { get; set; }
    public string Startup { get; set; }
    public string Active { get; set; }
    public string Recovery { get; set; }
    public string Block { get; set; }
    public string? Invulnerability { get; set; }
    
    public Move(string moveName)
    {
       MoveName = moveName;
    }
}