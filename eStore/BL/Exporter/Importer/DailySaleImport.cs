using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.DL.Data;
using eStore.Shared.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eStore.BL.Exporter.Database
{
    class DailySaleImport
    {
        private XSReader xS;
        private eStoreDbContext db;

        public DailySaleImport(eStoreDbContext context)
        {
            db = context;
        }

        public async Task ReadDueAsync(XSReader ixs)
        {
            xS = ixs;

            if (xS.WorkBookName == "Daily Sales")
            {
                await AddEDCTranscationAsync();
                await AddDueRecoveredListAsync(await SaleDetailsAsync());
                
            }
            else
            {
                throw new Exception();
            }
        }
        public async System.Threading.Tasks.Task ReadAsync(XSReader ixs)
        {
            xS = ixs;

            if (xS.WorkBookName == "Daily Sales")
            {
                //await AddEDCAsync();
                //await AddDueRecoveredListAsync(await AddDueListsAsync(await AddDailySalesAsync(GetSaleman())));
                //await AddEDCTranscationAsync();
                await AddEDCAsync();
                var sm = GetSaleman();
                var ds = await AddDailySalesAsync(sm);
                var dl = await AddDueListsAsync(ds);
                await AddDueRecoveredListAsync(dl);
                await AddEDCTranscationAsync();
            }
            else
            {
                throw new Exception();
            }

        }
        public async System.Threading.Tasks.Task ReadAsync(string fileName)
        {
            xS = new XSReader(fileName);

            if (xS.WorkBookName == "Daily Sales")
            {
                await AddEDCAsync();
                var sm = GetSaleman();
                var ds = await AddDailySalesAsync(sm);
                var dl = await AddDueListsAsync(ds);
                await AddDueRecoveredListAsync(dl);
                await AddEDCTranscationAsync();

            }
            else
            {
                throw new Exception();
            }

        }

        private async Task<SortedList<int, int>> SaleDetailsAsync()
        {
            var ws = xS.GetWS("DailySales");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title
            SortedDictionary<int, string> SaleList = new SortedDictionary<int, string>();
            foreach (var dR in nonEmptyDataRows)            
                if (dR.RowNumber() > Row)               
                    SaleList.Add(dR.Cell(1).GetValue<int>(), dR.Cell(3).GetValue<string>());

             ws = xS.GetWS("DueLists");
             nonEmptyDataRows = ws.RowsUsed();
             SortedList<int, int> IDList = new SortedList<int, int>();
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                    IDList.Add(dR.Cell(1).GetValue<int>(),await GetDueIdAsync(GetSaleId(SaleList.GetValueOrDefault(dR.Cell(5).GetValue<int>()))));
            }
            return IDList;

        }

        private int GetSaleId(string inv)
        {
            return db.DailySales.Where(c => c.InvNo == inv).Select(c => c.DailySaleId).FirstOrDefault();
        }
        private async Task<int> GetDueIdAsync(int id)
        {
           return await db.DuesLists.Where(c => c.DailySaleId == id).Select(c => c.DuesListId).FirstOrDefaultAsync();

        }
        private async System.Threading.Tasks.Task<int> AddEDCAsync()
        {
            var ws = xS.GetWS("CardMachine");
            //EDCId	TID	EDCName	AccountNumberId	StartDate	EndDate	IsWorking	MID	Remark	StoreId
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;

            List<EDC> cardM = new List<EDC>();

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    EDC eDC = new EDC
                    {
                        EDCId = dR.Cell(1).GetValue<int>(),
                        TID = dR.Cell(2).GetValue<int>(),
                        EDCName = dR.Cell(3).Value.ToString(),
                        AccountNumberId = dR.Cell(4).GetValue<int>(),
                        StartDate = dR.Cell(5).GetDateTime(),
                        IsWorking = dR.Cell(7).GetBoolean(),
                        MID = dR.Cell(8).Value.ToString(),
                        Remark = dR.Cell(9).Value.ToString(),
                        StoreId = dR.Cell(10).GetValue<int>(),
                        IsReadOnly = true,
                        UserId = "Admin"
                    };
                    try
                    {
                        eDC.EndDate = (DateTime?)dR.Cell(6).GetDateTime() ?? null;
                    }
                    catch (Exception)
                    {

                    }

                }

            }
            //Add Here
           await db.CardMachine.AddRangeAsync(cardM);
            return  await db.SaveChangesAsync();
        }
        private async System.Threading.Tasks.Task<int> AddEDCTranscationAsync()
        {
            //EDCTranscationId	EDCId	Amount	OnDate	CardEndingNumber	CardTypes	InvoiceNumber	StoreId
            var ws = xS.GetWS("CardTranscations");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;

            List<EDCTranscation> cardM = new List<EDCTranscation>();

            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    EDCTranscation eDC = new EDCTranscation
                    {
                        EDCTranscationId = dR.Cell(1).GetValue<int>(),
                        EDCId = dR.Cell(2).GetValue<int>(),
                        Amount = dR.Cell(3).GetValue<decimal>(),
                        OnDate = dR.Cell(4).GetDateTime(),
                        CardEndingNumber = dR.Cell(5).Value.ToString(),
                        CardTypes = dR.Cell(6).GetValue<CardMode>(),
                        InvoiceNumber = dR.Cell(7).Value.ToString(),
                        StoreId = dR.Cell(8).GetValue<int>(),
                        IsReadOnly = true,
                        UserId = "Admin"
                    };

                }

            }
            //Add Here
           await db.CardTranscations.AddRangeAsync(cardM);
            return await db.SaveChangesAsync();

        }
        private async System.Threading.Tasks.Task<SortedList<int, int>> AddDueListsAsync(SortedDictionary<int, string> SaleList)
        {
            //DuesListId	Amount	IsRecovered	RecoveryDate	DailySaleId	IsPartialRecovery	StoreId

            var ws = xS.GetWS("DueLists");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;

            SortedList<int, int> IDList = new SortedList<int, int>();
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    DuesList dL = new DuesList
                    {
                        IsRecovered = dR.Cell(3).GetBoolean(),
                        Amount = dR.Cell(2).GetValue<decimal>(),
                        DailySaleId = dR.Cell(5).GetValue<int>(),
                        IsPartialRecovery = dR.Cell(6).GetBoolean(),
                        StoreId = dR.Cell(7).GetValue<int>(),
                        UserId = "Admin"
                    };
                    try
                    {
                        dL.RecoveryDate = (DateTime?)dR.Cell(4).GetDateTime() ?? null;
                        
                    }
                    catch (Exception ex)
                    {

                    }
                    dL.DailySaleId = GetSaleId(SaleList.GetValueOrDefault(dL.DailySaleId));
                    db.DuesLists.Add(dL);
                    await db.SaveChangesAsync();
                    IDList.Add(dR.Cell(1).GetValue<int>(), dL.DuesListId);
                }

            }
            return IDList;

        }
        private async System.Threading.Tasks.Task<int> AddDueRecoveredListAsync(SortedList<int, int> IdList)
        {
            var ws = xS.GetWS("DueRecovereds");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title
            //DueRecoverdId PaidDate    DuesListId AmountPaid  IsPartialPayment Modes   Remarks StoreId UserName
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    DueRecoverd dL = new DueRecoverd
                    {
                        //DueRecoverdId = dR.Cell(1).GetValue<int>(),
                        PaidDate = dR.Cell(2).GetDateTime(),
                        DuesListId = dR.Cell(3).GetValue<int>(),
                        AmountPaid = dR.Cell(4).GetValue<decimal>(),
                        IsPartialPayment = dR.Cell(5).GetBoolean(),
                        Modes = dR.Cell(6).GetValue<PaymentMode>(),
                        Remarks = dR.Cell(7).Value.ToString(),
                        StoreId = dR.Cell(8).GetValue<int>(),
                        UserId = dR.Cell(9).Value.ToString(),

                    };
                    dL.DuesListId = IdList.GetValueOrDefault(dL.DuesListId);
                    await db.DueRecoverds.AddAsync(dL);

                }

            }
            return await db.SaveChangesAsync();

        }

        private SortedList<int, string> GetSaleman()
        {
            SortedList<int, string> smList = new SortedList<int, string>();

            var ws = xS.GetWS("Salesmans");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    smList.Add(dR.Cell(1).GetValue<int>(), dR.Cell(2).Value.ToString());
                }

            }
            Console.WriteLine(JsonConvert.SerializeObject(smList));
            return smList;
        }

        private async System.Threading.Tasks.Task<int> GetSMId(string sname)
        {
            int id= await db.Salesmen.Where(c => c.SalesmanName.Contains( sname)).Select(c => c.SalesmanId).FirstOrDefaultAsync();
            Console.WriteLine($"SM:'{sname}'  id :#{id}");
            return id;

        }

        private async System.Threading.Tasks.Task<SortedDictionary<int, string>> AddDailySalesAsync(SortedList<int, string> smList)
        {
            var ws = xS.GetWS("DailySales");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title
            //DailySaleId	SaleDate	InvNo	Amount	PayMode	CashAmount	SalesmanId	IsDue	IsManualBill	
            //IsTailoringBill	IsSaleReturn	Remarks	IsMatchedWithVOy	EDCTranscationId	MixAndCouponPaymentId	StoreId	UserName
            SortedDictionary<int, string> SaleList = new SortedDictionary<int, string>();
             
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    SaleList.Add(dR.Cell(1).GetValue<int>(), dR.Cell(3).GetValue<string>());
                    DailySale dL = new DailySale
                    {
                        //DailySaleId = dR.Cell(1).GetValue<int>(),
                        SaleDate = dR.Cell(2).GetDateTime(),
                        InvNo = dR.Cell(3).GetValue<string>(),
                        Amount = dR.Cell(4).GetValue<decimal>(),
                        PayMode = dR.Cell(5).GetValue<PayMode>(),
                        CashAmount = dR.Cell(6).GetValue<decimal>(),
                        SalesmanId = dR.Cell(7).GetValue<int>(),
                        IsDue = dR.Cell(8).GetBoolean(),
                        IsManualBill = dR.Cell(9).GetBoolean(),
                        IsTailoringBill = dR.Cell(10).GetBoolean(),
                        IsSaleReturn = dR.Cell(11).GetBoolean(),
                        Remarks = dR.Cell(12).GetValue<string>(),
                        IsMatchedWithVOy = dR.Cell(13).GetBoolean(),
                        //EDCTranscationId = dR.Cell(14).GetValue<int>(),
                        //MixAndCouponPaymentId = dR.Cell(15).GetValue<int>(),
                        StoreId = dR.Cell(16).GetValue<int>(),
                        UserId = dR.Cell(17).GetValue<string>(),
                        EntryStatus = 0,
                        IsReadOnly = true
                    };
                    dL.SalesmanId = await GetSMId(smList.GetValueOrDefault(dL.SalesmanId));
                    Console.WriteLine("SM:# " + dL.SalesmanId);
                    db.DailySales.Add(dL);

                }

            }
            await db.SaveChangesAsync();
            return SaleList;


        }


    }


}