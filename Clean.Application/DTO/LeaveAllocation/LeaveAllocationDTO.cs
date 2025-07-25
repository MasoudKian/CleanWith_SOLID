﻿using Clean.Application.DTO.Common;
using Clean.Application.DTO.LeaveType;
using Clean.Domain.Models;

namespace Clean.Application.DTO.LeaveAllocation
{
    public class LeaveAllocationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDTO? LeaveTypeDTO { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
