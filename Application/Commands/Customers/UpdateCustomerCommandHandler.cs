using CSSMS.Data;
using MediatR;

namespace CSSMS.Application.Commands.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateCustomerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (customer == null)
                return false;

            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Phone = request.Phone;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
