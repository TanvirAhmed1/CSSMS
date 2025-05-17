using CSSMS.Application.DTOs;
using Dapper;
using MediatR;
using System.Data;

namespace CSSMS.Application.Queries.Customers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly IDbConnection _dbConnection;

        public GetAllCustomersQueryHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var sql = "SELECT Id, Name, Email, Phone FROM Customers";
            var customers = await _dbConnection.QueryAsync<CustomerDto>(sql);
            return customers.ToList();
        }
    }
}
