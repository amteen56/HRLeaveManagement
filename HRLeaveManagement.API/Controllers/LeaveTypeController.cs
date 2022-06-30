using HRLeaveManagement.Application.DTOs.LeaveTypes;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        //Get: LeaveTypes
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await this._mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }
        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailsRequest { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommandRequest { createLeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveTypeRequestDto leaveType)
        {
            var command = new UpdateLeaveTypeCommandRequest { leaveTypeRequestDto = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommandRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
