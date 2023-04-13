using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) => _service = service;

        
    }
}
