using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        //constructor
        public AutoMapperProfiles()
        {
            //maapings [source and destination]
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRequestRegionDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Walk>().ReverseMap();
        }
    }
}
