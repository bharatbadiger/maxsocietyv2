using AutoMapper;
using Maxsociety.DTO;
using Maxsociety.Models;

namespace Maxsociety.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Visitors, VisitorDto>();
            CreateMap<VisitorLogs, VisitorLogDto>();
        }
    }
}

