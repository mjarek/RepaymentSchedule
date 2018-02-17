using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Models
{
    public class RepaymentScheduleDetail
    {
        public int Id { get; set; }
        public decimal Capital { get; set; }
        public decimal Interest { get; set; }
        public decimal RemainingCapital { get; set; }
    }
}