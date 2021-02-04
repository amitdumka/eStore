using System;
using eStore.DL.Data;
using eStore.Shared.ViewModels.ChartJSVC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eStore.BL.ViewComponets.ChartJS
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
}
