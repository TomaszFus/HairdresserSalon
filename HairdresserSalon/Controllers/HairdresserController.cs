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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using HairdresserSalon.Queries.User;
using HairdresserSalon.Areas.Identity.Data;

namespace HairdresserSalon.Controllers
{
    [Authorize]
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
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Employee == true)
            {
                var list = _queryDispatcher.QueryAsync(new GetAllHairdressers()).Result;
                return View(list);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
            
        }

        //GET create Hairdresser
        public ActionResult Create()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                return View(new HairdresserModel());
            }                
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        //POST create Hairdresser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HairdresserModel hairdresser)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                if (ModelState.IsValid)
                {
                    _commandDispatcher.SendAsync(new CreateHairdresser(hairdresser.Name));
                    return RedirectToAction("Index");
                }
                return View("Create");
                //_hairdresserRepository.AddHairdresser(hairdresser);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public ActionResult Delete(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                return View(_queryDispatcher.QueryAsync(new GetHairdresser { Id = id }).Result);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, HairdresserModel hairdresser)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                _commandDispatcher.SendAsync(new DeleteHairdresser(id));
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
