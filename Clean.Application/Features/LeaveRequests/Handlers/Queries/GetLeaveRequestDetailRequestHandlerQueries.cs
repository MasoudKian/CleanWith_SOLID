using AutoMapper;
using Clean.Application.DTO.LeaveRequest;
using Clean.Application.Features.LeaveRequests.Requests.Queries;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using MediatR;

namespace Clean.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandlerQueries
        : IRequestHandler<GetLeaveRequestDetailRequestQueries, LeaveRequestDTO>
    {
        #region ctor - DI

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandlerQueries(ILeaveRequestRepository leaveRequestRepository
            , IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequestQueries request
            , CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository
                .GetLeaveRequestWithDetails(request.LeaveRequestId);
            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
