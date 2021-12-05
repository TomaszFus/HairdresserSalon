using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;

namespace HairdresserSalon.Controllers
{
    public class HairdresserController : Controller
    {
        private readonly IHairdresserRepository _hairdresserRepository;
        public HairdresserController(IHairdresserRepository hairdresserRepository)
        {
            _hairdresserRepository = hairdresserRepository;
        }

        //GET get all hairdressers
        public ActionResult Index()
        {
            var list = _hairdresserRepository.GetAllHairdressers();
            return View(list);
        }

        //GET create Hairdresser
        public ActionResult Create()
        {
            return View(new HairdresserModel());
        }

        //POST create Hairdresser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HairdresserModel hairdresser)
        {
            _hairdresserRepository.AddHairdresser(hairdresser);
            return RedirectToAction("Index");
        }
    }
}
