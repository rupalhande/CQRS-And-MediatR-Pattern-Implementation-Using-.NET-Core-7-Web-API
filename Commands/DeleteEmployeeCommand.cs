using MediatR;

namespace CQRSMediatR.Commands
{
    public class DeleteEmployeeCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
