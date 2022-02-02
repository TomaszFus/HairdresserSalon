using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Commands.Day;
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
    public class TimeTableController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public TimeTableController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public ActionResult Index(Guid id, int pageNumber=1)
        {
            TempData["id"] = id;
            var list = _queryDispatcher.QueryAsync(new GetAllDaysForHairdresser { Id = id }).Result;
            //return View(list);
            return View(PaginatedList<DayModel>.CreateAsync(list, pageNumber, 5));
        }

        public ActionResult Create()
        {
            return View(new DayModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayModel day)
        {
            Guid id;
            var a = Guid.TryParse(TempData["id"].ToString(), out id);
            _commandDispatcher.SendAsync(new CreateDay(day.Date, id));
            return RedirectToAction("Index","Hairdresser");
            

        }
    }
}
