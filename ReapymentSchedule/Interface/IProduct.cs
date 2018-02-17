using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReapymentSchedule.Interface
{
   public  interface IProduct
    {

         decimal Interest { get; }
         ICalc Calc { get; }
    }
}
