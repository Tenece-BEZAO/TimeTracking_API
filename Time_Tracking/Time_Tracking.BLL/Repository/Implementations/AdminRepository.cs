using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;

namespace Time_Tracking.BLL.Repository.Implementations
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(Time_Tracking_DbContext time_Tracking_DbContext)
        : base(time_Tracking_DbContext)
        { }
    }
}
