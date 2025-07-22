using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.DTO.LeaveType
{
    public class CreateLeaveTypeDto : ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
