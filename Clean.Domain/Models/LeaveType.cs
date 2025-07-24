using Clean.Domain.Common;

namespace Clean.Domain.Models
{
    public class LeaveType : BaseDomainEntity
    {

        public string Name { get; set; } = string.Empty;
        public int DefaultDay { get; set; }

    }
}
