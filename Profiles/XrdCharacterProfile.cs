using AutoMapper;

namespace StriveAPI.Profiles;

public class XrdCharacterProfile : Profile
{
    public XrdCharacterProfile()
    {
        CreateMap<Entities.XrdCharacter, Models.XrdCharacterDto>();
    }
}