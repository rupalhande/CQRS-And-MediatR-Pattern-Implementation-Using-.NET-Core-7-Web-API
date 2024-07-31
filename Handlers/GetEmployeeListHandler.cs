using CQRSMediatR.Models;
using CQRSMediatR.Queries;
using CQRSMediatR.Repository;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeListHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeListAsync();
        }
    }
}
