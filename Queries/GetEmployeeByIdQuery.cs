using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Queries
{
    public class GetEmployeeByIdQuery:IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
