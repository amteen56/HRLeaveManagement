using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext dbContext;
        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetails()
        {
            var leaveRequest = await dbContext.leaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
        {
            var leaveRequest = await dbContext.leaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == Id);

            return leaveRequest;
        }
    }
}
