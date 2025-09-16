using AutoMapper;
using INDWalks.API.Model.Domain;
using INDWalks.API.Model.DTO;

namespace INDWalks.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Regions,RegionDto>().ReverseMap();
            CreateMap<Regions,UpdateRegionDto>().ReverseMap(); 
            CreateMap<Regions,AddRegionsDto>().ReverseMap();
            CreateMap<Walks,WalksDto>().ReverseMap();
            CreateMap<Walks,AddWalksDto>().ReverseMap();
            CreateMap<Walks,UpdateWalkDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
        }
    }
}
