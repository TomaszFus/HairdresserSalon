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

        public ActionResult Index(Guid id, int pageNumber=2)
        {
            TempData["id"] = id;
            var list = _queryDispatcher.QueryAsync(new GetAllDaysForHairdresser { Id = id }).Result;
            list = list.Where(x => x.Date >= DateTime.Today.AddDays(-7)).ToList();
            //return View(list);
            return View(PaginatedList<DayModel>.CreateAsync(list, pageNumber, 6));
        }

        public ActionResult Create()
        {
            return View(new DayModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime datefield)
        {
            Guid id;
            var a = Guid.TryParse(TempData["id"].ToString(), out id);

            bool correct = true;
            var list = _queryDispatcher.QueryAsync(new GetAllDaysForHairdresser { Id = id }).Result;
            foreach (var item in list)
            {
                if (item.Date ==datefield)
                {
                    correct = false;
                    TempData["Error"] = "Ten dzień został już dodany.";
                    break;
                    
                }
            }
            if (datefield.DayOfWeek==DayOfWeek.Sunday)
            {
                correct = false;
                TempData["Error"] = "Nie dodano dnia, ponieważ wybrany dzień to niedziela.";
            }

            if (correct == true)
            {
                _commandDispatcher.SendAsync(new CreateDay(datefield, id));
                TempData["Success"] = "Dodano dzień.";
            }
            
            return RedirectToAction("Index", new { id = TempData["id"] });
            


        }

        
    }
}
