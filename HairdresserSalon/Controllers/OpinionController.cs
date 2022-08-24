using HairdresserSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Queries.Opinion;

namespace HairdresserSalon.Controllers
{
    public class OpinionController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public OpinionController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            var list = _queryDispatcher.QueryAsync(new GetAllOpinions()).Result;
            float suma = 0;
            foreach (var item in list)
            {
                suma += item.Opinion.Rating;
            }
            float srednia = suma / list.Count();
            TempData["srednia"] = srednia;
            return View(PaginatedList<VisitModel>.CreateAsync(list, pageNumber, 5));
        }

        

        
    }
}
