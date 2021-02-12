using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using eStore.DL.Data;
using eStore.Shared.Models.Accounts;
using eStore.Shared.Models.Payroll;
using Newtonsoft.Json;

namespace eStore.BL.Exporter.Database
{
    public class DBImport
    {
        private string PathName = "";
        private readonly string BFolder = "ExcelSheet";
        private string BasePath;
        private eStoreDbContext Db;
        public DBImport(eStoreDbContext context)
        {
            Db = context;
        }

        public bool ImportData(string fileName)
        {
            ImportPayroll iP = new ImportPayroll(Db);
            iP.ReadPayRoll(fileName);
            return true;
        }

    }

    class EmpCodes
    {
        public int OldId { get; set; }
        public int NewId { get; set; }
        public string StaffName { get; set; }
        public int PartyId { get; set; }

    }
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
           var id= db.Employees.Where(c => (c.FirstName+" " + c.LastName) == Name).Select(c=>c.EmployeeId).FirstOrDefault();
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
                    if (xId>0)
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
                            Console.WriteLine("Error: " + ex.Message);

                            Console.WriteLine($"SN: {dR.Cell(2).Value.ToString()}");

                            Console.WriteLine($"DOB: {dR.Cell(10).Value.ToString()}");
                            Console.WriteLine($"LD: {dR.Cell(5).Value.ToString()}");
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
                    catch(Exception e)
                    {
                        Console.WriteLine("EX: " + e.Message);
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
            if (id > 0) {
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
    }


    class TestImport
    {
        public DataTable TestImportExcel(eStoreDbContext db, string fileName)
        {
            Console.WriteLine(fileName);
            XSReader xS = new XSReader(fileName);

            var ws = xS.GetWS("Employees");
            var dt = XSReader.ReadSheetToDt(ws, 6);
            int c = dt.Columns.IndexOf("UserName");
            dt.Columns[c].ColumnName = "UserId";
            dt.Columns.Add("EntryStatus");
            dt.Columns.Add("IsReadOnly");
            int c1 = 101;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["EntryStatus"] = EntryStatus.Added;
                dt.Rows[i]["IsReadOnly"] = true;
                dt.Rows[i][0] = ((i + 1 * 201) * c1 / 3) * i;
                c1 = c1 + new Random(c1).Next();
            }
            dt.AcceptChanges();
            //JsonConvert.SerializeObject(dt);
            //
            var lst = CommonMethod.ConvertToList<Employee>(dt);
            //var lst = DAL.CreateListFromTable<Employee>(dt);
            db.Employees.AddRange(lst);
            Console.WriteLine(JsonConvert.SerializeObject(dt));
            Console.WriteLine("Save: " + db.SaveChanges());


            return dt;

        }
    }


}
