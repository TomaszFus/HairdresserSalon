using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairdresserSalon.Repositories.Abstract;
using HairdresserSalon.Models;

namespace HairdresserSalon.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        //GET get all services
        public ActionResult Index()
        {
            var list = _serviceRepository.GetAllServices();
            return View(list);
        }

        //GET add new service
        public ActionResult Create()
        {
            return View();
        }

        //POST add new service
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceModel service)
        {
            _serviceRepository.AddService(service);
            return RedirectToAction("Index");
        }
    }
}
