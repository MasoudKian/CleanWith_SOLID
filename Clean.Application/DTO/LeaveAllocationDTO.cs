using Clean.Application.DTO.Common;
using Clean.Domain.Models;

namespace Clean.Application.DTO
{
    public class LeaveAllocationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO LeaveTypeDTO { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
