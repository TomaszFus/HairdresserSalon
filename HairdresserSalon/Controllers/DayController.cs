using HairdresserSalon.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Controllers
{
    public class DayController : Controller
    {
        private readonly IDayRepository _dayRepository;
        public DayController(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        public IActionResult Index()
        {
            var list = _dayRepository.GetAllDays();
            return View(list);
        }

        public IActionResult Details()
        {
            
            return View();
        }

    }
}
