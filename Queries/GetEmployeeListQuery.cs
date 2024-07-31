using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Queries
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
