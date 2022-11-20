using AutoMapper;

namespace StriveAPI.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Entities.StriveCharacter, Models.StriveCharacterDto>();
        CreateMap<Entities.StriveCharacter, Models.StriveCharacterNoMovesDto>();
    }
}