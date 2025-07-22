using AutoMapper;
using Clean.Application.DTO.LeaveType;
using Clean.Application.Features.LeaveTypes.Requests.Queries;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailHandlerQuery
        : IRequestHandler<GetLeaveTypeDetailRequestQuery, LeaveTypeDTO>
    {

        #region ctor - DI

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailHandlerQuery(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequestQuery request
            , CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetEntity(request.LeaveTypeId);
            if (leaveType == null) throw new Exception($" Leave Type : {leaveType} is null ... ");

            var mapModel = _mapper.Map<LeaveTypeDTO>(leaveType);
            return mapModel;
        }
    }
}
