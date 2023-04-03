﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
