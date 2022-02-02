using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Commands.Hairdresser;
using HairdresserSalon.Queries.Hairdresser;

namespace HairdresserSalon.Controllers
{
    public class HairdresserController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public HairdresserController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;

        }

        //GET get all hairdressers
        public ActionResult Index()
        {
            var list = _queryDispatcher.QueryAsync(new GetAllHairdressers()).Result;
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
            _commandDispatcher.SendAsync(new CreateHairdresser(hairdresser.Name));
            return RedirectToAction("Index");
            //_hairdresserRepository.AddHairdresser(hairdresser);

        }
    }
}
