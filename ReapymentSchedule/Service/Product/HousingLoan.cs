using ReapymentSchedule.Calc;
using ReapymentSchedule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Product
{
    public class HousingLoan : IProduct
    {
        public decimal Interest => 0.035m;
        
    }
}