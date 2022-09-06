using AutoMapper;
using CQRSapi_2.BusinessLayer.CQRS.Commands;
using CQRSapi_2.BusinessLayer.Dtos;
using CQRSapi_2.EntityLayer.Entities;

namespace CQRSapi_2.BusinessLayer.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
