using AutoMapper;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.MappingProfile;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
    }
}