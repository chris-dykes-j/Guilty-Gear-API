using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("strive_characters")]
public class StriveCharacter 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("character_name")]
    public string CharacterName { get; set; }

    [Column("defense")]
    public string Defense { get; set; }
    
    [Column("guts")]
    public string Guts { get; set; }
    
    [Column("pre_jump")]
    public string PreJump { get; set; }
    
    [Column("weight")]
    public string Weight { get; set; }
    
    [Column("back_dash")]
    public string BackDash { get; set; }
    
    [Column("forward_dash")]
    public string ForwardDash { get; set; }
    
    [Column("unique_movement")]
    public string UniqueMovement { get; set; }
    
    [Column("risc_multiplier")]
    public string RiscMultiplier { get; set; }
    
    [Column("movement_tension_gain")]
    public string TensionGain { get; set; }
    
    // public ICollection<Move> MoveList { get; set; } = null!;

    public StriveCharacter(string characterName, string defense, string guts, string preJump, string weight, string backDash, string forwardDash, string uniqueMovement, string riscMultiplier, string tensionGain)
    {
        CharacterName = characterName;
        Defense = defense;
        Guts = guts;
        PreJump = preJump;
        Weight = weight;
        BackDash = backDash;
        ForwardDash = forwardDash;
        UniqueMovement = uniqueMovement;
        RiscMultiplier = riscMultiplier;
        TensionGain = tensionGain;
    }
}

