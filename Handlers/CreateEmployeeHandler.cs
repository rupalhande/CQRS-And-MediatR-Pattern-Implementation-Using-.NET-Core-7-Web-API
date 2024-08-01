using CQRSMediatR.Commands;
using CQRSMediatR.Data;
using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly Context _dbContext;

        public CreateEmployeeHandler(Context context)
        {
            this._dbContext = context;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee() { 
                Id= Guid.NewGuid().ToString(),
                EmployeeName = request.EmployeeName,
                EmployeeEmail = request.EmployeeEmail,
                EmployeeAge = request.EmployeeAge,
                EmployeeAddress = request.EmployeeAddress

            };
            var result = await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }
    }
}
