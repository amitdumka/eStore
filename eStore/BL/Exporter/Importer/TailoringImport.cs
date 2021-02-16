using System;
using System.Collections.Generic;
using System.Linq;
using eStore.BL.Exporter.Database;
using eStore.DL.Data;
using eStore.Shared.Models.Tailoring;
using Microsoft.EntityFrameworkCore;

namespace eStore.BL.Exporter.Importer
{
    public class TailoringImport
    {
        private XSReader xS;
        private eStoreDbContext db;

        public TailoringImport(eStoreDbContext dbContext)
        {
            db = dbContext;
        }

        public async System.Threading.Tasks.Task ReadAsync(string fileName)
        {
            xS = new XSReader(fileName);

            if (xS.WorkBookName == "Tailoring")
            {
                await AddDeliveryAsyncs(await AddBookingAsync());
            }
            else
            {
                throw new Exception();
            }

        }
        public async System.Threading.Tasks.Task ReadAsync(XSReader ixs)
        {
            xS = ixs;

            if (xS.WorkBookName == "Tailoring")
            {

                await AddDeliveryAsyncs(await AddBookingAsync());
            }
            else
            {
                throw new Exception();
            }

        }

        private async System.Threading.Tasks.Task<int> GetIDAsync(string slip)
        {
            return await db.TalioringBookings.Where(c => c.BookingSlipNo == slip).Select(c => c.TalioringBookingId).FirstOrDefaultAsync();
        }
        private async System.Threading.Tasks.Task<SortedList<int, string>> AddBookingAsync()
        {
            // TalioringBookingId BookingDate CustName DeliveryDate    TryDate BookingSlipNo   TotalAmount TotalQty    ShirtQty ShirtPrice
            // PantQty PantPrice   CoatQty CoatPrice   KurtaQty KurtaPrice  BundiQty BundiPrice  Others OthersPrice IsDelivered StoreId
            // UserName

            var ws = xS.GetWS("Bookings");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            SortedList<int, string> list = new SortedList<int, string>();
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    list.Add(dR.Cell(1).GetValue<int>(), dR.Cell(6).Value.ToString());
                    TalioringBooking book = new TalioringBooking
                    {
                        IsReadOnly = true,
                        EntryStatus = 0,
                        BookingDate = dR.Cell(2).GetDateTime(),
                        CustName = dR.Cell(3).GetValue<string>(),
                        DeliveryDate = dR.Cell(4).GetDateTime(),
                        TryDate = dR.Cell(5).GetDateTime(),
                        BookingSlipNo = dR.Cell(6).Value.ToString(),
                        TotalAmount = dR.Cell(7).GetValue<decimal>(),
                        TotalQty = dR.Cell(8).GetValue<int>(),
                        ShirtQty = dR.Cell(9).GetValue<int>(),
                        ShirtPrice = dR.Cell(10).GetValue<decimal>(),

                        PantQty = dR.Cell(11).GetValue<int>(),
                        PantPrice = dR.Cell(12).GetValue<decimal>(),

                        CoatQty = dR.Cell(13).GetValue<int>(),
                        CoatPrice = dR.Cell(14).GetValue<decimal>(),

                        KurtaQty = dR.Cell(15).GetValue<int>(),
                        KurtaPrice = dR.Cell(16).GetValue<decimal>(),

                        BundiQty = dR.Cell(17).GetValue<int>(),
                        BundiPrice = dR.Cell(18).GetValue<decimal>(),

                        Others = dR.Cell(19).GetValue<int>(),
                        OthersPrice = dR.Cell(20).GetValue<decimal>(),
                        IsDelivered = dR.Cell(21).GetBoolean(),
                        StoreId = 1,//dR.Cell(22).GetValue<int>(),
                        UserId = dR.Cell(23).GetValue<string>()


                    };
                    await db.TalioringBookings.AddAsync(book);
                }
            }

            await db.SaveChangesAsync();
            return list;
        }
        private async System.Threading.Tasks.Task AddDeliveryAsyncs(SortedList<int, string> IDList)
        {
            //ContactId	FirstName	LastName	MobileNo	PhoneNo	EMailAddress	Remarks	UserName

            var ws = xS.GetWS("Deliveries");
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    //TalioringDeliveryId	DeliveryDate	TalioringBookingId	InvNo	Amount	Remarks	StoreId	UserName

                    TalioringDelivery del = new TalioringDelivery
                    {

                        DeliveryDate = dR.Cell(2).GetDateTime(),
                        TalioringBookingId = await GetIDAsync(IDList.GetValueOrDefault(dR.Cell(3).GetValue<int>())),
                        InvNo = dR.Cell(4).GetValue<string>(),
                        Amount = dR.Cell(5).GetValue<decimal>(),
                        Remarks = dR.Cell(6).GetValue<string>(),
                        StoreId = 1,
                        //StoreId=dR.Cell(7).GetValue<int>(),
                        UserId = dR.Cell(8).Value.ToString(),
                        IsReadOnly = true,
                        EntryStatus = 0
                    };

                    await db.TailoringDeliveries.AddAsync(del);
                }
            }

            await db.SaveChangesAsync();
        }

    }
}
