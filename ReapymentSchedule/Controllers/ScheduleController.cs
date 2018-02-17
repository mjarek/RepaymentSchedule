using ReapymentSchedule.Interface;
using ReapymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReapymentSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IManager _manager;
        public ScheduleController(IManager manager)
        {
            _manager = manager;
        }
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(InputData inputData)
        {
            // ViewBag.Tilte = Amount.ToString() + Instalment.ToString();
            var managerData = new ManagerData
            {
                Product = _manager.CreateProduct(inputData),
                Calculator = _manager.CreateCalculator(inputData)
            };
          
           return View(new Scheduler(managerData, inputData));
        }
    }

   
}