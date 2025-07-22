using AutoMapper;
using Clean.Application.DTO.LeaveAllocation.Validators;
using Clean.Application.Exceptions;
using Clean.Application.Features.LeaveAllocations.Requests.Command;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using Clean.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.LeaveAllocations.Handlers.Command
{
    public class CreateLeaveAllocationsCommandHandler
            : IRequestHandler<CreateLeaveAllocationsCommand, int>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationsCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveAllocationsCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationExceptions(validationResult);


            var leaveAllocations = mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
            leaveAllocations = await leaveAllocationRepository.CreateAsync(leaveAllocations);
            return leaveAllocations.LeaveTypeId;
        }
    }
}
