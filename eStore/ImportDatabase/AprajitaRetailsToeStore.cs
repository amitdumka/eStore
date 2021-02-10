using System;
using System.Collections.Generic;
using System.Linq;
using eStore.DL.Data;
using eStore.ImportDatabase.Data;
using eStore.Shared.Models.Payroll;
using Microsoft.EntityFrameworkCore;

namespace eStore.ImportDatabase
{
    public class AprajitaRetailsToeStore : BasicFunctions
    {
        public void ImportPayRollData()
        {


        }
    }

    public class BasicFunctions
    {
        protected eStoreDbContext outDB; AprajitaRetailsDbContext inDB;
        protected async System.Threading.Tasks.Task GetEmployeeDataAsync()
        {
            var inEmpList = await inDB.Employees.ToListAsync();

            List<eStore.Shared.Models.Payroll.Employee> OutEmpList = new List<Shared.Models.Payroll.Employee>();
            foreach (var inEmp in inEmpList)
            {
           
                List<Attendance> outAttList = new List<Attendance>();
                var inAttList = await inDB.Attendances.Where(c => c.EmployeeId == inEmp.EmployeeId).ToListAsync();
                foreach (var inAtt in inAttList)
                {
                    Attendance outAtt = new Attendance
                    {
                        StoreId = (int?) inAtt.StoreId ?? 1,
                        AttDate = inAtt.AttDate,
                        EntryStatus = 0,
                        IsReadOnly = false,
                        EntryTime = inAtt.EntryTime,
                        IsTailoring = (bool?)inAtt.IsTailoring??false,
                        Remarks = inAtt.Remarks,
                        Status = inAtt.Status,
                        UserId = "Admin"
                    };
                    outAttList.Add(outAtt);
                }
                Employee outEmp = new Employee
                {
                    StoreId = (int?)inEmp.StoreId??1,
                    Attendances=outAttList, UserId="Admin", IsReadOnly =false, State=inEmp.State,
                    Address=inEmp.Address, AdharNumber=inEmp.AdharNumber, Category=inEmp.Category , City=inEmp.City,
                    DateOfBirth=(DateTime)inEmp.DateOfBirth, EMail=inEmp.EMail, EntryStatus=0, FatherName=inEmp.FatherName,
                    FirstName=inEmp.StaffName, HighestQualification=inEmp.HighestQualification, PanNo=inEmp.PanNo,
                    OtherIdDetails=inEmp.OtherIdDetails, IsTailors=inEmp.IsTailors, MobileNo=inEmp.MobileNo, LastName="",
                    LeavingDate=inEmp.LeavingDate, IsWorking=inEmp.IsWorking, JoiningDate=inEmp.JoiningDate

                };

            }

        }
    }
}
