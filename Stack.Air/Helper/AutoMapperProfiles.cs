using System;
using System.Collections.Generic;
using AutoMapper;
using com.b_velop.Stack.Air.Data.Dtos;
using com.b_velop.Stack.Air.Data.Models;

namespace com.b_velop.Stack.Air.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SensorDataValueDto, Value>()
                .ForMember(dest => dest.MeasureValue, opt => opt.MapFrom(_ => _.Value))
                .ForMember(dest => dest.Sensor, act => act.Ignore())
                .ForMember(dest => dest.SensorId, opt => opt.MapFrom(_ => (long)_.Sensor));

            CreateMap<Value, ValueDto>()
                .ForMember(dest => dest.Name, act => act.MapFrom(_ => _.Sensor.Name));
            CreateMap<Time, TimeDto>();
            CreateMap<Sensor, GetSensorDto>();
            CreateMap<Value, ChartValueDto>()
                .ForMember(dest => dest.Timestamp, act => act.MapFrom(_ => _.Timestamp.Timestamp));
        }
    }
}
