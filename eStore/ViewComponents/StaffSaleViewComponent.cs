﻿using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using eStore.DL.Data;
using eStore.Shared.ViewModels;

namespace eStore.ViewComponents
{
    [ViewComponent(Name = "staffsale")]
    public class StaffSaleViewComponent : ViewComponent
    {
        private readonly eStoreDbContext db;

        public StaffSaleViewComponent(eStoreDbContext con)
        {
            db = con;
        }

        public StaffSale GetStaffSaleData()
        {
            // var emp = db.Employees.Where (c => c.Category == EmpType.Salesman && c.IsWorking).Select (c => new { c.EmployeeId, c.StaffName }).OrderBy(c=>c.EmployeeId).ToList ();

            var yearly = db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year ).GroupBy(a => a.SalesmanId).Select(a => new { Amount = a.Sum(b => (long)b.Amount), EmpId = a.Key }).OrderByDescending(a => a.EmpId).ToList();
            var montly = db.DailySales.Where(c => c.SaleDate.Year == DateTime.Today.Year && c.SaleDate.Month == DateTime.Today.Month).GroupBy(a => a.SalesmanId).Select(a => new { Amount = a.Sum(b => (long)b.Amount), EmpId = a.Key }).OrderByDescending(a => a.EmpId).ToList();
            var today = db.DailySales.Where(c => c.SaleDate == DateTime.Today ).GroupBy(a => a.SalesmanId).Select(a => new { Amount = a.Sum(b => (long)b.Amount), EmpId = a.Key }).OrderByDescending(a => a.EmpId).ToList();

            StaffSale saleInfo = new StaffSale();
            List<int> StaffId = new List<int>();

            //TODO: Add to index based on EmpId. 
            foreach (var item in yearly)
            {
                saleInfo.YearWise.Add((int)item.Amount);
                StaffId.Add(item.EmpId);
                Console.WriteLine($"Yearly #Id: {item.EmpId}  @Amount: {item.Amount}");
            }
            foreach (var item in montly)
            {
                saleInfo.MonthWise.Add((int)item.Amount);
                StaffId.Add(item.EmpId);
                Console.WriteLine($"Month #Id: {item.EmpId}  @Amount: {item.Amount}");
            }
            foreach (var item in today)
            {
                saleInfo.CurrentWise.Add((int)item.Amount);
                StaffId.Add(item.EmpId);
                Console.WriteLine($"Today #Id: {item.EmpId}  @Amount: {item.Amount}");
            }

            if (StaffId.Count == (yearly.Count + today.Count + montly.Count))
            {
                StaffId = StaffId.Distinct().ToList();
            }
            else
            {
                Console.WriteLine("Not Distinct");
                StaffId = StaffId.Distinct().ToList();
            }

            foreach (var item in StaffId)
            {

                string name = db.Salesmen.Find(item).SalesmanName;
                saleInfo.StaffName.Add(name);

            }



            return saleInfo;
        }

        public IViewComponentResult Invoke()
        {
            //  var chart = JsonConvert.DeserializeObject<ChartJs> (chartData);

            Ticks ticks = new Ticks { beginAtZero = true };
            Yax yax = new Yax { ticks = ticks };
            Yax[] y = new Yax[1];
            y[0] = yax;
            Scales scales = new Scales();
            scales.yAxes = y;

            Data data = new Data();

            StaffSale saleData = GetStaffSaleData();

            Dataset datasetY = new Dataset
            {
                borderWidth = 1,
                label = "Yearly",
                data = saleData.YearWise.ToArray(),
                backgroundColor = new string[]{
                    "rgba(255, 99, 132, 0.2)",
                    "rgba(54, 162, 235, 0.2)",
                    "rgba(255, 206, 86, 0.2)",
                    "rgba(75, 192, 192, 0.2)",
                    "rgba(153, 102, 255, 0.2)",
                    "rgba(54, 162, 235, 0.2)",
                    "rgba(255, 203, 83, 0.2)",
                    "rgba(255, 159, 64, 0.2)",
                    //"rgba(255, 99, 132, 0.2)",
                    //"rgba(54, 162, 235, 0.2)",
                    //"rgba(255, 206, 86, 0.2)",
                    //"rgba(75, 192, 192, 0.2)",
                },
                borderColor = new string[] {
                    "rgba(255, 99, 132, 1)",
                    "rgba(54, 162, 235, 1)",
                    "rgba(255, 206, 86, 1)",
                    "rgba(75, 192, 192, 1)",
                    "rgba(153, 102, 255, 1)",
                    "rgba(255, 203, 83, 1)",
                    "rgba(255, 159, 64, 1)",
                    "rgba(255, 99, 132, 1)",
                    //"rgba(54, 162, 235, 1)",
                    //"rgba(255, 206, 86, 1)",
                    //"rgba(75, 192, 192, 1)",
                    //"rgba(153, 102, 255, 1)",
                }
            };
            Dataset datasetM = new Dataset
            {
                borderWidth = 1,
                label = "Monthly",
                data = saleData.MonthWise.ToArray(),
                backgroundColor = new string[]{
                   // "rgba(255, 99, 132, 0.2)",
                   // "rgba(54, 162, 235, 0.2)",
                   // "rgba(255, 206, 86, 0.2)",
                    "rgba(75, 192, 192, 0.2)",
                    "rgba(153, 102, 255, 0.2)",
                    "rgba(54, 162, 235, 0.2)",
                    "rgba(255, 203, 83, 0.2)",
                   // "rgba(255, 159, 64, 0.2)",
                  //  "rgba(255, 99, 132, 0.2)",
                    "rgba(54, 162, 235, 0.2)",
                    "rgba(255, 206, 86, 0.2)",
                    //"rgba(75, 192, 192, 0.2)",
                },
                borderColor = new string[] {
                   // "rgba(255, 99, 132, 1)",
                   // "rgba(54, 162, 235, 1)",
                   // "rgba(255, 206, 86, 1)",
                    "rgba(75, 192, 192, 1)",
                    "rgba(153, 102, 255, 1)",
                    "rgba(255, 203, 83, 1)",
                    "rgba(255, 159, 64, 1)",
                    //"rgba(255, 99, 132, 1)",
                  //  "rgba(54, 162, 235, 1)",
                    "rgba(255, 206, 86, 1)",
                    "rgba(75, 192, 192, 1)",
                  //  "rgba(153, 102, 255, 1)",
                }
            };
            Dataset datasetC = new Dataset
            {
                borderWidth = 1,
                label = "Today",
                data = saleData.CurrentWise.ToArray(),
                backgroundColor = new string[]{
                    "rgba(255, 99, 132, 0.2)",
                    "rgba(54, 162, 235, 0.2)",
                   // "rgba(255, 206, 86, 0.2)",
                   // "rgba(75, 192, 192, 0.2)",
                   // "rgba(153, 102, 255, 0.2)",
                   // "rgba(54, 162, 235, 0.2)",
                    "rgba(255, 203, 83, 0.2)",
                    "rgba(255, 159, 64, 0.2)",
                    "rgba(255, 99, 132, 0.2)",
                   // "rgba(54, 162, 235, 0.2)",
                    //"rgba(255, 206, 86, 0.2)",
                   // "rgba(75, 192, 192, 0.2)",
                },
                borderColor = new string[] {
                    "rgba(255, 99, 132, 1)",
                    "rgba(54, 162, 235, 1)",
                    //"rgba(255, 206, 86, 1)",
                    //"rgba(75, 192, 192, 1)",
                    //"rgba(153, 102, 255, 1)",
                    //"rgba(255, 203, 83, 1)",
                    //"rgba(255, 159, 64, 1)",
                    "rgba(255, 99, 132, 1)",
                    "rgba(54, 162, 235, 1)",
                    "rgba(255, 206, 86, 1)",
                    //"rgba(75, 192, 192, 1)",
                    //"rgba(153, 102, 255, 1)",
                }
            };
            ChartJs chart = new ChartJs
            {
                type = "bar",
                responsive = true,
                options = new Options { scales = scales, title = new Title { Display = true, Text = "Staff Sale" }, legend = new Legend { Position = "Top" } },
                data = new Data { datasets = new Dataset[] { datasetY, datasetM, datasetC }, labels = saleData.StaffName.ToArray() }
            };

            var chartModel = new ChartJsViewModel
            {
                Chart = chart,
                ChartJson = JsonConvert.SerializeObject(chart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                })
            };

            return View(chartModel);
        }
    }
}
