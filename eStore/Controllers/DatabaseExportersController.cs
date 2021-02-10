using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using eStore.BL.Exporter.Database;
using eStore.ImportDatabase.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class DatabaseExportersController : Controller
    {
        private AprajitaRetailsDbContext _db;
        private IWebHostEnvironment Environment;
        public DatabaseExportersController(AprajitaRetailsDbContext context, IWebHostEnvironment _environment)
        {
            _db = context;
            Environment = _environment;
        }
        // GET: DatabaseExporters
        public ActionResult Index()
        {
            return View();
        }

        // GET: DatabaseExporters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DatabaseExporters/Create
        public IActionResult DownloadAsZip(int? id)
        {
            AprajitaRetailsDBExport dm = new AprajitaRetailsDBExport(_db, this.Environment.WebRootPath);
            string fileName = "";
            if (id==1)
             fileName = dm.DownloadFirstToExcell();
            else if (id == 2)
                fileName = dm.DownloadSecondToExcel();
            else if (id == 2)
                fileName = dm.DownloadThirdToExcel();
            return File(fileName, "application/zip", "StoreDB.zip");
        }
        
        // POST: DatabaseExporters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DatabaseExporters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatabaseExporters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DatabaseExporters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatabaseExporters/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}