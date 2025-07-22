using AutoMapper;
using Clean.Application.Exceptions;
using Clean.Application.Features.LeaveRequests.Requests.Command;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using Clean.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveRequests.Handlers.Command
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand,Unit>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
           IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await leaveRequestRepository.GetEntity(request.LeaveRequestId);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.LeaveRequestId);

            await leaveRequestRepository.DeleteAsync(leaveRequest);
            return Unit.Value;
        }
    }
}
