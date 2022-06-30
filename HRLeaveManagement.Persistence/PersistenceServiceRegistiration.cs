using HRLeaveManagement.Application.Persistence.Contract.Persistence;
using HRLeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));
            services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));

            return services;
        }
    }
}
