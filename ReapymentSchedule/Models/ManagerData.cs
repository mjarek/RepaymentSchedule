using ReapymentSchedule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Models
{
    public class ManagerData
    {
        public ICalc Calculator { get; set; }
        public IProduct Product { get; set; }
    }
}