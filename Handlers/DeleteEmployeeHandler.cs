using Azure.Core;
using CQRSMediatR.Commands;
using CQRSMediatR.Data;
using CQRSMediatR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly Context _dbContext;

        public DeleteEmployeeHandler(Context dbContex)
        {
            this._dbContext = dbContex;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //return await _dbContext.Employees
            //    .Where(x => x.Id == request.Id)
            //    .ExecuteDeleteAsync(cancellationToken);

            var employee = await _dbContext.Employees
                  .Where(x => x.Id == request.Id)
                  .FirstOrDefaultAsync(cancellationToken);
            if (employee == null)
            {
                return 0;
            }
            _dbContext.Employees.Remove(employee);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
