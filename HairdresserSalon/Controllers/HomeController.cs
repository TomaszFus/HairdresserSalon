using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDayRepository _dayRepository;
        private readonly IUserRepository _permissionRepository;

        public HomeController(ILogger<HomeController> logger, IDayRepository dayRepository, IUserRepository permissionRepository)
        {
            _logger = logger;
            _dayRepository = dayRepository;
            _permissionRepository = permissionRepository;
        }

        public IActionResult Index()
        {
            
            //var data = DateTime.UtcNow;
            //var data2 = data.AddMinutes(62);
            //if (data>data2)
            //{

            //}
            //DateTime s = DateTime.Now;
            //TimeSpan ts = new TimeSpan(10, 30, 0);
            //s = s.Date + ts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
