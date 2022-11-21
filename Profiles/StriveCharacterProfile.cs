using AutoMapper;

namespace StriveAPI.Profiles;

public class StriveCharacterProfile : Profile
{
    public StriveCharacterProfile()
    {
        CreateMap<Entities.StriveCharacter, Models.StriveCharacterDto>();
    }
}