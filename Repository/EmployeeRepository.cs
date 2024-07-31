using CQRSMediatR.Data;
using CQRSMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _dbContext;

        public EmployeeRepository(Context dbContex) 
        {
            this._dbContext = dbContex;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employeeDetails)
        {
            var result = _dbContext.Employees.Add(employeeDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            var filteredData = _dbContext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            if(filteredData != null)
            {
                _dbContext.Employees.Remove(filteredData);
                return await _dbContext.SaveChangesAsync(); ;
            }
            return 0;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int Id)
        {
            return await _dbContext.Employees.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<int> UpdateEmployeeAsync(Employee employeeDetails)
        {
            _dbContext.Employees.Update(employeeDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
