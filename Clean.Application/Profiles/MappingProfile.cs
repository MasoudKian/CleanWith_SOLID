using AutoMapper;
using Clean.Application.DTO;
using Clean.Domain.Models;

namespace Clean.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest,LeaveRequestDTO>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDTO>().ReverseMap();
        }
    }
}
