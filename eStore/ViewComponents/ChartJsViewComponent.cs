using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using eStore.DL.Data;
using eStore.Shared.ViewModels;
using eStore.Shared.ViewModels.ChartJSVC;

namespace eStore.ViewComponents
{
    [ViewComponent(Name = "chartjs")]
    public class ChartJsViewComponent : ViewComponent
    {
        private readonly eStoreDbContext db;

        public ChartJsViewComponent(eStoreDbContext con)
        {
            db = con;
        }

        public IViewComponentResult Invoke()
        {
            var chartData = @"
            {
                type: 'line',
                responsive: true,
                data:
                {
                    labels: ['Monday', 'Tuesday', 'Wednesday','Thursday', 'Friday', 'Saturday',  'Sunday'],
                    datasets: [{
                        label: 'Weekly Sale',
                        data: [12000, 19000, 3000, 5000, 2000, 3000,6000],
                        backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                            ],
                        borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 159, 64, 1)'
                            ],
                        borderWidth: 1
                    }]
                },
                options:
                {
                    scales:
                    {
                        yAxes: [{
                            ticks:
                            {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            }";

            var chart = JsonConvert.DeserializeObject<ChartJs>(chartData);

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

    public class MonthlySaleData
    {
        public List<string> MonthName { get; set; }
        public List<int> Amount { get; set; }
    }
    public class StaffSale
    {
        public List<string> StaffName { get; set; }

        public List<int> YearWise { get; set; }
        public List<int> MonthWise { get; set; }
        public List<int> CurrentWise { get; set; }

        public StaffSale()
        {
            StaffName = new List<string>();
            YearWise = new List<int>();
            MonthWise = new List<int>();
            CurrentWise = new List<int>();
        }
    }
    public class SaleData
    {
        public decimal Amount { get; set; }
        public DateTime OnDate { get; set; }
    }

    public class SaleDataVM
    {
        public List<int> Amount { get; set; }
        public List<string> Label { get; set; }
    }

    public static class SaleDataVMExt
    {
        public static SaleDataVM CopyObject(this SaleDataVM obj, List<SaleData> data)
        {
            List<int> Amt = new List<int>();
            List<string> label = new List<string>();
            foreach (var item in data)
            {
                Amt.Add((int)item.Amount);
                label.Add(item.OnDate.ToString("dd/MMMM"));
            }
            obj.Amount = Amt; obj.Label = label;
            return new SaleDataVM { Amount = Amt, Label = label };
        }
    }
    public class YearlySaleData
    {
        public List<int> Year { get; set; }
        public List<int> Amount { get; set; }
    }
}
