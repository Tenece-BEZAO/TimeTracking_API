﻿using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities.Exceptions;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Implementations
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Time_Tracking_DbContext time_Tracking_DbContext)
        : base(time_Tracking_DbContext)
        { }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
        .OrderBy(c => c.FullName)
        .ToListAsync();


        public async Task<IEnumerable<Employee>> GetEmployeesByIdsAsync(IEnumerable<int> employeeIds, bool trackChanges) =>
            await FindByCondition(x => employeeIds.Contains(x.Id), trackChanges)
            .ToListAsync();

        public async Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges)
        {
            var employee = await FindByCondition(c => c.Id.Equals(employeeId), trackChanges)
                   .SingleOrDefaultAsync();
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);
            return employee;
        }

        public async Task CreateEmployeeAsync(Employee employee) => Create(employee);
    }
}
