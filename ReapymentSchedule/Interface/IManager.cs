using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReapymentSchedule.Models;

namespace ReapymentSchedule.Interface
{
    public interface IManager
    {
        IProduct CreateProduct(InputData data);
        ICalc CreateCalculator(InputData data);
    }
}
