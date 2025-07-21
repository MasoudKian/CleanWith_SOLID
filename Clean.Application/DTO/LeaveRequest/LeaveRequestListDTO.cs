using Clean.Application.DTO.Common;
using Clean.Application.DTO.LeaveType;

namespace Clean.Application.DTO.LeaveRequest
{
    public class LeaveRequestListDTO : BaseDTO
    {
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
