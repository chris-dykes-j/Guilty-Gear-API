using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StriveAPI.Entities;

[Table("xrd_characters")]
public class XrdCharacter : ICharacter 
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
    
    [Column("risc_gain_rate")]
    public string RiscGain { get; set; }
    
    [Column("wake_up_face_up")]
    public string WakeFaceUp { get; set; }
    
    [Column("wake_up_face_down")]
    public string WakeFaceDown { get; set; }
    
    [Column("unique_movement")]
    public string UniqueMovement { get; set; }
    
    public XrdCharacter(string characterName, string defense, string guts, string preJump, string weight, string backDash, string forwardDash, string uniqueMovement, string riscMultiplier, string tensionGain, string riscGain, string wakeFaceUp, string wakeFaceDown)
    {
        CharacterName = characterName;
        Defense = defense;
        Guts = guts;
        PreJump = preJump;
        Weight = weight;
        BackDash = backDash;
        ForwardDash = forwardDash;
        RiscGain = riscGain;
        WakeFaceUp = wakeFaceUp;
        WakeFaceDown = wakeFaceDown;
        UniqueMovement = uniqueMovement;
    }
}

