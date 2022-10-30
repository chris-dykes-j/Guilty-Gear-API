using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("characters")]
public class Character 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("character_id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("character_name")]
    public string CharacterName { get; set; }

    public ICollection<Move> Moves { get; set; }
        = new List<Move>();
    
    public Character(string characterName)
    {
        CharacterName = characterName;
    }
}

