


namespace CheatSheets.Mapping
{
    using AutoMapper;
    using Models;
    using System;
    using DTO;
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Job, JobDto>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.JobName));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmployeeAge, opt => opt.MapFrom(src => (DateTime.Now - src.DateOfBirth).Days/365));
        }
    }
}
