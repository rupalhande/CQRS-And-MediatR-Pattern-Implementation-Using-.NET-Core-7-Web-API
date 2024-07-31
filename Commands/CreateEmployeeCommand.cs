using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Commands
{
    public class CreateEmployeeCommand:IRequest<Employee>
    {
        public  string EmployeeName { get; set; }
        public  string EmployeeEmail { get; set; }
        public string EmployeeAddress { get; set; }
        public int EmployeeAge { get; set; }

        public CreateEmployeeCommand(string employeeName, string employeeEmail, string employeeAddress, int employeeAge)
        {
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            EmployeeAddress = employeeAddress;
            EmployeeAge = employeeAge;
        }
    }
}
