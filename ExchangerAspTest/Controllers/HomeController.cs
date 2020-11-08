using ExchangerAspTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangerAspTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }


        public IEnumerable<Operation> Rates { get; set; }
        public async Task OnGet()
        {
           
          Rates = await _db.Rates.ToListAsync();
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

   

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private const string urlPattern = "https://api.exchangeratesapi.io/latest?base=";
      

        [HttpPost]
        public IActionResult Index(Operation model)
        {
           

            string url = string.Format(urlPattern, model.ToAmount.ToString(), model.ToCurrency.ToString());
            
            WebClient wc = new WebClient();
            var json = wc.DownloadString(url + model.ToAmount.ToString());


            Exchange exchange = Newtonsoft.Json.JsonConvert.DeserializeObject<Exchange>(json);
            double exchangeRate = exchange.rates[model.ToCurrency.ToString()];

             model.Convert = model.Amount * exchangeRate ;
             ViewBag.Convert = model.Convert;
            return View();
        }

        // [HttpPost]
        //public IActionResult Index1(Operation model)
        //{
        //    //string result = model.NumberA.ToString();
        //    //string numberA = model.Result.ToString();


        //    //ViewBag.NumberA = numberA;
        //    //ViewBag.Resut = result;

        //    //string result = model.OperationType.ToString();
        //    //string numberA = model.OperationType1.ToString();

        //    model.OperationType = model.OperationType1 ;
        //    //model.OperationType1 = model.OperationType;


        //    //model.Result = ViewBag.NumberA;
        //    return View();
        //}

        class Exchange
        {          
            public Dictionary<String, double> rates { get; set; }
        }



    }

}
