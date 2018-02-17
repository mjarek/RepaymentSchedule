﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReapymentSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(decimal Amount, decimal Instalment)
        {
            ViewBag.Tilte = Amount.ToString() + Instalment.ToString();
            return View();
        }
    }
}