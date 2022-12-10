using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("strive_move_list")]
public class StriveMove 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
   
    [Required]
    [Column("move_name")]
    public string MoveName { get; set; }
   
    [ForeignKey("Character")]
    [Column("character_id")]
    public int CharacterId { get; set; }

    [Column("input")]
    [MaxLength(50)]
    public string Input { get; set; }
    [Column("damage")]
    [MaxLength(50)]
    public string Damage { get; set; }
    
    [Column("guard")]
    [MaxLength(50)]
    public string Guard { get; set; }
    
    [Column("startup")]
    [MaxLength(50)]
    public string Startup { get; set; }
    
    [Column("active")]
    [MaxLength(50)]
    public string Active { get; set; }
    
    [Column("recovery_frames")]
    [MaxLength(50)]
    public string Recovery { get; set; }
    
    [Column("on_block")]
    [MaxLength(50)]
    public string Block { get; set; }
    
    [Column("invulnerability")]
    [MaxLength(50)]
    public string? Invulnerability { get; set; }
    
    public StriveMove(string moveName, string input, string damage, string guard, string startup, string active,
        string recovery, string block, string? invulnerability)
    {
        MoveName = moveName;
        Input = input;
        Damage = damage;
        Guard = guard;
        Startup = startup;
        Active = active;
        Recovery = recovery;
        Block = block;
        Invulnerability = invulnerability;
    }
}