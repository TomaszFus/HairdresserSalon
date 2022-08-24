using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Models;
using Convey.CQRS.Queries;
using HairdresserSalon.Queries.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HairdresserSalon.Queries.User;
using HairdresserSalon.Areas.Identity.Data;
using Convey.CQRS.Commands;
using HairdresserSalon.Commands.Service;

namespace HairdresserSalon.Controllers
{
    
    public class ServiceController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ServiceController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [Authorize]
        //GET get all services
        public ActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin==true)
            {
                var list = _queryDispatcher.QueryAsync(new GetAllServices()).Result;
                return View(list);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public ActionResult PriceList()
        {
            var list = _queryDispatcher.QueryAsync(new GetAllServices()).Result;
            return View(list);
        }

        [Authorize]
        //GET add new service
        public ActionResult Create()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                return View(new ServiceModel());
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        //POST add new service
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceModel service)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            bool serviceAlreadyExist = false;
            if (appUser.Admin == true)
            {
                if (ModelState.IsValid)
                {
                    var list = _queryDispatcher.QueryAsync(new GetAllServices()).Result;
                    foreach (var item in list)
                    {
                        if (item.Name == service.Name)
                        {
                            serviceAlreadyExist = true;
                        }
                    }
                    if (serviceAlreadyExist)
                    {
                        ModelState.AddModelError("Name", "Taka usługa już istnieje");
                        return View("Create");
                    }

                    _commandDispatcher.SendAsync(new CreateService(service.Name, service.Price, service.Duration));
                    return RedirectToAction("Index");
                }
                return View("Create");
                
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        //GET edit
        [Authorize]
        public ActionResult Edit(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var service = _queryDispatcher.QueryAsync(new GetService { Id = id }).Result;
                return View(service);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        //POST edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ServiceModel serviceModel)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                if (ModelState.IsValid)
                {
                    _commandDispatcher.SendAsync(new UpdateService(id, serviceModel.Name, serviceModel.Price, serviceModel.Duration));
                    return RedirectToAction("Index");
                }
                return View("Edit");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }


        //GET delete
        [Authorize]
        public ActionResult Delete(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                var service = _queryDispatcher.QueryAsync(new GetService { Id = id }).Result;
                return View(service);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ServiceModel serviceModel)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Admin == true)
            {
                //var service = _serviceRepository.Get(id);
                //_serviceRepository.Delete(id);
                _commandDispatcher.SendAsync(new DeleteService(id));
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }
    }
}
