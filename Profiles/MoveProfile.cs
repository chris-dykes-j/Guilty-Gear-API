using AutoMapper;

namespace StriveAPI.Profiles;

public class MoveProfile : Profile
{
    public MoveProfile()
    {
        CreateMap<Entities.Move, Models.MoveDto>();
        CreateMap<Entities.Move, Models.MoveNoDataDto>();
        CreateMap<Entities.Move, Models.MoveWithCharacterNameDto>();
    }
}