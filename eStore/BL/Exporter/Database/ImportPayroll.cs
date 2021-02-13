using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;
using eStore.Shared.Models.Payroll;

namespace eStore.BL.Exporter.Database
{
    class ImportPayroll
    {
        private XSReader xS;
        private List<EmpCodes> EmpRecord;
        private int SalaryLedgerID = 0;
        private eStoreDbContext db;

        public ImportPayroll(eStoreDbContext context)
        {
            db = context;
        }

        public void ReadPayRoll(string fileName)
        {
            xS = new XSReader(fileName);

            if (xS.WorkBookName == "PayRoll")
            {
                db.Attendances.RemoveRange(db.Attendances);
                db.SalaryPayments.RemoveRange(db.SalaryPayments);
                db.Employees.RemoveRange(db.Employees);

                db.SaveChanges();


                AddEmployees(xS.GetWS("Employees"));
                AddAllSheet();
                AddCurrentSalar(xS.GetWS("CurrentSalaries"));

            }
            else
            {
                throw new Exception();
            }

        }

        private int AddOrGetEmployeeLedger()
        {
            var ID = db.LedgerTypes.Where(c => c.LedgerNameType == "Salary").Select(c => c.LedgerTypeId).FirstOrDefault();
            if (ID != null && ID <= 0)
            {
                LedgerType Lt = new LedgerType
                {
                    LedgerNameType = "Salary",
                    Remark = "For Employees",
                    Category = LedgerCategory.Expenses
                };
                db.LedgerTypes.Add(Lt);
                db.SaveChanges();
                return Lt.LedgerTypeId;
            }
            else return ID;


        }

        private int IsEmpExsits(string Name)
        {
            var id = db.Employees.Where(c => (c.FirstName + " " + c.LastName) == Name).Select(c => c.EmployeeId).FirstOrDefault();
            return id;

        }

        private void AddEmployees(IXLWorksheet ws)
        {

            var nonEmptyDataRows = ws.RowsUsed();

            int Row = 6;//Title;

            this.SalaryLedgerID = AddOrGetEmployeeLedger();
            List<Employee> empList = new List<Employee>();
            EmpRecord = new List<EmpCodes>();
            foreach (var dR in nonEmptyDataRows)
            {
                //for row number check
                if (dR.RowNumber() > Row)
                {
                    //EmployeeId	StaffName	MobileNo	JoiningDate	LeavingDate	IsWorking	Category	IsTailors	EMail	DateOfBirth
                    //AdharNumber	PanNo	OtherIdDetails	Address	City	State	FatherName	HighestQualification	StoreId	UserName

                    var name1 = dR.Cell(2).Value.ToString();

                    EmpCodes codes = new EmpCodes
                    {
                        OldId = dR.Cell(1).GetValue<int>(),
                        StaffName = dR.Cell(2).Value.ToString(),

                    };
                    var xId = IsEmpExsits(name1);
                    if (xId > 0)
                    {
                        codes.NewId = xId;
                        codes.PartyId = AddOrGetParty(xId);
                    }
                    else
                    {
                        var name = name1.Split(" ");
                        var FName = name[0];
                        var LName = "";
                        for (int i = 1; i < name.Length; i++)
                        {
                            LName = LName + name[i] + " ";

                        }
                        Employee emp = new Employee
                        {
                            FirstName = FName,
                            LastName = LName,
                            EntryStatus = 0,
                            IsReadOnly = true,
                            MobileNo = dR.Cell(3).Value.ToString(),
                            JoiningDate = dR.Cell(4).GetDateTime().Date,
                            IsWorking = dR.Cell(6).GetBoolean(),
                            Category = dR.Cell(7).GetValue<EmpType>(),
                            IsTailors = dR.Cell(8).GetBoolean(),
                            EMail = dR.Cell(9).Value.ToString(),
                            AdharNumber = dR.Cell(11).Value.ToString(),
                            PanNo = dR.Cell(12).Value.ToString(),
                            OtherIdDetails = dR.Cell(13).Value.ToString(),
                            Address = dR.Cell(14).Value.ToString(),
                            City = dR.Cell(15).Value.ToString(),
                            State = dR.Cell(16).Value.ToString(),
                            FatherName = dR.Cell(17).Value.ToString(),
                            HighestQualification = dR.Cell(18).Value.ToString(),
                            StoreId = dR.Cell(19).GetValue<int>(),
                            UserId = dR.Cell(20).Value.ToString()


                        };
                        try
                        {
                            emp.LeavingDate = (DateTime?)dR.Cell(5).GetDateTime().Date ?? null;
                            emp.DateOfBirth = (DateTime?)dR.Cell(10).GetDateTime().Date ?? new DateTime(1947, 07, 15).Date;

                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine("Error: " + ex.Message);

                            //Console.WriteLine($"SN: {dR.Cell(2).Value.ToString()}");

                            //Console.WriteLine($"DOB: {dR.Cell(10).Value.ToString()}");
                            //Console.WriteLine($"LD: {dR.Cell(5).Value.ToString()}");
                        }
                        db.Employees.Add(emp);
                        db.SaveChanges();
                        codes.NewId = emp.EmployeeId;
                        codes.PartyId = AddOrGetParty(emp);


                    }


                    EmpRecord.Add(codes);
                }
            }

        }

        private void AddAllSheet()
        {
            foreach (var item in EmpRecord)
            {
                AddAttendence(xS.GetWS("Att_" + item.StaffName), item.NewId);
                AddSalaryPayment(xS.GetWS("Sal_" + item.StaffName), item.NewId, item.PartyId);
            }

        }

        private void AddAttendence(IXLWorksheet ws, int EmpId)
        {

            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 9;//Title;
            List<Attendance> attList = new List<Attendance>();
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    //AttendanceId	EmployeeId	AttDate	EntryTime	Status	Remarks	IsTailoring	StoreId	UserName

                    Attendance att = new Attendance
                    {
                        EmployeeId = EmpId,
                        EntryStatus = 0,
                        IsReadOnly = true,
                        AttDate = dR.Cell(3).GetDateTime(),
                        EntryTime = dR.Cell(4).Value.ToString(),
                        Status = dR.Cell(5).GetValue<AttUnit>(),
                        Remarks = dR.Cell(6).Value.ToString(),
                        StoreId = dR.Cell(8).GetValue<int>(),
                        UserId = dR.Cell(9).Value.ToString(),
                    };

                    try
                    {
                        att.IsTailoring = (bool?)dR.Cell(7).GetBoolean() ?? false;

                    }
                    catch (Exception e)
                    {
                        // Console.WriteLine("EX: " + e.Message);
                        att.IsTailoring = false;
                    }
                    attList.Add(att);
                }
            }
            db.Attendances.AddRange(attList);
            db.SaveChanges();
        }

        private void AddSalaryPayment(IXLWorksheet ws, int EmpId, int PartyId)
        {
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 9;//Title;
            List<SalaryPayment> SalList = new List<SalaryPayment>();
            foreach (var dR in nonEmptyDataRows)
            {
                if (dR.RowNumber() > Row)
                {
                    //SalaryPaymentId	EmployeeId	SalaryMonth	SalaryComponet	PaymentDate	Amount	PayMode	Details	StoreId	UserName

                    SalaryPayment salary = new SalaryPayment
                    {
                        EmployeeId = EmpId,
                        EntryStatus = 0,
                        IsReadOnly = true,
                        PartyId = PartyId,

                        SalaryMonth = dR.Cell(3).Value.ToString(),
                        SalaryComponet = dR.Cell(4).GetValue<SalaryComponet>(),
                        PaymentDate = dR.Cell(5).GetDateTime(),

                        Amount = dR.Cell(6).GetValue<decimal>(),
                        PayMode = dR.Cell(7).GetValue<PayMode>(),
                        Details = dR.Cell(8).Value.ToString(),
                        StoreId = dR.Cell(9).GetValue<int>(),
                        UserId = dR.Cell(10).Value.ToString(),

                    };
                    SalList.Add(salary);
                }
            }
            db.SalaryPayments.AddRange(SalList);
            db.SaveChanges();

        }


        private int AddOrGetParty(int empID)
        {
            var PName = "EMP# " + db.Employees.Find(empID).StaffName;

            var id = db.Parties.Where(c => c.PartyName == PName).Select(c => c.PartyId).FirstOrDefault();
            if (id > 0)
            {
                return id;
            }
            else
            {
                var emp = db.Employees.Find(empID);
                Party party = new Party
                {
                    Address = emp.Address,
                    GSTNo = "",
                    OpenningDate = emp.JoiningDate,
                    PartyName = "EMP# " + emp.StaffName,
                    OpenningBalance = (decimal)0,
                    PANNo = "",
                    LedgerTypeId = this.SalaryLedgerID
                };
                db.Parties.Add(party);
                db.SaveChanges();
                return party.PartyId;

            }
        }
        private int AddOrGetParty(Employee emp)
        {
            var PName = "EMP# " + emp.StaffName;
            var id = db.Parties.Where(c => c.PartyName == PName).Select(c => c.PartyId).FirstOrDefault();
            if (id > 0)
            {
                return id;
            }
            else
            {
                Party party = new Party
                {
                    Address = emp.Address,
                    GSTNo = "",
                    OpenningDate = emp.JoiningDate,
                    PartyName = "EMP# " + emp.StaffName,
                    OpenningBalance = (decimal)0,
                    PANNo = "",
                    LedgerTypeId = this.SalaryLedgerID
                };
                db.Parties.Add(party);
                db.SaveChanges();
                return party.PartyId;

            }
        }

        private void AddCurrentSalar(IXLWorksheet ws)
        {
            var nonEmptyDataRows = ws.RowsUsed();
            int Row = 6;//Title;
            List<CurrentSalary> salLst = new List<CurrentSalary>();
            foreach (var dR in nonEmptyDataRows)
            {
                //for row number check
                if (dR.RowNumber() > Row)
                {

                    CurrentSalary sal = new CurrentSalary
                    {
                        CurrentSalaryId = dR.Cell(1).GetValue<int>(),
                        IsReadOnly = true,
                        EntryStatus = 0,
                        BasicSalary = dR.Cell(3).GetValue<decimal>(),
                        LPRate = dR.Cell(4).GetValue<decimal>(),
                        IncentiveRate = dR.Cell(5).GetValue<decimal>(),
                        IncentiveTarget = dR.Cell(6).GetValue<decimal>(),
                        WOWBillRate = dR.Cell(7).GetValue<decimal>(),
                        WOWBillTarget = dR.Cell(8).GetValue<decimal>(),
                        IsFullMonth = dR.Cell(9).GetBoolean(),
                        IsSundayBillable = dR.Cell(10).GetBoolean(),
                        EffectiveDate = dR.Cell(11).GetDateTime().Date,
                        IsEffective = dR.Cell(13).GetBoolean(),
                        IsTailoring = dR.Cell(14).GetBoolean(),
                        UserId = "Admin",

                    };

                    try
                    {
                        sal.EmployeeId = EmpRecord.Where(c => c.OldId == dR.Cell(2).GetValue<int>()).Select(c => c.NewId).FirstOrDefault();
                        sal.CloseDate = (DateTime?)dR.Cell(12).GetDateTime().Date ?? null;
                    }
                    catch (Exception)
                    {
                    }

                    salLst.Add(sal);

                }
            }
            db.Salaries.AddRange(salLst);
            db.SaveChanges();


        }
    }


}
