using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveTypes.Requests.Command
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public int LeaveTypeId { get; set; }
    }
}
