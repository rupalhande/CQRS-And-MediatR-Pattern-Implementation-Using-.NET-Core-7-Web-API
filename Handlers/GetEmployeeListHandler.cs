using CQRSMediatR.Data;
using CQRSMediatR.Models;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly Context _dbContext;

        public GetEmployeeListHandler(Context dbContex)
        {
            this._dbContext = dbContex;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Employees.ToListAsync(cancellationToken);
        }
    }
}
