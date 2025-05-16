using MediatR;

namespace CSSMS.Application.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
