using Clean.Application.DTO.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestsListRequestQueries : IRequest<List<LeaveRequestListDTO>>
    {
    }
}
