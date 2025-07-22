using AutoMapper;
using Clean.Application.DTO.LeaveRequest.Validators;
using Clean.Application.Exceptions;
using Clean.Application.Features.LeaveRequests.Requests.Command;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveRequests.Handlers.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationExceptions(validationResult);

            var leaveRequest = await leaveRequestRepository.GetEntity(request.Id);
            if (request.UpdateLeaveRequestDto != null)
            {

                mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
                await leaveRequestRepository.UpdateEntityAsync(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovealDto != null)
            {
                await leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovealDto.Approved);
            }

            return Unit.Value;
        }
    }
}
