using ReapymentSchedule.Interface;
using ReapymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Calc
{
    public class ConstantCapitalInstalment : ICalc
    {
        public List<RepaymentScheduleDetail> list = new List<RepaymentScheduleDetail>();

        public List<RepaymentScheduleDetail> Calc(InputData data,IProduct product)
        {
            

            var CapitalInstalment = Math.Round(data.Amount / data.NumberOfInstalments, 2,MidpointRounding.ToEven);
            var LastCapitalInstalment = data.Amount - (CapitalInstalment * (data.NumberOfInstalments - 1));
            decimal counter = data.Amount;
            int counterPeriod = 1;


            while (counter > 0)
            {
                RepaymentScheduleDetail detail = new RepaymentScheduleDetail
                {
                    Capital = CapitalInstalment,
                    Id = counterPeriod,
                    Interest = Math.Round((counter * product.Interest) / data.NumberOfInstalments, 2, MidpointRounding.ToEven),
                    RemainingCapital = counter
                };
                

                if (counter == LastCapitalInstalment)
                { 
                    counter -= LastCapitalInstalment;
                    detail.Capital = LastCapitalInstalment;
                   
                }
                else
                {
                    counter -= CapitalInstalment;
                }
                counterPeriod += 1;
                list.Add(detail);
            }

            return list;
        }
    }
}