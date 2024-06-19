using System.Reflection.PortableExecutable;
using AutoMapper;
using TrainTimings.Api.DTOs.City;
using TrainTimings.Api.DTOs.Timing;
using TrainTimings.Api.DTOs.Train;
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
    }
}