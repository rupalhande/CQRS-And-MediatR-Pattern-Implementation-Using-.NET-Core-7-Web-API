using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Commands
{
    public class UpdateEmployeeCommand:IRequest<bool>
    {
        public string Id { get; set; }
        public  string EmployeeName { get; set; }
        public  string EmployeeEmail { get; set; }
        public string EmployeeAddress { get; set; }
        public int EmployeeAge { get; set; }

        public UpdateEmployeeCommand(string id, string employeeName, string employeeEmail, string employeeAddress, int employeeAge)
        {
            Id = id;
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            EmployeeAddress = employeeAddress;
            EmployeeAge = employeeAge;
        }
    }
}
