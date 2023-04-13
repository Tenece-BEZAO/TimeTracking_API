using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.DAL.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration <Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasData(
            new Admin
            {
                Id = 1,
                FullName = "Alex Doe",
                PhoneNumber = "0810-000-5678",
                Email = "a.doe@domain.com",
                Password = "12345"
            }
        );
    }
}