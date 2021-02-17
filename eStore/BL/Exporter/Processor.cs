using System;
using System.Collections.Generic;
using System.Linq;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;
using Microsoft.EntityFrameworkCore;

namespace eStore.BL.Exporter
{
    public class Processor
    {
        private void GetOrAddParty()
        {

        }

        private static int GetPartyId(eStoreDbContext db, string PName)
        {
          return  db.Parties.Where(c => c.PartyName.Contains(PName)).Select(c => c.PartyId).FirstOrDefault();
        }

        public static int AddExpLedgerType(eStoreDbContext db)
        {
            string[] lists = { "Electricity", "Postage", "HomeExpenses", "Out of Store", "Assests", "Freight", "Serivces", "Tax & Duties" };
            foreach (var item in lists)
            {
                LedgerType lt = new LedgerType {
                    LedgerNameType=item, Remark=item, Category=LedgerCategory.Expenses
                };
                db.LedgerTypes.Add(lt);

            }
          return  db.SaveChanges();

        }

        public static int AddPartyList(eStoreDbContext db)
        {
            foreach (var item in Head)
            {

                Party p = new Party
                {
                    Address = "Dumka",
                    PartyName=item, OpenningDate=DateTime.Today, OpenningBalance=0,
                    LedgerTypeId=7
                };

                db.Parties.Add(p);
            }
          return  db.SaveChanges();
        }

        private static List<string> Head = new List<string> { "maa bhawani art","painter","store renovation cost","telephone",
             "Store Renovation", "CityNet",  "Electrician",    "Painter","Raj Mistry",    "Kite","Workshop","workshop","Repair & Maintenance",
             "Bikash Patwari",   "Ajay Electricals",   "Singhania Senitries",   "Scientific emporium",
             "Anup Sharma(grill shop)",   "Shop Electricity Bill",    "Prince Tailoring Materials", "R.S Enterprises",
             "Freight charge",  "Tailoring trims expences", "Tailoring trims expenses", "Telephone Bill",  "Bhutu Mistry",  "Glass House" ,"water"       };

        public static async System.Threading.Tasks.Task<string> ProcessExpensesAsync(eStoreDbContext db)
        {
            string Message = "";

            int PartyId = 0;
            int TotalUpdate = 0;

            var exps = await db.Expenses.Where(c => c.PartyName.Contains("KITES") && c.PartyId == null).ToListAsync();
            PartyId = GetPartyId(db, "Kites");
            foreach (var e in exps)
            {

                e.PartyId = PartyId;
                e.EntryStatus = EntryStatus.Updated;
                db.Expenses.Update(e);
            }
            PartyId = 0;
             exps = await db.Expenses.Where(c => c.Particulars.Contains("water") && c.PartyId == null).ToListAsync();
            PartyId = GetPartyId(db, "Kites");
            foreach (var e in exps)
            {

                e.PartyId = PartyId;
                e.EntryStatus = EntryStatus.Updated;
                db.Expenses.Update(e);
            }
            PartyId = 0;
            TotalUpdate += db.SaveChanges();

            foreach (var h in Head)
            {

                if (h == "maa bhawani art")
                    PartyId = GetPartyId(db, "Maa Bhawani Art");
                else if (h == "painter")
                    PartyId = GetPartyId(db, "Painter");
                else if (h == "store renovation cost")
                    PartyId = GetPartyId(db, "Store Renovation");
                else if (h == "telephone")
                    PartyId = GetPartyId(db, "Telephone Bill");
                

                else if (h == "Kites")
                {
                    var exp1 = await db.Expenses.Where(c => c.Particulars.Contains("water") && c.PartyId==null).ToListAsync();

                    foreach (var e in exp1)
                    {
                        
                        e.PartyId = PartyId;
                        e.EntryStatus = EntryStatus.Updated;
                        db.Expenses.Update(e);
                    }
                    PartyId = 0;
                }
                else
                    PartyId = GetPartyId(db, h);

                if (PartyId > 0)
                {
                    var exp = await db.Expenses.Where(c => c.Particulars.ToLower().Contains(h.ToLower()) && c.PartyId == null).ToListAsync();
                    foreach (var e in exp)
                    {
                        e.PartyId = PartyId;
                        e.EntryStatus = EntryStatus.Updated;
                        db.Expenses.Update(e);
                    }
                    PartyId = 0;
                    TotalUpdate += db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("PartyName: " + h);
                    Message += "PartyName: " + h;
                }
               
            }

            var exp12 = await db.Expenses.Where(c=>c.PartyId == null).ToListAsync();
            foreach (var e in exp12)
            {
                e.PartyId = 43;
                e.EntryStatus = EntryStatus.Updated;
                db.Expenses.Update(e);
            }
            TotalUpdate += db.SaveChanges();
            Message += "    #Total Update: " + TotalUpdate;
            return Message;

        }
    }
}

/*
 * battery water
 * 
 maa bhawani art
 store renovation cost
 CityNet(Internet)
 Electrician
 painter
 Raj Mistry
 water can
 workshop
 Bikash Patwari
 Ajay Electricals
 Singhania Senitries
 Scientific emporium
 Anup Sharma(grill shop)
 Shop Electricity Bill
 Prince Tailoring Materials
 R.S Enterprises
 Freight charge
 Tailoring trims expences
 Telephone Bill
 Bhutu Mistry
 Glass House
 */