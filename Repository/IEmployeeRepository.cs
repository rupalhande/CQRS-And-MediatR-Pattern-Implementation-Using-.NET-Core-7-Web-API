using CQRSMediatR.Models;

namespace CQRSMediatR.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeeListAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int Id);
        public Task<Employee> AddEmployeeAsync(Employee employeeDetails);
        public Task<int> UpdateEmployeeAsync(Employee employeeDetails);
        public Task<int> DeleteEmployeeAsync(int Id);
    }
}
