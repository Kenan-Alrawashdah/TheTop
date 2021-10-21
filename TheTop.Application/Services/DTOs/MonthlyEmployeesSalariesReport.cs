﻿using System;
using System.Collections.Generic;

namespace TheTop.Application.Services.DTOs
{
    public class MonthlyEmployeesSalariesReportDTO 
    {
        public ICollection<EmployeeSalaryDTO> Employees { get; set; }
        public decimal TotalSalaries { get; set; }
        public int TotalWorkingHours { get; set;  }

        public int Month { get; set; }

        public DateTime DateTie { get; set; }
    }
}
