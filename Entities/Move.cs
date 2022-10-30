using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("move_list")]
public class Move
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("move_id")]
    public int Id { get; set; }
   
    [Required]
    [MaxLength(50)]
    [Column("move_name")]
    public string MoveName { get; set; }
   
    [ForeignKey("CharacterId")]
    [Column("character_id")]
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