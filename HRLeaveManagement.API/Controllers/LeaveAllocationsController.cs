using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        //Get: leaveAllocations
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await this._mediator.Send(new GetLeaveAllocationListWithDetailsRequest());
            return Ok(leaveAllocations);
        }
        // GET api/<leaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationWithDetailsRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<leaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommandRequest { createLeaveAllocationDto = leaveAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<leaveAllocationsController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommandRequest { leaveAllocationDto = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<leaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommandRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
