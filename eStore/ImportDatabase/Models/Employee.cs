using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

//public enum ArvindAccount { ArvindLimited, ALBL, AFL, Others }
namespace AprajitaRetails.ImportDatabase.Models
{
    public class VBInvoice
    {
        public int VBInvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime OnDate { get; set; }
        public int StoreId { get; set; }

        public string BillType { get; set; }
        public decimal BillAmount { get; set; }
        public decimal BillGrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }

        public string CustomerMobile { get; set; }
        public string CustomerName { get; set; }
        public bool Tailoring { get; set; }

        public ICollection<VBPaymentDetail> VBPaymentDetails { get; set; }
        public ICollection<VBLineItem> VBLineItems { get; set; }
    }

    public class VBPaymentDetail
    {
        public int VBPaymentDetailId { get; set; }

        public string Mode { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public int VBInvoiceid { get; set; }
        public virtual VBInvoice Invoice { get; set; }
    }

    public class VBLineItem
    {
        public int VBLineItemId { get; set; }
        public int SerialNo { get; set; }
        public string LineItemType { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LineTotalAmount { get; set; }

        public int VBInvoiceid { get; set; }
        public virtual VBInvoice Invoice { get; set; }
    }
    //Banking Section
    public class Bank
    {
        public int BankId { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        public ICollection<AccountNumber> Accounts { get; set; }
        public ICollection<BankAccountInfo> BankAccounts { get; set; }
        //public ICollection<Areas.Uploader.Models.BankSetting> BankSettings { get; set; }
        //public ICollection<Areas.Accountings.Models.BankAccount> BankAcc { get; set; }

    }
    public class TranscationMode
    {
        [Display(Name = "Mode")]
        public int TranscationModeId { get; set; }
        //[Index(IsUnique = true)]
        [Display(Name = "Transaction Mode")]
        public string Transcation { get; set; }

        public virtual ICollection<CashReceipt> CashReceipts { get; set; }
        public virtual ICollection<CashPayment> CashPayments { get; set; }
        //Modes Name  write Seed 
        // Amit Kumar , Mukesh, HomeExp, OtherHomeExpenses,CashInOut
    }

    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string StaffName { get; set; }

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
        public string? EMail { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? AdharNumber { get; set; }
        public string? PanNo { get; set; }
        public string? OtherIdDetails { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? FatherName { get; set; }

        public string HighestQualification { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<SalaryPayment> SalaryPayments { get; set; }
        public ICollection<StaffAdvancePayment> AdvancePayments { get; set; }
        public ICollection<StaffAdvanceReceipt> AdvanceReceipts { get; set; }
        public ICollection<PettyCashExpense> CashExpenses { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public ICollection<Salesman> Salesmen { get; set; }

        public virtual ICollection<CurrentSalary> CurrentSalaries { get; set; }
        public virtual EmployeeUser User { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }

    public class EmployeeUser
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string UserName { get; set; }
        public bool IsWorking { get; set; }
    }
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Display(Name = "Staff Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Attendance Date")]
        public DateTime AttDate { get; set; }

        [Display(Name = "Entry Time")]
        public string EntryTime { get; set; }

        public AttUnit Status { get; set; }
        public string Remarks { get; set; }
        public bool? IsTailoring { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }
    public class CurrentSalary
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

        public string UserName { get; set; }
    }
    //TODO: convert to implement tailioring division also
    public class PaySlip
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

        public string UserName { get; set; }


    }
    public class StaffAdvanceReceipt
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
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }


    public class StaffAdvancePayment
    {
        public int StaffAdvancePaymentId { get; set; }

        [Display(Name = "Staff Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }

        public string Details { get; set; }


        [Display(Name = "Party")]
        public int? PartyId { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
        [DefaultValue(false)]
        public bool? IsDataMoved { get; set; }
    }




    public class Salesman
    {
        public int SalesmanId { get; set; }
        [Display(Name = "Salesman")]
        public string SalesmanName { get; set; }

        public virtual ICollection<DailySale> DailySales { get; set; }
        //public virtual ICollection<RegularSaleItem> SaleItems { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        // public int StoreLocationId { get; internal set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }




    public class SalaryPayment
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
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }




    public class Receipt
    {
        public int ReceiptId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expense Date")]
        public DateTime RecieptDate { get; set; }

        [Display(Name = "Receipt From ")]
        public string ReceiptFrom { get; set; }


        [Display(Name = "Payment Mode")]
        public PaymentMode PayMode { get; set; }
        [Display(Name = "Receipt Details ")]
        public string ReceiptDetails { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Receipt Slip No ")]
        public string RecieptSlipNo { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Party")]
        public int? PartyId { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }




    public class CashDetail
    {
        public int CashDetailId { set; get; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { set; get; }
        [Display(Name = "2000")]
        public int C2000 { set; get; }
        [Display(Name = "1000")]
        public int C1000 { set; get; }
        [Display(Name = "500")]
        public int C500 { set; get; }
        [Display(Name = "100")]
        public int C100 { set; get; }
        [Display(Name = "50")]
        public int C50 { set; get; }
        [Display(Name = "20")]
        public int C20 { set; get; }
        [Display(Name = "10")]
        public int C10 { set; get; }
        [Display(Name = "5")]
        public int C5 { set; get; }
        [Display(Name = "Coin 10")]
        public int Coin10 { set; get; }
        [Display(Name = "Coin 5")]
        public int Coin5 { set; get; }
        [Display(Name = "Coin 2")]
        public int Coin2 { set; get; }
        [Display(Name = "Coin 1")]
        public int Coin1 { set; get; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
    public class CashPayment
    {
        public int CashPaymentId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Mode")]
        public int TranscationModeId { get; set; }
        public TranscationMode Mode { get; set; }

        [Display(Name = "Paid To"), Required]
        public string PaidTo { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Receipt No")]
        public string SlipNo { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }
    public class CashReceipt
    {
        public int CashReceiptId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Receipt Date")]
        public DateTime InwardDate { get; set; }

        [Display(Name = "Mode")]
        public int TranscationModeId { get; set; }
        public TranscationMode Mode { get; set; }

        [Display(Name = "Receipt From"), Required]
        public string ReceiptFrom { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Receipt No")]
        public string SlipNo { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }
    public class ChequesLog
    {
        public int ChequesLogId { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Account No")]
        public string AccountNumber { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cheques Date")]
        public DateTime? ChequesDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deposit Date")]
        public DateTime? DepositDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cleared Date")]
        public DateTime? ClearedDate { get; set; }
        [Display(Name = "By")]
        public string IssuedBy { get; set; }
        [Display(Name = "To")]
        public string IssuedTo { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "PDC")]
        public bool IsPDC { get; set; }
        [Display(Name = "By Aprajita Retails")]
        public bool IsIssuedByAprajitaRetails { get; set; }
        [Display(Name = "To Aprajita Retails")]
        public bool IsDepositedOnAprajitaRetails { get; set; }
        public string Remarks { get; set; }


        public string UserName { get; set; }
    }

    public class DueRecoverd
    {
        public int DueRecoverdId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Recovery Date")]
        public DateTime PaidDate { get; set; }

        public int DuesListId { get; set; }
        public virtual DuesList DuesList { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal AmountPaid { get; set; }
        [Display(Name = "Is Partial Payment")]
        public bool IsPartialPayment { get; set; }
        public PaymentMode Modes { get; set; }
        public string Remarks { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }
    public class DuesList
    {
        public int DuesListId { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]

        public decimal Amount { get; set; }

        [Display(Name = "Is Paid")]
        public bool IsRecovered { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Recovery Date")]
        public DateTime? RecoveryDate { get; set; }
        public int DailySaleId { get; set; }
        public virtual DailySale DailySale { get; set; }

        public bool IsPartialRecovery { get; set; }

        public virtual ICollection<DueRecoverd> Recoverds { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
    public class EndOfDay
    {
        public int EndOfDayId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EOD Date")]
        // [Index(IsUnique = true)]
        public DateTime EOD_Date { get; set; }

        public float Shirting { get; set; }
        public float Suiting { get; set; }
        public int USPA { get; set; }

        [Display(Name = "FM/Arrow/Others")]
        public int FM_Arrow { get; set; }

        [Display(Name = "Arvind RTW")]
        public int RWT { get; set; }

        [Display(Name = "Accessories")]
        public int Access { get; set; }
        [Display(Name = "Cash at Store")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CashInHand { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
    public class Expense
    {
        public int ExpenseId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expense Date")]
        public DateTime ExpDate { get; set; }//Ok

        public string Particulars { get; set; }//Ok

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }//Ok

        [Display(Name = "Payment Mode")]
        public PaymentMode PayMode { get; set; }//Ok

        [Display(Name = "Payment Details")]
        public string PaymentDetails { get; set; }//Ok

        [Display(Name = "Paid By")]
        public int EmployeeId { get; set; }//Ok
        public virtual Employee PaidBy { get; set; }//Ok

        [Display(Name = "Paid To")]
        public string PaidTo { get; set; }//Ok

        public string Remarks { get; set; }//Ok

        [Display(Name = "Party")]
        public int? PartyId { get; set; }//Ok
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; } //Ok
        public virtual Store Store { get; set; }//Ok

        public string UserName { get; set; }//Ok

    }

    public class Payment
    {
        public int PaymentId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PayDate { get; set; }

        [Display(Name = "Payment Party")]
        public string PaymentPartry { get; set; }
        [Display(Name = "Payment Mode")]
        public PaymentMode PayMode { get; set; }
        [Display(Name = "Payment Details")]
        public string PaymentDetails { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Payment Slip No")]
        public string PaymentSlipNo { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Party")]
        public int? PartyId { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }

    }
    public class PettyCashExpense
    {
        public int PettyCashExpenseId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expense Date")]
        public DateTime ExpDate { get; set; }

        [Display(Name = "Expense Details")]
        public string Particulars { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Paid By")]
        public int EmployeeId { get; set; }
        public virtual Employee PaidBy { get; set; }


        [Display(Name = "Paid To")]
        public string PaidTo { get; set; }

        [Display(Name = "Remarks/Details")]
        public string Remarks { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }

    public class BankWithdrawal
    {
        public int BankWithdrawalId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Withdrawal Date")]
        public DateTime DepoDate { get; set; }

        public int AccountNumberId { get; set; }
        public AccountNumber Account { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Cheques Details")]
        public string ChequeNo { get; set; }

        [Display(Name = "Signed By")]
        public string SignedBy { get; set; }

        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }

        [Display(Name = "Self/Named")]
        public string InNameOf { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public string UserName { get; set; }
    }

    // Entry mode  on any transcation on bank.
    // statement upload.

    public class BankTranscation
    {
        public int BankTranscationId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime OnDate { get; set; }

        public string Particulars { get; set; }
        public string Details { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal InAmount { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal OutAmount { get; set; }
        public bool IsDeposited { get; set; }
        public int RefId { get; set; }
        public string UserName { get; set; }
    }

    //S No.Value Date Transaction Date Cheque Number Transaction Remarks Withdrawal Amount (INR ) Deposit Amount (INR ) Balance (INR )
    public class BankStatement
    {
        public int ID { get; set; }
        public int AccountNumberId { get; set; }
        public virtual AccountNumber AccountNumber { get; set; }
        public DateTime OnDateValue { get; set; }
        public DateTime OnDateTranscation { get; set; }
        public string ChequeNumber { get; set; }
        public string TransactionRemarks { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal WithdrawalAmount { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal DepositAmount { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public Remark Remark { get; set; }
    }
    public class BankDeposit
    {
        public int BankDepositId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deposit Date")]
        public DateTime DepoDate { get; set; }

        public int AccountNumberId { get; set; }
        public AccountNumber Account { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public BankPayMode PayMode { get; set; }

        [Display(Name = "Transaction Details")]
        public string Details { get; set; }
        public string Remarks { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }
    public class AccountNumber
    {
        public int AccountNumberId { get; set; }

        [Display(Name = "Bank Name")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        [Display(Name = "Account Number")]
        public string Account { get; set; }
        [Display(Name = "Account Type")]
        public AccountType? AccountType { get; set; }

        public ICollection<BankDeposit> Deposits { get; set; }
        public ICollection<BankWithdrawal> Withdrawals { get; set; }
        public ICollection<BankStatement> BankStatements { get; set; }
    }
    public class BankAccountInfo
    {
        public int BankAccountInfoId { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public AccountType AccountType { get; set; }
        [Display(Name = "Client Account")]
        public bool IsClientAccount { get; set; }
        public virtual BankAccountSecurityInfo AccountSecurityInfo { get; set; }

    }

    public class BankAccountSecurityInfo
    {
        [ForeignKey("BankAccountInfo")]
        public int BankAccountSecurityInfoId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string TaxPassword { get; set; }
        public string ExtraPassword { get; set; }
        public string ATMCardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int CVVNo { get; set; }
        public int ATMPin { get; set; }
        public int TPIN { get; set; }

        public virtual BankAccountInfo BankAccountInfo { get; set; }
    }

    public class Store
    {
        public int StoreId { get; set; }
        [Display(Name = "Store Code")]
        public string StoreCode { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }
        [Display(Name = "Contact No")]
        public string PhoneNo { get; set; }
        [Display(Name = "Store Manager Name")]
        public string StoreManagerName { get; set; }
        [Display(Name = "SM Contact No")]
        public string StoreManagerPhoneNo { get; set; }
        [Display(Name = "PAN No")]
        public string PanNo { get; set; }
        [Display(Name = "GSTIN ")]
        public string GSTNO { get; set; }
        [Display(Name = "Employees Count")]
        public int NoOfEmployees { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Closing Date")]
        public DateTime? ClosingDate { get; set; }
        [Display(Name = "Operative")]
        public bool Status { get; set; }

        public virtual ICollection<ImportPurchase> ImportPurchases { get; set; }
        public virtual ICollection<ImportInWard> ImportInWards { get; set; }
        public virtual ICollection<ImportSaleItemWise> ImportSaleItemWises { get; set; }
        public virtual ICollection<ImportSaleRegister> ImportSaleRegisters { get; set; }

        //Purchase
        public virtual ICollection<ProductPurchase> ProductPurchases { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }

        public virtual ICollection<DailySale> DailySales { get; set; }
        public virtual ICollection<Salesman> Salesmen { get; set; }
       // public virtual ICollection<CashInHand> CashInHands { get; set; }
       // public virtual ICollection<CashInBank> CashInBanks { get; set; }

        //public int CompanyId { get; set; }
        //public virtual Company Company { get; set; }



    }
    public class ArvindPayment
    {
        public int ArvindPaymentId { get; set; }
        public ArvindAccount Arvind { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }
        public string InvoiceNo { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public string BankDetails { get; set; }
        public string Remarks { get; set; }

        public string UserName { get; set; }

    }
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonPhoneNo { get; set; }
        public string WebSite { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }

    //global Class
    public class Brand
    {
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [Display(Name = "Brand Code")]
        public string BCode { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Primary")]
        public bool IsPrimaryCategory { get; set; }
        [Display(Name = "Secondary")]
        public bool IsSecondaryCategory { get; set; }
    }
    public class Supplier
    {
        public int SupplierID { get; set; }
        [Display(Name = "Supplier")]
        public string SuppilerName { get; set; }
        public string Warehouse { get; set; }
        public ICollection<ProductPurchase> ProductPurchases { get; set; }
    }
    public class PurchaseTaxType
    {
        public int PurchaseTaxTypeId { get; set; }
        [Display(Name = "Tax")]
        public string TaxName { get; set; }
        [Display(Name = "Tax Type")]
        public TaxType TaxType { get; set; }
        [Display(Name = "Composite Rate")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CompositeRate { get; set; }
        //Navigation
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }


    //Global Class

    public class ProductItem
    {
        public int ProductItemId { set; get; }

        public string Barcode { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public virtual Brand BrandName { get; set; }

        [Display(Name = "Style Code")]
        public string StyleCode { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Item Desc")]
        public string ItemDesc { get; set; }

        [Display(Name = "Category")]
        public ProductCategory Categorys { get; set; }
        [Display(Name = "Product Type")]
        public Category MainCategory { get; set; }
        [Display(Name = "Product Series")]
        public Category ProductCategory { get; set; }
        [Display(Name = "Sub Category")]
        public Category ProductType { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRP { get; set; }
        [Display(Name = "Tax Rate")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TaxRate { get; set; }    // TODO:Need to Review in final Edition
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public string? HSNCode { get; set; }
        public Size Size { get; set; }
        public Unit Units { get; set; }


        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }


    }
    //Store Based Class
    public class ProductPurchase
    {
        public int ProductPurchaseId { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string InWardNo { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InWardDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public string InvoiceNo { get; set; }
        public double TotalQty { get; set; }
        [Display(Name = "Basic Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalBasicAmount { get; set; }
        [Display(Name = "Shipping Cost")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal ShippingCost { get; set; }
        [Display(Name = "Tax")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalTax { get; set; }
        [Display(Name = "Total Amount")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
        [Display(Name = "Paid")]
        public bool IsPaid { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }

        public string UserName { get; set; }



    }
    // This is Store Based but still StoreID linking is not done. will check for it in final realase
    public class PurchaseItem
    {
        public int PurchaseItemId { get; set; }//Pk
        [Display(Name = "Purchase ID")]
        public int ProductPurchaseId { get; set; }//FK
        public virtual ProductPurchase ProductPurchase { get; set; }     //Nav
        [Display(Name = "Product")]
        public int ProductItemId { get; set; } //FK 
        public virtual ProductItem ProductItem { get; set; }
        public string Barcode { get; set; }// TODO: if not working then link with productitemid
        public double Qty { get; set; }
        public Unit Unit { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Cost { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        [Display(Name = "Tax Amount")]
        public decimal TaxAmout { get; set; }
        [Display(Name = "Input Tax")]
        public int? PurchaseTaxTypeId { get; set; } //TODO: Temp Purpose. need to calculate tax here
        public virtual PurchaseTaxType PurchaseTaxType { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CostValue { get; set; }
    }
    //Store Based Class
    public class Stock
    {
        public int StockID { set; get; }
        [Display(Name = "Store")]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        [Display(Name = "Product")]
        public int ProductItemId { set; get; }
        public virtual ProductItem ProductItem { get; set; }
        public double Quantity { set; get; }
        [Display(Name = "Sale Qty")]
        public double SaleQty { get; set; }
        [Display(Name = "Purchase Qty")]
        public double PurchaseQty { get; set; }
        public Unit Units { get; set; }



    }



    //Version 3.0 
    // Added Feature
    //Income

    public class DailySale
    {
        public int DailySaleId { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sale Date")]
        public DateTime SaleDate { get; set; }
        [Display(Name = "Invoice No")]
        public string InvNo { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }
        [Display(Name = "Cash Amount")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CashAmount { get; set; }
        [ForeignKey("Salesman")]
        public int SalesmanId { get; set; }
        public virtual Salesman Salesman { get; set; }
        [Display(Name = "Due")]
        public bool IsDue { get; set; }
        [Display(Name = "Manual Bill")]
        public bool IsManualBill { get; set; }
        [Display(Name = "Tailoring Bill")]
        public bool IsTailoringBill { get; set; }
        [Display(Name = "Sale Return")]
        public bool IsSaleReturn { get; set; }
        public string Remarks { get; set; }
        [DefaultValue(false)]
        public bool IsMatchedWithVOy { get; set; }

        public int? EDCTranscationId { get; set; }
        public virtual EDCTranscation EDCTranscation { get; set; }

        public int? MixAndCouponPaymentId { get; set; }
        public virtual MixAndCouponPayment MixAndCouponPayment { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        public string UserName { get; set; }

        public virtual CouponPayment CouponPayment { get; set; }
        public virtual PointRedeemed PointRedeemed { get; set; }
    }

    public class CouponPayment
    {
        public int CouponPaymentId { get; set; }
        public string CouponNumber { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }

        public int DailySaleId { get; set; }
        public virtual DailySale DailySale { get; set; }
        public string InvoiceNumber { get; set; }

        public string Remark { get; set; }

    }
    public class PointRedeemed
    {
        public int PointRedeemedId { get; set; }
        public string CustomerMobileNumber { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }

        public int DailySaleId { get; set; }
        public virtual DailySale DailySale { get; set; }
        public string InvoiceNumber { get; set; }

        public string Remark { get; set; }
    }

    public class EDC
    {
        public int EDCId { get; set; }
        public int TID { get; set; }
        public string EDCName { get; set; }
        public int AccountNumberId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public bool IsWorking { get; set; }
        public string MID { get; set; }
        public string Remark { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

    }
    public class EDCTranscation
    {
        public int EDCTranscationId { get; set; }
        public int EDCId { get; set; }
        public virtual EDC CardMachine { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }
        public string CardEndingNumber { get; set; }
        public CardMode CardTypes { get; set; }
        public string InvoiceNumber { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

    }


    public class MixAndCouponPayment
    {
        public int MixAndCouponPaymentId { get; set; }

        public string InvoiceNumber { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OnDate { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public MixAndCouponPayment Mode { get; set; }
        public string Details { get; set; }
        public string Remarks { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }


    }



    public class RentedLocation
    {
        public int RentedLocationId { get; set; }
        public string PlaceName { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime OnDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Vacate Date")]
        public DateTime? VacatedDate { get; set; }

        public string City { get; set; }
        public string OwnerName { get; set; }
        public string MobileNo { get; set; }
        public decimal RentAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public bool IsRented { get; set; }
        public RentType RentType { get; set; }
    }

    public class Rent
    {
        public int RentId { get; set; }
        [Display(Name = "Location")]
        public int RentedLocationId { get; set; }
        public virtual RentedLocation Location { get; set; }
        public RentType RentType { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime OnDate { get; set; }

        public string Period { get; set; }

        [Display(Name = "Amount")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public PaymentMode Mode { get; set; }
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
    }





    public class ElectricityConnection
    {
        public int ElectricityConnectionId { get; set; }
        public string LocationName { get; set; }
        public string ConnectioName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string ConsumerNumber { get; set; }
        public string ConusumerId { get; set; }
        public ConnectionType Connection { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Connection Date")]
        public DateTime ConnectinDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Disconnection Date")]
        public DateTime? DisconnectionDate { get; set; }

        public int KVLoad { get; set; }
        public bool OwnedMetter { get; set; }

        [Display(Name = "Connection Amount"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalConnectionCharges { get; set; }
        [Display(Name = "Security Deposit"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal SecurityDeposit { get; set; }
        public string Remarks { get; set; }


    }


    public class EletricityBill
    {
        public int EletricityBillId { get; set; }
        public int ElectricityConnectionId { get; set; }
        public string BillNumber { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date")]
        public DateTime BillDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Date")]
        public DateTime MeterReadingDate { get; set; }

        public double CurrentMeterReading { get; set; }
        public double TotalUnit { get; set; }

        [Display(Name = "Current Amount"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CurrentAmount { get; set; }
        [Display(Name = "Arrear Amount"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal ArrearAmount { get; set; }
        [Display(Name = "Net Amount"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal NetDemand { get; set; }

        public ElectricityConnection Connection { get; set; }

    }
    public class Contact
    {
        public int ContactId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Phone]
        [Display(Name = "Mobile No")]
        public string? MobileNo { get; set; }
        [Phone]
        [Display(Name = "Phone No")]
        public string? PhoneNo { get; set; }
        [EmailAddress]
        [Display(Name = "eMail")]
        public string? EMailAddress { get; set; }
        [Display(Name = "Notes")]
        public string? Remarks { get; set; }

        public string UserName { get; set; }
    }
    public class EBillPayment
    {
        public int EBillPaymentId { get; set; }
        public int EletricityBillId { get; set; }
        public virtual EletricityBill Bill { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Amount"), DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public PaymentMode Mode { get; set; }
        public string PaymentDetails { get; set; }
        public string Remarks { get; set; }
        public bool IsPartialPayment { get; set; }
        public bool IsBillCleared { get; set; }


    }
     


    public class BookEntry
    {
        public int BookEntryId { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        ////[ExcelColumn("Inward Date")]
        [Column(TypeName = "DateTime2")]
        [Display(Name = "On Date")]
        public DateTime OnDate { get; set; }
        [Display(Name = "Ledger By")]
        public LedgerBy LedgerBy { get; set; }
        [Display(Name = "Ledger To")]
        public LedgerTo LedgerTo { get; set; }
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Display(Name = "Voucher Type")]
        public VoucherType VoucherType { get; set; }
        public string Naration { get; set; }
        [Display(Name = "Processed")]
        public bool IsConsumed { get; set; }
    }
    public class ImportSearchList
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string InvoiceNo { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OnDate { get; set; }
    }



    public class ImportInWard
    {
        //Inward No	Inward Date	Invoice No	Invoice Date	Party Name	Total Qty	Total MRP Value	Total Cost

        public int ImportInWardId { get; set; }

        //[ExcelColumn("Inward No")]
        public string InWardNo { get; set; }

        // 4/4/2018  5:34:56 PM
        // [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm:ss tt}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[ExcelColumn("Inward Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime InWardDate { get; set; }

        //[ExcelColumn("Invoice No")]
        public string InvoiceNo { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[ExcelColumn("Invoice Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime InvoiceDate { get; set; }

        //[ExcelColumn("Party Name")]
        public string PartyName { get; set; }

        //[ExcelColumn("Total Qty")]
        [DataType(DataType.Currency), Column(TypeName = "decimal(18,2)")]
        public decimal TotalQty { get; set; }

        //[ExcelColumn("Total MRP Value")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalMRPValue { get; set; }

        //[ExcelColumn("Total Cost")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TotalCost { get; set; }

        [DefaultValue(false)]
        public bool IsDataConsumed { get; set; } = false;// is data imported to relevent table

        //Store Based Started
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime? ImportDate { get; set; } = DateTime.Now;


    }

    public class ImportPurchase
    {
        //GRNNo	GRNDate	Invoice No	Invoice Date	Supplier Name	Barcode	Product Name	Style Code	Item Desc	Quantity	MRP	MRP Value	Cost	Cost Value	TaxAmt	ExmillCost	Excise1	Excise2	Excise3

        public int ImportPurchaseId { get; set; }

        //[ExcelColumn("GRNNo")]
        public string GRNNo { get; set; }

        //[ExcelColumn("GRNDate")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GRNDate { get; set; }

        //[ExcelColumn("Invoice No")]
        public string InvoiceNo { get; set; }

        //[ExcelColumn("Invoice Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        //[ExcelColumn("Supplier Name")]
        public string SupplierName { get; set; }

        //[ExcelColumn("Bar code")]
        public string Barcode { get; set; }

        //[ExcelColumn("Product Name")]
        public string ProductName { get; set; }

        //[ExcelColumn("Style Code")]
        public string StyleCode { get; set; }

        //[ExcelColumn("Item Desc")]
        public string ItemDesc { get; set; }

        //[ExcelColumn("Quantity")]
        public double Quantity { get; set; }

        //[ExcelColumn("MRP")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRP { get; set; }

        //[ExcelColumn("MRP Value")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRPValue { get; set; }

        //[ExcelColumn("Cost")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Cost { get; set; }

        //[ExcelColumn("Cost Value")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CostValue { get; set; }

        //[ExcelColumn("TaxAmt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }

        public bool IsVatBill { get; set; }
        public bool IsLocal { get; set; }

        [DefaultValue(false)]
        public bool IsDataConsumed { get; set; } = false;// is data imported to relevent table

        //Store Based Started
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }

    //TODO: Need to Create View So String Date error problem will be solved
    public class ImportSaleItemWise
    {
        //Invoice No	Invoice Date	Invoice Type	Brand Name	Product Name	Item Desc	HSN Code	BAR CODE	Style Code	Quantity	MRP	Discount Amt	Basic Amt	Tax Amt	SGST Amt	CGST Amt	Line Total	Round Off	Bill Amt	Payment Mode	SalesMan Name	Coupon %	Coupon Amt	SUB TYPE	Bill Discount	LP Flag	Inst Order CD	TAILORING FLAG


        public int ImportSaleItemWiseId { get; set; }

        //[ExcelColumn("Invoice Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }

        //[ExcelColumn("Invoice No")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        //[ExcelColumn("Invoice Type")]
        [Display(Name = "Invoice Type")]
        public string InvoiceType { get; set; }

        //[ExcelColumn("Brand Name")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        //[ExcelColumn("Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        //[ExcelColumn("Item Desc")]
        [Display(Name = "Item Desc")]
        public string ItemDesc { get; set; }

        //[ExcelColumn("HSN Code")]
        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; }

        //[ExcelColumn("BAR CODE")]
        public string Barcode { get; set; }

        //[ExcelColumn("Style Code")]
        [Display(Name = "Style Code")]
        public string StyleCode { get; set; }

        //[ExcelColumn("Quantity")]
        public double Quantity { get; set; }

        //[ExcelColumn("MRP")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRP { get; set; }

        //[ExcelColumn("Discount Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Discount { get; set; }

        //[ExcelColumn("Basic Amt")]
        [Display(Name = "Basic Rate")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BasicRate { get; set; }

        //[ExcelColumn("Tax Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Tax { get; set; } // Can be use for IGST

        //[ExcelColumn("SGST Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal SGST { get; set; }

        //[ExcelColumn("CGST Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CGST { get; set; }

        //[ExcelColumn("Line Total")]
        [Display(Name = "Line Total")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal LineTotal { get; set; }

        //[ExcelColumn("Round Off")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal RoundOff { get; set; }

        //[ExcelColumn("Bill Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        [Display(Name = "Bill Amount")]
        public decimal BillAmnt { get; set; }

        //[ExcelColumn("Payment Mode")]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        //[ExcelColumn("SalesMan Name")]
        public string Saleman { get; set; }

        [DefaultValue(false)]
        public bool IsDataConsumed { get; set; } = false;

        [DefaultValue(false)]
        public bool IsVatBill { get; set; }
        [DefaultValue(false)]
        public bool IsLocal { get; set; }

        public bool LP { get; set; }

        //Store Based Started
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

    }

    public class ImportSaleItemWiseVM
    {
        //Invoice No	Invoice Date	Invoice Type	Brand Name	Product Name	Item Desc	HSN Code	BAR CODE	Style Code	Quantity	MRP	Discount Amt	Basic Amt	Tax Amt	SGST Amt	CGST Amt	Line Total	Round Off	Bill Amt	Payment Mode	SalesMan Name	Coupon %	Coupon Amt	SUB TYPE	Bill Discount	LP Flag	Inst Order CD	TAILORING FLAG
        public static ImportSaleItemWise ToTable(ImportSaleItemWiseVM data)
        {


            ImportSaleItemWise item = new ImportSaleItemWise
            {
                Barcode = data.Barcode,
                BasicRate = data.BasicRate,
                BillAmnt = data.BillAmnt,
                BrandName = data.BrandName,
                CGST = data.CGST,
                Discount = data.Discount,
                HSNCode = data.HSNCode,
                InvoiceDate = DateTime.ParseExact(data.InvoiceDate.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                InvoiceNo = data.InvoiceNo,
                InvoiceType = data.InvoiceType,
                IsDataConsumed = data.IsDataConsumed,
                ImportSaleItemWiseId = data.ImportSaleItemWiseId,
                Quantity = data.Quantity,
                ItemDesc = data.ItemDesc,
                LineTotal = data.LineTotal,
                MRP = data.MRP,
                PaymentType = data.PaymentType,
                StoreId = data.StoreId,
                ProductName = data.ProductName,
                RoundOff = data.RoundOff,
                Saleman = data.Saleman,
                SGST = data.SGST,
                StyleCode = data.StyleCode,
                Tax = data.Tax,
                IsLocal = data.IsLocal,
                IsVatBill = data.IsVatBill
            };
            return item;
        }

        public int ImportSaleItemWiseId { get; set; }

        //[ExcelColumn("Invoice Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string InvoiceDate { get; set; }

        //[ExcelColumn("Invoice No")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        //[ExcelColumn("Invoice Type")]
        [Display(Name = "Invoice Type")]
        public string InvoiceType { get; set; }

        //[ExcelColumn("Brand Name")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        //[ExcelColumn("Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        //[ExcelColumn("Item Desc")]
        [Display(Name = "Item Desc")]
        public string ItemDesc { get; set; }

        //[ExcelColumn("HSN Code")]
        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; }

        //[ExcelColumn("BAR CODE")]
        public string Barcode { get; set; }

        //[ExcelColumn("Style Code")]
        [Display(Name = "Style Code")]
        public string StyleCode { get; set; }

        //[ExcelColumn("Quantity")]
        public double Quantity { get; set; }

        //[ExcelColumn("MRP")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRP { get; set; }

        //[ExcelColumn("Discount Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Discount { get; set; }

        //[ExcelColumn("Basic Amt")]
        [Display(Name = "Basic Rate")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BasicRate { get; set; }

        //[ExcelColumn("Tax Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Tax { get; set; } // Can be use for IGST

        //[ExcelColumn("SGST Amt")]

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal SGST { get; set; }

        //[ExcelColumn("CGST Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal CGST { get; set; }
        //[ExcelColumn("Line Total")]
        [Display(Name = "Line Total")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal LineTotal { get; set; }

        //[ExcelColumn("Round Off")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal RoundOff { get; set; }
        //[ExcelColumn("Bill Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        [Display(Name = "Bill Amount")]
        public decimal BillAmnt { get; set; }
        //[ExcelColumn("Payment Mode")]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        //[ExcelColumn("SalesMan Name")]
        public string Saleman { get; set; }
        [DefaultValue(false)]
        public bool IsDataConsumed { get; set; } = false;
        public bool IsVatBill { get; set; }
        public bool IsLocal { get; set; }

        //Store Based Started
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }

    public class ImportSaleRegister
    {
        public int ImportSaleRegisterId { get; set; }

        //[ExcelColumn("Invoice No")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        //[ExcelColumn("Invoice Type")]
        [Display(Name = "Invoice Type")]
        public string InvoiceType { get; set; }

        //[ExcelColumn("Invoice Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public string InvoiceDate { get; set; }

        //[ExcelColumn("Quantity")]
        public double Quantity { get; set; }

        //[ExcelColumn("MRP")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal MRP { get; set; }

        //[ExcelColumn("Discount")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Discount { get; set; }
        //[ExcelColumn("Basic Amt")]
        [Display(Name = "Basic Rate")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BasicRate { get; set; }

        //[ExcelColumn("Tax Amt")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Tax { get; set; }

        //[ExcelColumn("Round Off")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal RoundOff { get; set; }

        //[ExcelColumn("Bill Amt")]
        [Display(Name = "Bill Amount")]
        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal BillAmnt { get; set; }

        //[ExcelColumn("Payment Mode")]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        public bool IsConsumed { get; set; } = false;

        //Store Based Started
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

    }

    public class TailoringStaffAdvancePayment
    {
        public int TailoringStaffAdvancePaymentId { get; set; }

        [Display(Name = "Tailor Name")]
        public int TailoringEmployeeId { get; set; }

      //  public TailoringEmployee Employee { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }

        public string Details { get; set; }
    }

     

    public class TailoringStaffAdvanceReceipt
    {
        public int TailoringStaffAdvanceReceiptId { get; set; }

        [Display(Name = "Staff Name")]
        public int TailoringEmployeeId { get; set; }

       // public TailoringEmployee Employee { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Receipt Date")]
        public DateTime ReceiptDate { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Payment Mode")]
        public PayMode PayMode { get; set; }

        public string Details { get; set; }
    }

    public class TalioringBooking
    {
        public int TalioringBookingId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Customer Name")]
        public string CustName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Trail Date")]
        public DateTime TryDate { get; set; }

        [Display(Name = "Booking Slip")]
        public string BookingSlipNo { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Total Qty")]
        public int TotalQty { get; set; }

        [Display(Name = "Shirt Qty")]
        public int ShirtQty { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Shirt Price")]
        public decimal ShirtPrice { get; set; }

        [Display(Name = "Pant Qty")]
        public int PantQty { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Pant Price")]
        public decimal PantPrice { get; set; }

        [Display(Name = "Coat Qty")]
        public int CoatQty { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Coat Price")]
        public decimal CoatPrice { get; set; }

        [Display(Name = "Kurta Qty")]
        public int KurtaQty { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Kurta Price")]
        public decimal KurtaPrice { get; set; }

        [Display(Name = "Bundi Qty")]
        public int BundiQty { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Bundi Price")]
        public decimal BundiPrice { get; set; }

        [Display(Name = "Others Qty")]
        public int Others { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money"), Display(Name = "Others Price")]
        public decimal OthersPrice { get; set; }

        [DefaultValue(false)]
        public bool IsDelivered { get; set; }

        public virtual ICollection<TalioringDelivery> Deliveries { get; set; }

        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }

    public class TalioringDelivery
    {
        public int TalioringDeliveryId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Booking ID")]
        public int TalioringBookingId { get; set; }
        public TalioringBooking Booking { get; set; }

        [Display(Name = "Voy Inv No")]
        public string InvNo { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public string Remarks { get; set; }
        //Version 3.0
        [DefaultValue(1)]
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public string UserName { get; set; }
    }
}