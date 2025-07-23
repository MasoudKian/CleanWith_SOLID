using Clean.Application.Contracts.Persistence;
using Clean.Domain.Models;

namespace Clean.Application.Contracts.Persistence.EntitiesRepository
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
