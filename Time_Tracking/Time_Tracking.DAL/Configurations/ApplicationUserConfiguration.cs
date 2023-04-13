using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.DAL.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser { Id = "1", UserName = "john.doe", FirstName = "John", LastName = "Doe" },
                new ApplicationUser { Id = "2", UserName = "jane.doe", FirstName = "Jane", LastName = "Doe" },
                new ApplicationUser { Id = "3", UserName = "kendrick.chukwuka", FirstName = "kendrick", LastName = "chukwuka" }
            );
        }
    }

}
