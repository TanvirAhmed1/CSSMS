using CSSMS.Application.Commands.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CSSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return Ok(new { CustomerId = customerId });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id) return BadRequest("Mismatched Customer ID");
            var result = await _mediator.Send(command);
            return result ? Ok("Customer updated.") : NotFound("Customer not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand { Id = id });
            return result ? Ok("Customer deleted.") : NotFound("Customer not found.");
        }
    }
}
