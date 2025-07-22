using Clean.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.DTO.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto : BaseDTO
    {
        public bool? Approved { get; set; }
    }
}
