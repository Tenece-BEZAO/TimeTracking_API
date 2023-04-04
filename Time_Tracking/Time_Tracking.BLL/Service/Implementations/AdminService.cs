using AutoMapper;

using Time_Tracking.BLL.Repositories;
using Time_Tracking.DAL.Entities.Exceptions;
using Time_Tracking.DAL.Entities;
using Time_Tracking.Shared.DataTransferObjects;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.BLL.LoggerService;

namespace Time_Tracking.BLL.Service.Implementations
{
    internal sealed class AdminService : IAdminService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AdminService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }



    }
}
