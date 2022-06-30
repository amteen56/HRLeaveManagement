using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Persistence.Contract.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails();
    }
}
