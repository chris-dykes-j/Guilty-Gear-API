using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("plus_r_move_list")]
public class AccentCoreMove 
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
}