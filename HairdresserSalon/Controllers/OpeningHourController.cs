using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Commands.OpeningHour;
using HairdresserSalon.Models;
using HairdresserSalon.Queries.OpeningHour;
using HairdresserSalon.Queries.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HairdresserSalon.Controllers
{
    public class OpeningHourController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public OpeningHourController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var hour = _queryDispatcher.QueryAsync(new GetHour { Id = id }).Result;
                return View(hour);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OpeningHourModel openingHour, DateTime hourOpen, DateTime hourClose)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                if (ModelState.IsValid)
                {
                    _commandDispatcher.SendAsync(new UpdateHour(id, hourOpen, hourClose, openingHour.IsOpen));
                    return RedirectToAction("Edit", "Information");
                }
                return RedirectToAction("Edit","Information");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
