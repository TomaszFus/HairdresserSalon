using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Models;
using Convey.CQRS.Queries;
using HairdresserSalon.Queries.Service;

namespace HairdresserSalon.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IQueryDispatcher _queryDispatcher;
        
        public ServiceController(IServiceRepository serviceRepository, IQueryDispatcher queryDispatcher)
        {
            _serviceRepository = serviceRepository;
            _queryDispatcher = queryDispatcher;
        }

        //GET get all services
        public ActionResult Index()
        {
            var list = _queryDispatcher.QueryAsync(new GetAllServices()).Result;
            return View(list);
        }

        //GET add new service
        public ActionResult Create()
        {
            return View(new ServiceModel());
        }

        //POST add new service
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceModel service)
        {
            _serviceRepository.AddService(service);
            return RedirectToAction("Index");
        }

        //GET edit
        public ActionResult Edit(Guid id)
        {
            return View(_serviceRepository.Get(id).Result);
        }

        //POST edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ServiceModel serviceModel)
        {
            _serviceRepository.Update(id, serviceModel);
            return RedirectToAction("Index");
        }


        //GET delete
        public ActionResult Delete(Guid id)
        {
            return View(_serviceRepository.Get(id).Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ServiceModel serviceModel)
        {
            //var service = _serviceRepository.Get(id);
            _serviceRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
