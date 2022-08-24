using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Commands.Hour;
using HairdresserSalon.Queries.Day;
using HairdresserSalon.Queries.Hour;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Controllers
{
    public class HourController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public HourController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        public ActionResult Edit(Guid id)
        {
            TempData["day"] = id;
            var day = _queryDispatcher.QueryAsync(new GetDay { Id = id }).Result;
            //var list = _queryDispatcher.QueryAsync(new GetHoursForDay { Id = id }).Result;
            return View(day);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Guid dayId = (Guid)TempData["day"];
            _commandDispatcher.SendAsync(new Delete(id));
            return RedirectToAction("Edit", new { id = dayId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime hour)
        {
            Guid dayId = (Guid)TempData["day"];
            var list = _queryDispatcher.QueryAsync(new GetHoursForDay { Id = dayId }).Result;
            bool check = false;
            foreach (var item in list)
            {
                if (item.Hour.Hour == hour.Hour && item.Hour.Minute == hour.Minute)
                {
                    check = true;
                    TempData["Error"] = "Wybrana godzina już istnieje.";
                }
            }

            if (check==false)
            {
                _commandDispatcher.SendAsync(new AddHour(dayId, hour));
                TempData["Success"] = "Dodano godzinę.";
            }
            

            return RedirectToAction("Edit", new { id = dayId });
        }
    }
}
