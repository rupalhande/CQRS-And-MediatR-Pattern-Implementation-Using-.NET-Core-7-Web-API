using CQRSMediatR.Commands;
using CQRSMediatR.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly Context _dbContext;

        public UpdateEmployeeHandler(Context dbContex)
        {
            this._dbContext = dbContex;
        }
        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //await _dbContext.Employees
            //    .Where(x => x.Id == request.Id)
            //    .ExecuteUpdateAsync(e => e
            //    .SetProperty(e => e.EmployeeName, request.EmployeeName)
            //    .SetProperty(e => e.EmployeeEmail, request.EmployeeEmail)
            //    .SetProperty(e => e.EmployeeAddress, request.EmployeeAddress)
            //    .SetProperty(e => e.EmployeeAge, request.EmployeeAge),
            //    cancellationToken
            //    );

            var employee= await _dbContext.Employees
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if(employee == null) { return false; }

            employee.EmployeeName = request.EmployeeName;
            employee.EmployeeEmail = request.EmployeeEmail;
            employee.EmployeeAddress = request.EmployeeAddress;
            employee.EmployeeAge = request.EmployeeAge;

            _dbContext.Employees.Update(employee);

            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
