using AutoMapper;
using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Application.UnitTest.Mocks;
using Moq;

namespace Clean.Application.UnitTest.LeavTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;

        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();


        }


    }
}
