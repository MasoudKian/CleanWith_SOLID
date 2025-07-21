using AutoMapper;
using Clean.Application.DTO.LeaveAllocation;
using Clean.Application.DTO.LeaveRequest;
using Clean.Application.DTO.LeaveType;
using Clean.Domain.Models;

namespace Clean.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // LeaveRequestList
            CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveRequest,LeaveRequestListDTO>().ReverseMap();


            CreateMap<LeaveType,LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();
        }
    }
}
