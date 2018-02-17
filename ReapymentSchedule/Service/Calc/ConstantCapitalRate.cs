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
        //Interest z productu
        //period

        public List<RepaymentScheduleDetail> list = new List<RepaymentScheduleDetail>();

        public List<RepaymentScheduleDetail> Calc(InputData data)
        {
            var period = 12;

            var CapitalInstalment = Math.Round(data.Amount / period, 2,MidpointRounding.ToEven);
            var LastCapitalInstalment = data.Amount - (CapitalInstalment * (period - 1));
            decimal counter = data.Amount;
            int counterPeriod = 1;


            while (counter > 0)
            {


                RepaymentScheduleDetail detail = new RepaymentScheduleDetail
                {
                    Capital = CapitalInstalment,
                    Id = counterPeriod,
                    Interest = Math.Round((counter * 0.035m) / 12, 2, MidpointRounding.ToEven),
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

        

        private RepaymentScheduleDetail CalculateSchema(RepaymentScheduleDetail detail)
        {
            return detail = new RepaymentScheduleDetail
            {
                Capital = detail.Capital,
                Id = detail.Id,
                //Interest = 
            };
        }
    }
}