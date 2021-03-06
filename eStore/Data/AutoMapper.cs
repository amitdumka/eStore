using AutoMapper;
using eStore.Shared.DTOs.Payrolls;
using eStore.Shared.Models.Payroll;
using eStore.Shared.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

           
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<Employee, EmployeeBasicDto>();
            CreateMap<Store, StoreBasicDto>();
            CreateMap<StoreBasicDto, Store>();

            CreateMap<PaySlip, PaySlipDto>();
            CreateMap<StaffAdvanceReceipt, StaffAdvanceReceiptDto>();
            CreateMap<SalaryPayment, SalaryPaymentDto>();
            CreateMap<CurrentSalary, CurrentSalaryDto>();


            CreateMap<EmployeeDto, Employee>();
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<PaySlipDto, PaySlip>();
            CreateMap<StaffAdvanceReceiptDto, StaffAdvanceReceipt>();
            CreateMap<SalaryPaymentDto, SalaryPayment>();
            CreateMap<CurrentSalaryDto, CurrentSalary>();
           
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
