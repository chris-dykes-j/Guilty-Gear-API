using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

public class Character 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string CharacterName { get; set; }

    public ICollection<Move> Moves { get; set; }
        = new List<Move>();
    
    public Character(string characterName)
    {
        CharacterName = characterName;
    }
}

