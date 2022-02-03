using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Queries.Visit;

namespace HairdresserSalon.Controllers
{
    public class VisitController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public VisitController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }
        public IActionResult Index()
        {
            var list = _queryDispatcher.QueryAsync(new GetAllAvailableDates()).Result;
            return View(list);
        }

        public IActionResult Create(Guid id)
        {
            return View();
        }
    }
}
