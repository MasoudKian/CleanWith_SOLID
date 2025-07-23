using Clean.Application.Persistence.Contract;
using Clean.Application.Persistence.Contract.EntitiesRepository;
using Clean.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistence.Repositories.EntitiesRepository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly CleanDbContext _dbContext;

        public LeaveAllocationRepository(CleanDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                .Include(t => t.LeaveType)
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
               .Include(t => t.LeaveType)
               .FirstOrDefaultAsync(l => l.LeaveTypeId == id);
            return leaveAllocation;
        }
    }
}
