using AutoMapper;
using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Application.DTO.LeaveType;
using Clean.Application.Features.LeaveTypes.Handlers.Command;
using Clean.Application.Features.LeaveTypes.Requests.Command;
using Clean.Application.Profiles;
using Clean.Application.Responses;
using Clean.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace Clean.Application.UnitTest.LeavTypes.Command
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDto _leaveTypeDto;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDay = 15,
                Name = "Test LeaveType DTO"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object,_mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand()
            { CreateLeaveTypeDto = _leaveTypeDto, }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            var leaveType = await _mockRepository.Object.GetAllEntities();

            leaveType.Count.ShouldBe(3);
        }
    }
}
