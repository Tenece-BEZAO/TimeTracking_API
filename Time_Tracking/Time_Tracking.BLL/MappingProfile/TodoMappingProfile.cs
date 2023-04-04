using AutoMapper;
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


            //new additions

            CreateMap<TodoStateDTO, State>()
                  .ConvertUsing(src => Enum.Parse<State>(src.Name));
            CreateMap<TodoDTO, Todo>()
              .ForMember(dest => dest.State, opt => opt.MapFrom(src => Enum.Parse<State>(src.State.Name)));
            CreateMap<PriorityDTO, Priority>().ConvertUsing<PriorityConverter>();

        }

        public class PriorityConverter : ITypeConverter<PriorityDTO, Priority>
        {
            public Priority Convert(PriorityDTO source, Priority destination, ResolutionContext context)
            {
                if (Enum.TryParse(source.Name, out Priority result))
                {
                    return result;
                }
                throw new ArgumentException("Invalid Priority value");
            }
        }





    }
}
