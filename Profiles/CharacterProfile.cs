using AutoMapper;

namespace StriveAPI.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Entities.Character, Models.CharacterDto>();
        CreateMap<Entities.Character, Models.CharacterNoMovesDto>();
    }
}