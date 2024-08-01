using Azure.Core;
using CQRSMediatR.Data;
using CQRSMediatR.Models;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly Context _dbContext;

        public GetEmployeeByIdHandler(Context context)
        {
            this._dbContext = context;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            return employee;
        }
    }
}
