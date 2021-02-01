﻿using System;
using System.Collections.Generic;
using eStore.Shared.Models.Payroll;

namespace eStore.Shared.ViewModels.Payroll
{
    /// <summary>
    /// Move to Model Section
    /// </summary>
    public class EmployeeAttendaceInfo
    {
        public int EmpId { get; set; }
        public string StaffName { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; } // a;
        public int WorkingDays { get; set; } // noofdays;
        public int Sundays { get; set; } // noofsunday;
        public int SundayPresent { get; set; } // sunPresent;
        public int HalfDays { get; set; } // halfDays;
        public int Total { get; set; } // totalAtt;
        public List<Attendance> Attendances { get; set; }
    }
}
