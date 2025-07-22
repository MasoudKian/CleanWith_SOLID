using Clean.Application.DTO.Common;

namespace Clean.Application.DTO.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDTO, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; } = string.Empty;
        public bool Cancelled { get; set; }
    }
}
