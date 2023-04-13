﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities;

namespace Time_Tracking.BLL.MappingProfile
{
    public class EmployeeMappingProfile: Profile
    {
       
          

        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
                     
        
    }
}
