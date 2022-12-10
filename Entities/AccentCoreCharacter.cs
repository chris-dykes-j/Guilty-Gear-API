using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("plus_r_characters")]
public class AccentCoreCharacter 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("character_name")]
    public string CharacterName { get; set; }
}