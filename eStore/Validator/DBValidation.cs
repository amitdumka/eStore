﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eStore.Shared.Models.Payroll;
using eStore.DL.Data;

namespace eStore.Validator
{
    public class DBValidation
    {
        /// <summary>
        /// Check for attendance possible  duplicate entry
        /// </summary>
        /// <param name="db"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public static bool AttendanceDuplicateCheck(eStoreDbContext db, Attendance att)
        {
            var d = db.Attendances.Where(c => c.AttDate == att.AttDate && c.EmployeeId == att.EmployeeId).Select(c => new { c.AttendanceId }).FirstOrDefault();

            if (d != null)
                return true;
            else
                return false;



        }
    }
}
