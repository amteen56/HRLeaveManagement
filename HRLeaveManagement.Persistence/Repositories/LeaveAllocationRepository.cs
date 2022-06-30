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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails()
        {
            var leaveAllocations = await dbContext.leaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = await dbContext.leaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == Id);

            return leaveAllocation;
        }
    }
}
