using Clean.Application.Contracts.Persistence.EntitiesRepository;
using Clean.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistence.Repositories.EntitiesRepository
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly CleanDbContext _dbContext;

        public LeaveTypeRepository(CleanDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
