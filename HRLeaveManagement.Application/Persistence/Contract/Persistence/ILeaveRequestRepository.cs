using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistence.Contract.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int Id);
        Task<List<LeaveRequest>> GetLeaveRequestListWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
