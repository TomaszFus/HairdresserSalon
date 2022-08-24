using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Commands.User;
using HairdresserSalon.Queries.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HairdresserSalon.Controllers
{
    public class UserController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public UserController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var list = _queryDispatcher.QueryAsync(new GetEmployees()).Result;
                return View(list);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public IActionResult AddEmployee(string email)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var list = _queryDispatcher.QueryAsync(new GetUsers()).Result;
                //bool exist = false;
                AppUser _appUser = new AppUser();

                foreach (AppUser user in list)
                {
                    if (user.Email == email)
                    {
                        //exist = true;
                        _appUser = user;
                        if (user.Employee == true)
                        {
                            TempData["Error"] = "Konto zostało już dodane";
                            return RedirectToAction("Index");
                        }
                        break;
                    }
                    TempData["Error"] = "Nie znaleziono takiego konta";
                }


                //if (exist==true)
                //{
                _commandDispatcher.SendAsync(new AddEmployee(_appUser));
                
                //}
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public IActionResult DeleteEmployee(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                _commandDispatcher.SendAsync(new DeleteEmployee(id));
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
        
        public IActionResult ChangeAdminStatus(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                _commandDispatcher.SendAsync(new ChangeAdminStatus(id));
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
