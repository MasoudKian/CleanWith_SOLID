using AutoMapper;
using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Application.DTO.LeaveType;
using Clean.Application.Features.LeaveTypes.Handlers.Queries;
using Clean.Application.Features.LeaveTypes.Requests.Queries;
using Clean.Application.Profiles;
using Clean.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace Clean.Application.UnitTest.LeavTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;

        public GetLeaveTypeListRequestHandlerTests()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListHandlerQuery(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequestQuery(), CancellationToken.None);


            result.ShouldBeOfType<List<LeaveTypeDTO>>();
            result.Count.ShouldBe(2);   


        }


    }
}
