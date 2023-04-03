using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Enums;
using Priority = Time_Tracking.DAL.Enums.Priority;

namespace Time_Tracking.BLL.MappingProfile
{
    public class TodoMappingProfile : Profile
    {

        public TodoMappingProfile()
        {
            CreateMap<Todo, TodoDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToLocalTime()))
                
                .ReverseMap();
            CreateMap<State, TodoStateDTO>()
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));

            CreateMap<Priority, PriorityDTO>()
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ToString()));




            CreateMap<Employee, EmployeeDTO>()
                    .ReverseMap();

          
                



        }
    }
}
