using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocations;
using HRLeaveManagement.Application.DTOs.LeaveRequests;
using HRLeaveManagement.Application.DTOs.LeaveTypes;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest Mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveTypeRequestDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
