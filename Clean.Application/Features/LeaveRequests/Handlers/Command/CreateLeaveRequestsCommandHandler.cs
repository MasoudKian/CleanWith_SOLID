using AutoMapper;
using Clean.Application.Contracts.Infrastructure;
using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Application.DTO.LeaveRequest.Validators;
using Clean.Application.Features.LeaveRequests.Requests.Command;
using Clean.Application.Models;
using Clean.Application.Responses;
using Clean.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<CreateLeaveRequestsCommandHandler> _logger;

        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender, ILogger<CreateLeaveRequestsCommandHandler> logger)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestsDTO);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var leaveRequest = mapper.Map<LeaveRequest>(request.CreateLeaveRequestsDTO);
            leaveRequest = await leaveRequestRepository.CreateAsync(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successfully";
            response.Id = leaveRequest.Id;

            // It should be implemented better here.
            var email = new Email
            {
                To = "masoudkiannezhad@.com",
                Subject = "Leave Request Submitted",
                Body = $"Your leave request for {request.CreateLeaveRequestsDTO.StartDate} " +
                $"to {request.CreateLeaveRequestsDTO.EndDate} " +
                $"has been submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //log
                _logger.LogError($"In create leave request is {ex.Message}");
            }

            return response;
        }
    }
}
