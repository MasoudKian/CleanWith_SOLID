using Clean.Application.DTO.Common;

namespace Clean.Application.DTO
{
    public class LeaveTypeDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDay { get; set; }
    }
}
