using AutoMapper;
using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Application.DTO.LeaveType;
using Clean.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace Clean.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListHandlerQuery
        : IRequestHandler<GetLeaveTypeListRequestQuery, List<LeaveTypeDTO>>
    {
        #region ctor - DI

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListHandlerQuery(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequestQuery request
            , CancellationToken cancellationToken)
        {
            var leaveTypeList = await _leaveTypeRepository.GetAllEntities();
            var mapModel = _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
            return mapModel;
        }
    }
}
