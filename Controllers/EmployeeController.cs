using CQRSMediatR.Commands;
using CQRSMediatR.Models;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            var list = await mediator.Send(new GetEmployeeListQuery());

            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(string id)
        {
            var query = new GetEmployeeByIdQuery() { Id=id};
            return await mediator.Send(query);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostAsync([FromBody] CreateEmployeeCommand  value)
        {
            return await mediator.Send(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] CreateEmployeeCommand value)
        {
            var command = new UpdateEmployeeCommand(id, value.EmployeeName, value.EmployeeEmail, value.EmployeeAddress, value.EmployeeAge);
            return await mediator.Send(command)? Ok() : NotFound();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var command=new DeleteEmployeeCommand() { Id=id};
            return await mediator.Send(command)>0?Ok():NotFound();
        }
    }
}
