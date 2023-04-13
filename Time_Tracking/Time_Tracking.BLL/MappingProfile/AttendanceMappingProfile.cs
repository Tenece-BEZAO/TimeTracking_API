using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.MappingProfile
{
    public class AttendanceMappingProfile:Profile
    {
        public AttendanceMappingProfile()
        {
            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<AttendanceDTO, Attendance>();
   
        }
    }
}
