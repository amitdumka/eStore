using System;
using System.Collections.Generic;
using eStore.BL.Exporter.Database;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;

namespace eStore.BL.Exporter.Importer
{
    public class ImportExpenses
    {
        private XSReader xS;
        private eStoreDbContext db;

        public ImportExpenses(eStoreDbContext dbContext)
        {
            db = dbContext;
        }

        public async System.Threading.Tasks.Task ReadAsync(string fileName)
        {
            xS = new XSReader(fileName);

            if (xS.WorkBookName == "Expenses")
            {
                await AddExpensesAsync();
                await AddPaymentAsync();
                await AddRecieptAsync();
                await AddCashPaymentsAsync();
                await AddCashReceiptAsync();
                await AddPettyCashPaymentsAsync();

            }
            else
            {
                throw new Exception();
            }

        }
        public async System.Threading.Tasks.Task ReadAsync(XSReader ixs)
        {
            xS = ixs;

            if (xS.WorkBookName == "Expenses")
            {
                await AddExpensesAsync();
                await AddPaymentAsync();
                await AddRecieptAsync();
                await AddCashPaymentsAsync();
                await AddCashReceiptAsync();
                await AddPettyCashPaymentsAsync();

            }
            else
            {
                throw new Exception();
            }

        }

        private async System.Threading.Tasks.Task AddExpensesAsync()
        {
            var ws = xS.GetWS("Expenses");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            //ExpenseId	ExpDate	Particulars	Amount	PayMode	PaymentDetails	EmployeeId	PaidTo	Remarks	PartyId	StoreId	UserName

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    Expense exp = new Expense
                    {
                        OnDate = dR.Cell(2).GetDateTime(),
                        Particulars = dR.Cell(3).Value.ToString(),
                        Amount = dR.Cell(4).GetValue<decimal>(),
                        PayMode = dR.Cell(5).GetValue<PaymentMode>(),
                        PaymentDetails = dR.Cell(6).Value.ToString(),
                        EmployeeId = dR.Cell(7).GetValue<int>(),
                        PartyName = dR.Cell(8).Value.ToString(),
                        Remarks = dR.Cell(9).Value.ToString(),
                        PartyId = dR.Cell(10).GetValue<int>(),
                        StoreId = dR.Cell(11).GetValue<int>(),
                        UserId = dR.Cell(12).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,
                        IsDyn = false,
                        IsOn = true,

                    };
                    db.Expenses.Add(exp);


                }
            }

            await db.SaveChangesAsync();;

        }
        private async System.Threading.Tasks.Task AddPaymentAsync()
        {
            var ws = xS.GetWS("Payments");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            //PaymentId PayDate PaymentPartry PayMode PaymentDetails Amount  PaymentSlipNo Remarks PartyId StoreId UserName

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    Payment exp = new Payment
                    {
                        OnDate = dR.Cell(2).GetDateTime(),
                        PartyName = dR.Cell(3).Value.ToString(),
                        PayMode = dR.Cell(4).GetValue<PaymentMode>(),
                        PaymentDetails = dR.Cell(5).Value.ToString(),
                        Amount = dR.Cell(6).GetValue<decimal>(),
                        PaymentSlipNo = dR.Cell(7).Value.ToString(),
                        Remarks = dR.Cell(8).Value.ToString(),
                        PartyId = dR.Cell(9).GetValue<int>(),
                        StoreId = dR.Cell(10).GetValue<int>(),
                        UserId = dR.Cell(11).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,
                        IsDyn = false,
                        IsOn = true,


                    };
                    db.Payments.Add(exp);


                }
            }

            await db.SaveChangesAsync();;

        }
        private async System.Threading.Tasks.Task AddRecieptAsync()
        {
            var ws = xS.GetWS("Reciepts");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            //ReceiptId RecieptDate ReceiptFrom PayMode ReceiptDetails Amount  RecieptSlipNo Remarks PartyId StoreId UserName

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    Receipt exp = new Receipt
                    {
                        OnDate = dR.Cell(2).GetDateTime(),
                        PartyName = dR.Cell(3).Value.ToString(),
                        PayMode = dR.Cell(4).GetValue<PaymentMode>(),
                        PaymentDetails = dR.Cell(5).Value.ToString(),
                        Amount = dR.Cell(6).GetValue<decimal>(),
                        RecieptSlipNo = dR.Cell(7).Value.ToString(),
                        Remarks = dR.Cell(8).Value.ToString(),
                        PartyId = dR.Cell(9).GetValue<int>(),
                        StoreId = dR.Cell(10).GetValue<int>(),
                        UserId = dR.Cell(11).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,
                        IsDyn = false,
                        IsOn = true,


                    };
                    db.Receipts.Add(exp);


                }
            }

            await db.SaveChangesAsync();;

        }
        
        private async System.Threading.Tasks.Task AddCashReceiptAsync()
        {
            var ws = xS.GetWS("Reciepts");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            // CashReceiptId	InwardDate	TranscationModeId	Mode	ReceiptFrom	Amount	SlipNo	StoreId	UserName

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    CashReceipt exp = new CashReceipt
                    {
                        InwardDate = dR.Cell(2).GetDateTime(),
                        TranscationModeId = dR.Cell(3).GetValue<int>(),
                        ReceiptFrom = dR.Cell(5).Value.ToString(),
                        Amount = dR.Cell(6).GetValue<decimal>(),
                        SlipNo = dR.Cell(7).Value.ToString(),
                        Remarks = "Imported",
                        StoreId = dR.Cell(8).GetValue<int>(),
                        UserId = dR.Cell(9).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,

                    };
                    db.CashReceipts.Add(exp);
                }

            }
            await db.SaveChangesAsync();;
        }
        private async System.Threading.Tasks.Task AddCashPaymentsAsync()
        {
            var ws = xS.GetWS("Reciepts");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
                        //           CashPaymentId PaymentDate TranscationModeId Mode    PaidTo Amount  SlipNo StoreId UserName


            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    CashPayment exp = new CashPayment
                    {
                        PaymentDate = dR.Cell(2).GetDateTime(),
                        TranscationModeId = dR.Cell(3).GetValue<int>(),
                        PaidTo = dR.Cell(5).Value.ToString(),
                        Amount = dR.Cell(6).GetValue<decimal>(),
                        SlipNo = dR.Cell(7).Value.ToString(),
                        Remarks = "Imported",
                        StoreId = dR.Cell(8).GetValue<int>(),
                        UserId = dR.Cell(9).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,

                    };
                    db.CashPayments.Add(exp);
                }

            }
            await db.SaveChangesAsync();;
        }

        private int GetTranscationMode(string mode)
        {
            int id = 9;
            mode = mode.ToLower();
            if (mode.Contains("dan"))
            {
                id = 12;
            }
            else if (mode.Contains("breakfast")) id = 13;
            else if (mode.Contains("lunch")) id = 14;
            else if (mode.Contains("coffee")) id = 15;
            else if (mode.Contains("cup") ||mode.Contains("glass")) id = 16;
            else if (mode.Contains("batery")) id = 17;
            return id;
        }
        private async System.Threading.Tasks.Task AddPettyCashPaymentsAsync()
        {
            var ws = xS.GetWS("Reciepts");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
//            PettyCashExpenseId ExpDate Particulars Amount  EmployeeId PaidTo  Remarks StoreId UserName

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    CashPayment exp = new CashPayment
                    {
                        PaymentDate = dR.Cell(2).GetDateTime(),
                        Remarks = "#Pat: "+dR.Cell(3).Value.ToString()+"#RM: "+ dR.Cell(7).Value.ToString(),
                        Amount = dR.Cell(4).GetValue<decimal>(),
                        PaidTo = dR.Cell(6).Value.ToString(),
                        StoreId = dR.Cell(8).GetValue<int>(),
                        UserId = dR.Cell(9).Value.ToString(),
                        EntryStatus = 0,
                        IsReadOnly = true,SlipNo="CashPayment_Imported",
                        

                    };
                    exp.TranscationModeId = GetTranscationMode(dR.Cell(3).Value.ToString());
                    db.CashPayments.Add(exp);
                }

            }
            await db.SaveChangesAsync();
        }
    }

}
/*
 //ExpenseId	ExpDate	Particulars	Amount	PayMode	PaymentDetails	EmployeeId	PaidTo	Remarks	PartyId	StoreId	UserName

 //PaymentId	PayDate	PaymentPartry	PayMode	PaymentDetails	Amount	PaymentSlipNo	Remarks	PartyId	StoreId	UserName
 //ReceiptId	RecieptDate	ReceiptFrom	PayMode	ReceiptDetails	Amount	RecieptSlipNo	Remarks	PartyId	StoreId	UserName
// CashReceiptId	InwardDate	TranscationModeId	Mode	ReceiptFrom	Amount	SlipNo	StoreId	UserName
//CashPaymentId	PaymentDate	TranscationModeId	Mode	PaidTo	Amount	SlipNo	StoreId	UserName
 PettyCashExpenseId	ExpDate	Particulars	Amount	EmployeeId	PaidTo	Remarks	StoreId	UserName


 
 
 
 
 
 */
