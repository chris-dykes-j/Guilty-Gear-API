using AutoMapper;

namespace StriveAPI.Profiles;

public class StriveMoveProfile : Profile
{
    public StriveMoveProfile()
    {
        CreateMap<Entities.StriveMove, Models.StriveMoveDto>();
        CreateMap<Entities.StriveMove, Models.StriveMoveCharacterNameDto>();
    }
}