using AutoMapper;

namespace StriveAPI.Profiles;

public class XrdMoveProfile : Profile
{
    public XrdMoveProfile()
    {
        CreateMap<Entities.XrdMove, Models.XrdMoveDto>();
    }
}