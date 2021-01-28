using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eStore.Shared.Models.Payroll
{
    /// <summary>
    /// @Version: 5.0
    /// </summary>
    public class SalaryPayment : BaseST
    {
        public int SalaryPaymentId { get; set; }

        [Display(Name = "Staff Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Salary/Year")]
        public string SalaryMonth { get; set; }

        [Display(Name = "Payment Reason")]
        public SalaryComponet SalaryComponet { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }

        public string Details { get; set; }
    }

    public class StaffAdvanceReceipt : BaseST
    {
        public int StaffAdvanceReceiptId { get; set; }

        [Display(Name = "Staff Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Receipt Date")]
        public DateTime ReceiptDate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }
        public string Details { get; set; }

        [Display(Name = "Party")]
        public int? PartyId { get; set; }
    }

    /// <summary>
    /// @Version: 5.0
    /// </summary>
    //TODO: convert to implement tailioring division also
    public class PaySlip : BaseNT
    {
        public int PaySlipId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int? CurrentSalaryId { get; set; }
        public virtual CurrentSalary CurrentSalary { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }

        public int NoOfDaysPresent { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalSale { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal SaleIncentive { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal WOWBillAmount { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal WOWBillIncentive { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal LastPcsAmount { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal LastPCsIncentive { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal OthersIncentive { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal GrossSalary { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal StandardDeductions { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TDSDeductions { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal PFDeductions { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal AdvanceDeducations { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal OtherDeductions { get; set; }

        public string Remarks { get; set; }

        public bool? IsTailoring { get; set; }
    }

    /// <summary>
    /// @Version: 5.0
    /// </summary>

    public class CurrentSalary : BaseGT
    {
        //TODO: Think some thing others also
        //TODO: Implement tailoring division on this model
        public int CurrentSalaryId { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }

        //[DataType(DataType.Currency), Column(TypeName = "money")]
        //public decimal SundaySalary { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal LPRate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal IncentiveRate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal IncentiveTarget { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal WOWBillRate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal WOWBillTarget { get; set; }

        [DefaultValue(true)]
        public bool IsFullMonth { get; set; }
        public bool IsSundayBillable { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EffectiveDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CloseDate { get; set; }

        public bool IsEffective { get; set; }
        [DefaultValue(false)]
        public bool IsTailoring { get; set; }

        public virtual ICollection<PaySlip> PaySlips { get; set; }

    }
}
