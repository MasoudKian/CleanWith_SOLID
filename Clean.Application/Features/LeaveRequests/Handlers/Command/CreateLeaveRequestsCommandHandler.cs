using Clean.Application.Features.LeaveRequests.Requests.Command;
using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveRequests.Handlers.Command
{
    public class CreateLeaveRequestsCommandHandler
    : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponse>
    {
        public Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request
            , CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
