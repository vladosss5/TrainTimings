using System.Reflection.PortableExecutable;
using AutoMapper;
using TrainTimings.Api.DTOs.City;
using TrainTimings.Api.DTOs.Timing;
using TrainTimings.Api.DTOs.Train;
using TrainTimings.Api.DTOs.TypeFollowing;
using TrainTimings.Api.DTOs.TypeTrain;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCityDto, City>().ReverseMap();
        CreateMap<UpdateCityDto, City>().ReverseMap();
        
        CreateMap<CreateTimingDto, Timing>().ReverseMap();
        CreateMap<UpdateTimingDto, Timing>().ReverseMap();

        CreateMap<CreateTrainDto, Train>().ReverseMap();
        CreateMap<UpdateTimingDto, Train>().ReverseMap();

        CreateMap<CreateTypeFollowingDto, TypesFollowing>().ReverseMap();
        CreateMap<UpdateTypeFollowingDto, TypesFollowing>().ReverseMap();
        
        CreateMap<CreateTypeTrainDto, TypeTrain>().ReverseMap();
        CreateMap<UpdateTypeTrainDto, TypeTrain>().ReverseMap();
    }
}