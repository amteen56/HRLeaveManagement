using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
