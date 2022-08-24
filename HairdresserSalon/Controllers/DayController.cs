using Convey.CQRS.Queries;
using HairdresserSalon.Models;
using HairdresserSalon.Queries.Day;
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
        private readonly IQueryDispatcher _queryDispatcher;
        public DayController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            var list = _queryDispatcher.QueryAsync(new GetAllAvailableDates()).Result;
            return View(PaginatedList<DayModel>.CreateAsync(list, pageNumber, 6));
        }

        public IActionResult IndexEmp(int pageNumber = 1)
        {
            TempData["emp"] = true;
            var list = _queryDispatcher.QueryAsync(new GetAllAvailableDates()).Result;
            return View("Index",PaginatedList<DayModel>.CreateAsync(list, pageNumber, 6));
        }

        public IActionResult Details()
        {
            
            return View();
        }

    }
}
