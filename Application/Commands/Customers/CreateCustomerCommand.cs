using MediatR;

namespace CSSMS.Application.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
