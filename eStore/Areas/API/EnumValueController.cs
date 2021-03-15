using eStore.BL.DataHelpers;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
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
        [HttpGet]
        [Route("ledgercategorytype/all")]
        public ActionResult GetLedgerCategoryType()
        {
            return Ok(EnumExtensions.GetValues<LedgerCategory>());
        }

        [HttpGet]
        [Route("taxtype/all")]
        public ActionResult GetTaxType()
        {
            return Ok(EnumExtensions.GetValues<TaxType>());
        }
        [HttpGet]
        [Route("genders/all")]
        public ActionResult GetGenders()
        {
            return Ok(EnumExtensions.GetValues<Gender>());
        }
        [HttpGet]
        [Route("connectiontype/all")]
        public ActionResult GetConnectionType()
        {
            return Ok(EnumExtensions.GetValues<ConnectionType>());
        }
        [HttpGet]
        [Route("renttype/all")]
        public ActionResult GetRentType()
        {
            return Ok(EnumExtensions.GetValues<RentType>());
        }

        [HttpGet]
        [Route("units/all")]
        public ActionResult GetUnits()
        {
            return Ok(EnumExtensions.GetValues<Unit>());
        }


        [HttpGet]
        [Route("sizes/all")]
        public ActionResult GetSizes()
        {
            return Ok(EnumExtensions.GetValues<Size>());
        }

        [HttpGet]
        [Route("productcategory/all")]
        public ActionResult GetProductCategory()
        {
            return Ok(EnumExtensions.GetValues<ProductCategory>());
        }

        [HttpGet]
        [Route("entrystatus/all")]
        public ActionResult GetEntryStatus()
        {
            return Ok(EnumExtensions.GetValues<EntryStatus>());
        }


        [HttpGet]
        [Route("cardmodes/all")]
        public ActionResult GetCardModes()
        {
            return Ok(EnumExtensions.GetValues<CardMode>());
        }
        [HttpGet]
        [Route("cardtype/all")]
        public ActionResult GetCardType()
        {
            return Ok(EnumExtensions.GetValues<CardType>());
        }

        [HttpGet]
        [Route("vpaymode/all")]
        public ActionResult GetVPayMode()
        {
            return Ok(EnumExtensions.GetValues<VPayMode>());
        }


        [HttpGet]
        [Route("salarycomponets/all")]
        public ActionResult GetSalaryComponets()
        {
            return Ok(EnumExtensions.GetValues<SalaryComponet>());
        }

        [HttpGet]
        [Route("bankpaymode/all")]
        public ActionResult GetBankPayModes()
        {
            return Ok(EnumExtensions.GetValues<BankPayMode>());
        }

        [HttpGet]
        [Route("mixpaymode/all")]
        public ActionResult GetMixPayMode()
        {
            return Ok(EnumExtensions.GetValues<MixPaymentMode>());
        }

        [HttpGet]
        [Route("vochertype/all")]
        public ActionResult GetVoucherType()
        {
            return Ok(EnumExtensions.GetValues<VoucherType>());
        }

        [HttpGet]
        [Route("loginrole/all")]
        public ActionResult GetLoginRoles()
        {
            return Ok(EnumExtensions.GetValues<LoginRole>());
        }

        [HttpGet]
        [Route("arvindaccounts/all")]
        public ActionResult GetArvindAccounts()
        {
            return Ok(EnumExtensions.GetValues<ArvindAccount>());
        }
    }
}
