using AutoMapper;
using Clean.Application.DTO.LeaveRequest;
using Clean.Application.Features.LeaveRequests.Requests.Queries;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using MediatR;

namespace Clean.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandlerQueries
        : IRequestHandler<GetLeaveRequestsListRequestQueries, List<LeaveRequestListDTO>>
    {
        #region ctor - DI

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandlerQueries(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestsListRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveRequestList = await _leaveRequestRepository.GetAllEntities();
            return _mapper.Map<List<LeaveRequestListDTO>>(leaveRequestList);
        }
    }
}
