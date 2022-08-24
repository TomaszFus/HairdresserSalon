using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Commands.Information;
using HairdresserSalon.Models;
using HairdresserSalon.Queries.Information;
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
    public class InformationController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public InformationController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;

        }
        public IActionResult Index()
        {
            var info = _queryDispatcher.QueryAsync(new GetInformation()).Result;
            return View(info);
        }

        //GET edit
        [Authorize]
        public ActionResult Edit()
        {

            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var info = _queryDispatcher.QueryAsync(new GetInformation()).Result;
                return View(info);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        //POST edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, InformationModel information)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                if (ModelState.IsValid)
                {
                    _commandDispatcher.SendAsync(new UpdateInformation(information.Street, information.City, information.PhoneNumber));
                    return RedirectToAction("Edit");
                }
                return RedirectToAction("Edit");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
