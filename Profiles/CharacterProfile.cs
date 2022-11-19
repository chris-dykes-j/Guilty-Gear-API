using AutoMapper;

namespace StriveAPI.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Entities.StriveCharacter, Models.CharacterDto>();
        CreateMap<Entities.StriveCharacter, Models.CharacterNoMovesDto>();
    }
}