using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using HairdresserSalon.Queries.Hour;
using HairdresserSalon.Queries.Day;
using HairdresserSalon.Queries.Service;
using System.Security.Claims;
using HairdresserSalon.Models;
using HairdresserSalon.Queries.Customer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Convey.CQRS.Commands;
using HairdresserSalon.Commands.Visit;
using Microsoft.AspNetCore.Authorization;
using HairdresserSalon.Queries.Visit;
using HairdresserSalon.Commands.Visit.Handlers;
using HairdresserSalon.Areas.Identity.Data;
using HairdresserSalon.Queries.User;
using HairdresserSalon.Commands.Customer;

namespace HairdresserSalon.Controllers
{
    [Authorize]
    public class VisitController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public VisitController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }
        public IActionResult Index(string search, string id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Employee == true)
            {
                var list = _queryDispatcher.QueryAsync(new GetAllVisits()).Result;
                if (search!=null)
                {
                    list = list.Where(x => x.Customer.LastName.ToLower() == search.ToLower()).ToList();
                }
                else if (id=="t")
                {
                    list = list.Where(x => x.Date.Day.Date == DateTime.Now).ToList();
                }
                return View(list);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");

        }

        public IActionResult CustomerIndex()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var list = _queryDispatcher.QueryAsync(new GetVisitsForCustomer { Id = userId}).Result;
            return View(list);
        }

        public IActionResult VisitsHistory()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var list = _queryDispatcher.QueryAsync(new GetVisitsHistory { Id = userId }).Result;
            return View(list);
        }

        public IActionResult VisitsArchive(int id)
        {
            var list = _queryDispatcher.QueryAsync(new GetVisitsArchive()).Result;
            //if (id == 1)
            //{
            //    return View(list);
            //}
            if (id == 2)
            {
                list = list.Where(x => x.Ended == true);
                //return View(list);
            }
            if (id == 3)
            {
                list = list.Where(x => x.Canceled == true);
                //return View(list);
            }
            return View(list);
        }
        

        public IActionResult Create(Guid id)
        {
            var result = _queryDispatcher.QueryAsync(new GetHour { Id = id }).Result;
            var result2 = _queryDispatcher.QueryAsync(new GetDayAndHairdresser { Id = result.Day.Id }).Result;
            var services = _queryDispatcher.QueryAsync(new GetAllServices()).Result;
            ViewBag.Services = new SelectList(services, "Id", "Name");
            
            VisitModel visit = VisitModel.Create(Guid.NewGuid(), result2.Hairdresser, false, result, false);
            TempData["hairdresser"] = visit.Hairdresser.Id.ToString();
            TempData["date"] = visit.Date.Id.ToString();

            //bool emp=false;
            //if (TempData.ContainsKey("emp"))
            //    emp = (bool)TempData["emp"];

            //if (emp==true)
            //{
            //    return View(visit);
            //}

            return View(visit);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitModel visit)
        {        
            Guid hairdresserId = (Guid)TempData["hairdresser"];
            Guid dateId = (Guid)TempData["date"];
            Guid serviceId = Guid.Parse(Request.Form["Services"]);
            Guid userId = Guid.Empty;
            if (visit.Customer==null)
            {
                try
                {
                    userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    bool customerExist = false;
                    CustomerModel _customer = new CustomerModel();
                    var customers = _queryDispatcher.QueryAsync(new GetAllCustomers()).Result;
                    foreach (var item in customers)
                    {
                        if (item.FirstName == visit.Customer.FirstName && item.LastName == visit.Customer.LastName)
                        {
                            customerExist = true;
                            _customer = item;

                        }
                    }

                    if (customerExist == false)
                    {
                        CustomerModel customer = CustomerModel.Create(Guid.NewGuid(), visit.Customer.FirstName, visit.Customer.LastName, visit.Customer.Email, visit.Customer.PhoneNumber);
                        _commandDispatcher.SendAsync(new CreateCustomer(customer));
                        userId = customer.Id;
                    }
                    else
                    {
                        userId = _customer.Id;
                    }
                }
                else
                {
                    TempData["emp"] = true;
                    TempData["error"] = "Uzupełnij dane";
                    return RedirectToAction("Create", new { id = visit.Id });
                }
                
                
                
                
            }
            
            
            _commandDispatcher.SendAsync(new CreateVisit(serviceId, userId, hairdresserId, dateId, visit));
            var b = Test.a;
            if (b==true)
            {
                return RedirectToAction("CustomerIndex");
            }
            TempData["Error"] = "Nie umówiono wizyty. Niewystarczający czas na wykonanie usługi. Proszę wybrać inny termin.";
            return RedirectToAction("Index", "Day");

        }

        public ActionResult VisitNotCreated()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Employee == true)
            {
                var visit = _queryDispatcher.QueryAsync(new GetVisitDetails { Id = id }).Result;
                if (visit.Customer.VisitsCounter % 10 == 0)
                {
                    visit.Price = visit.Price - visit.Price * 20 / 100;
                }
                return View(visit);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public ActionResult DetailsCustomer(Guid id)
        {
            var visit = _queryDispatcher.QueryAsync(new GetVisitDetails { Id = id }).Result;
            return View(visit);
        }

        //GET edit
        public ActionResult CancelVisit(Guid id)
        {
            var visit = _queryDispatcher.QueryAsync(new GetVisitDetails { Id = id }).Result;
            return View(visit);
        }

        //POST edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelVisit(Guid id, ServiceModel serviceModel)
        {
            // 1 klient
            // 2 zakład
            int source = int.Parse(TempData["source"].ToString());
            _commandDispatcher.SendAsync(new CancelVisit(id, source));
            if (source == 2)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("CustomerIndex");
        }

        
        
        //GET edit
        public ActionResult EndVisit(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Employee == true)
            {
                var visit = _queryDispatcher.QueryAsync(new GetVisitDetails { Id = id }).Result;
                return View(visit);
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        
        
        //POST edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndVisit(Guid id, ServiceModel serviceModel)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            AppUser appUser = _queryDispatcher.QueryAsync(new GetUserById { Id = userId }).Result;
            if (appUser.Employee == true)
            {
                _commandDispatcher.SendAsync(new EndVisit(id));
                return RedirectToAction("Index");
            }
            return View("Areas/Identity/Pages/Account/AccessDenied.cshtml");
        }

        public ActionResult AddOpinion(Guid id)
        {
            TempData["id"] = id;
            var visit = _queryDispatcher.QueryAsync(new GetVisitDetails { Id = id }).Result;
            return View(visit);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOpinion(VisitModel visit)
        {
            
                if (visit.Opinion.Rating==0)
                {
                    TempData["Error"] = "Wybierz ocenę!";
                    return View("AddOpinion");
                }
                _commandDispatcher.SendAsync(new AddOpinion(visit));
                return RedirectToAction("VisitsHistory", new { id = (Guid)TempData["id"] });
            
            
        }
    }
}
