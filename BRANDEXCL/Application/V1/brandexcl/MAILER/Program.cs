using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MAILER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                string day = System.DateTime.Now.ToString("ddd");
                //Passing service base url
                client.BaseAddress = new Uri("http://brandexclusive.in/");
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                Console.WriteLine("Sending Daily Sales Report");
                Task<string> task = client.GetStringAsync("api/Mailer/SendDailySalesReport");
                Console.WriteLine(task.Result.ToString());
                Console.WriteLine("Sending Daily Profit And Loss Report");
                Task<string> task1 = client.GetStringAsync("api/Mailer/SendDailyProfitLossReport");
                Console.WriteLine(task1.Result.ToString());
                Console.WriteLine("Sending Daily Stock Report");
                if(day== "Sun")
                {
                    Task<string> task2 = client.GetStringAsync("api/Mailer/SendWeeklyStockReport");
                    Console.WriteLine(task2.Result.ToString());
                }
            }
        }
    }
}
