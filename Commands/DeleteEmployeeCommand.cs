using MediatR;

namespace CQRSMediatR.Commands
{
    public class DeleteEmployeeCommand: IRequest<int>
    {
        public string Id { get; set; }
    }
}
