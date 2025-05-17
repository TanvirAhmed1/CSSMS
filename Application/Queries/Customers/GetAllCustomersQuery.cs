using CSSMS.Application.DTOs;
using MediatR;

namespace CSSMS.Application.Queries.Customers
{
    public record GetAllCustomersQuery() : IRequest<List<CustomerDto>>;
}
