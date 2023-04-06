﻿using AutoMapper;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Time_Tracking.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CreatingEmployeeDTO, Employee>();

            CreateMap<UpdatingEmployeeDTO, Employee>();

        }
    }
}
