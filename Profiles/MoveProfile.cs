using AutoMapper;

namespace StriveAPI.Profiles;

public class MoveProfile : Profile
{
    public MoveProfile()
    {
        CreateMap<Entities.StriveMove, Models.StriveMoveDto>();
        CreateMap<Entities.StriveMove, Models.StriveMoveNoDataDto>();
        CreateMap<Entities.StriveMove, Models.StriveMoveCharacterNameDto>();
    }
}