using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Domain.Models;
using Moq;

namespace Clean.Application.UnitTest.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>()
            {
                new LeaveType
                {
                Id = 1,
                DefaultDay = 10,
                Name = "Test Vacation"
                },
                new LeaveType
                {
                Id = 2,
                DefaultDay = 15,
                Name = "Test Sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(r => r.GetAllEntities()).ReturnsAsync(leaveTypes);
                                            // Controlling method input that does not have a different type
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
                .ReturnsAsync((LeaveType leavetype) =>
                {
                    leaveTypes.Add(leavetype);
                    return leavetype;
                });


            return mockRepo;
        }
    }
}
