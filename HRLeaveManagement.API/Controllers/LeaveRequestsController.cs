using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    { 
      private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveRequestsController>
    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestListDto>>> Get(bool isLoggedInUser = false)
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestListWithDetailsRequest());
        return Ok(leaveRequests);
    }

    // GET api/<LeaveRequestsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestWithDetailsRequest { Id = id });
        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestsController>
    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var command = new CreateLeaverRquestCommandRequest { createLeaveRequestDto = leaveRequest };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }

    // PUT api/<LeaveRequestsController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequest)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = leaveRequest };
        await _mediator.Send(command);
        return NoContent();
    }

    // PUT api/<LeaveRequestsController>/changeapproval/5
    [HttpPut("changeapproval/{id}")]
    public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApproval)
    {
        var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeLeaveRequestApproval };
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE api/<LeaveRequestsController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveRequestCommandRequest { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
}