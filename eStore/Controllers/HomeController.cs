﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eStore.Models;
using eStore.BL.Widgets;
using eStore.DL.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using eStore.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using eStore.Ops;


namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly eStoreDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(ILogger<HomeController> logger, eStoreDbContext context, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // Setting Store Info Here
            ViewBag.StoreID = ActiveSession.GetActiveSession(HttpContext.Session, HttpContext.Response, "/Identity/Account/Login?ReturnUrl=/Home/Index");
            MasterViewReport mvr = DashboardWidget.GetMasterViewReport(_context);
            return View(mvr);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestUI()
        {
            return View();
        }
        //public async Task<IActionResult> UpdateDBAsync()
        //{

        //    //int a = 0;// Processor.AddExpLedgerType(_context);
        //    //int b = 0;// Processor.AddPartyList(_context);

        //    //string c = await Processor.ProcessExpensesAsync(_context);
        //    //ViewBag.MessageMe = $"Details: Type={a}   Party={b}  Exp={c} ";

        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> TestUIAsync(IFormFile file)
        //{
        //    if (file.Length > 0)
        //    {
        //        //var filePath = Path.GetTempFileName();
        //        string filename = file.FileName;

        //        string pathToExcelFile = Path.GetTempPath() + filename;
        //        Console.WriteLine(pathToExcelFile);

        //        using (var stream = System.IO.File.Create(pathToExcelFile))
        //        {
        //            await file.CopyToAsync(stream);
                    
        //        }

        //        // TestImport t = new TestImport();
        //        // var data= t.TestImportExcel(_context, pathToExcelFile);
        //        // return  View(data);
        //        DBImport im = new DBImport(_context,_userManager);
        //        bool a= await im.ImportDataAsync(pathToExcelFile);
        //        if (a)
        //        {
        //            ViewBag.Message = "It DOne";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Not Done";
        //        }
        //    }

        //    return View();
        //}
    }
}
