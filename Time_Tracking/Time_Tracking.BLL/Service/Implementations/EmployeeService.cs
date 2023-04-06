using AutoMapper;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.DAL.Entities.Exceptions;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Service.Implementations
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(bool trackChanges)
        {
            var employees = await _repository.Employee.GetAllEmployeesAsync(trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return employeesDto;
        }

        public async Task<EmployeeDTO> GetEmployeeAsync(int employeeId, bool trackChanges)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(employeeId, trackChanges);

            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var employeeDto = _mapper.Map<EmployeeDTO>(employee);

            return employeeDto;
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(CreatingEmployeeDTO employee)
        {
            if (employee is null)
                throw new CreatingEmployeeBadRequestException();
            var employeeEntity = _mapper.Map<Employee>(employee);
            await _repository.Employee.CreateEmployeeAsync(employeeEntity);
            await _repository.SaveAsync();
            var employeeToReturn = _mapper.Map<EmployeeDTO>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeAsync(int employeeId, bool trackChanges)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);
            
            await _repository.Employee.DeleteEmployeeAsync(employee);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeProfileAsync(int employeeId, UpdatingEmployeeDTO employeeToUpdate, bool trackChanges)
        {
            if (employeeToUpdate is null)
                throw new UpdatingEmployeeBadRequestException();
            var employee = _repository.Employee.GetEmployeeAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);
            await _mapper.Map(employeeToUpdate, employee);
            await _repository.SaveAsync();
        }
    }
}
