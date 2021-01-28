﻿using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using eStore.Shared.Models.Stores;

namespace eStore.Shared.Models.Payroll
{
    /// <summary>
    /// @Version: 5.0
    /// </summary>

    public class Employee : BaseST
    {
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last    Name")]
        public string LastName { get; set; }

        [Display(Name = "Employee Name")]
        public string StaffName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Mobile No"), Phone]
        public string MobileNo { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leaving Date")]
        public DateTime? LeavingDate { get; set; }

        [Display(Name = "Working")]
        public bool IsWorking { get; set; }

        [Display(Name = "Job Category")]
        [DefaultValue(0)]
        public EmpType Category { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Tailoring Division")]
        public bool IsTailors { get; set; }

        [Display(Name = "eMail"), EmailAddress]
        public string EMail { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string AdharNumber { get; set; }
        public string PanNo { get; set; }
        public string OtherIdDetails { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FatherName { get; set; }
        public string HighestQualification { get; set; }

        // public ICollection<SalaryPayment> SalaryPayments { get; set; }
        // public ICollection<StaffAdvancePayment> AdvancePayments { get; set; }
        // public ICollection<StaffAdvanceReceipt> AdvanceReceipts { get; set; }
        // public ICollection<PettyCashExpense> CashExpenses { get; set; }
        // public ICollection<Expense> Expenses { get; set; }
        //public virtual ICollection<CurrentSalary> CurrentSalaries { get; set; }

        public ICollection<Salesman> Salesmen { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public virtual EmployeeUser User { get; set; }

    }
    /// <summary>
    /// Employee User
    /// </summary>
    public class EmployeeUser
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public bool IsWorking { get; set; }
    }
}
