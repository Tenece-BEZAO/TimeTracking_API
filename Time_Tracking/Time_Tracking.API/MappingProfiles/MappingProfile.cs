using AutoMapper;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.API.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDTO>();

        CreateMap<CreatingEmployeeDto, Employee>();

        CreateMap<UpdatingEmployeeDTO, Employee>();

        CreateMap<Attendance, AttendanceDTO>();

        CreateMap<Todo, TodoDTO>();

    }
}