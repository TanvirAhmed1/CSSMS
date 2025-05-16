using MediatR;

namespace CSSMS.Application.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
    }
}
