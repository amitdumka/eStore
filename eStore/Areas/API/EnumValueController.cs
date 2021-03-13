using eStore.BL.DataHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Areas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumValueController : ControllerBase
    {

        [HttpGet]
        [Route("accounttype/all")]
        public ActionResult GetAccountTypeLevels()
        {
            return Ok(EnumExtensions.GetValues<AccountType>());
        }

        [HttpGet]
        [Route("paymentmode/all")]
        public ActionResult GetPaymentModeTypes()
        {
            return Ok(EnumExtensions.GetValues<PaymentMode>());
        }
        [HttpGet]
        [Route("paymode/all")]
        public ActionResult GetPayModeTypes()
        {
            return Ok(EnumExtensions.GetValues<PayMode>());
        }

        [HttpGet]
        [Route("attendanceunit/all")]
        public ActionResult GetAttendanceTypes()
        {
            return Ok(EnumExtensions.GetValues<AttUnit>());
        }

        [HttpGet]
        [Route("employeetype/all")]
        public ActionResult GetEmployeeTypes()
        {
            return Ok(EnumExtensions.GetValues<EmpType>());
        }

        [HttpGet]
        [Route("ledgerentrytype/all")]
        public ActionResult GetLedgerEntryType()
        {
            return Ok(EnumExtensions.GetValues<LedgerEntryType>());
        }
    }
}
