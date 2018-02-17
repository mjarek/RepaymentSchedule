using ReapymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReapymentSchedule.Interface
{
    public interface ICalc
    {
        List<RepaymentScheduleDetail> Calc(InputData data, IProduct product);
    }
}
