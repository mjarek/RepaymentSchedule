using ReapymentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReapymentSchedule.Models
{
    public class Scheduler
    { 
        private ManagerData managerData;
        private InputData inputData;
        private List<RepaymentScheduleDetail> repaymentSchedule;

        public Scheduler(ManagerData managerData, InputData inputData)
        {
            this.managerData = managerData;
            this.inputData = inputData;
            CreateRepaymentSchedule();
        }

        private void CreateRepaymentSchedule()
        {
            var scheduleDetail = new SortedList<int, RepaymentScheduleDetail>();
            var numberOfInstalment=CalculateNumberOfInstalment();


            repaymentSchedule =  managerData.Calculator.Calc(inputData);
        }

        public List<RepaymentScheduleDetail> GetRepaymentSchedule()
        {
            return repaymentSchedule ?? new List<RepaymentScheduleDetail>();
        }

        private int CalculateNumberOfInstalment()
        {
            var result = 0;
            if (inputData.PeriodType == TypeOfPeriod.Period.Year )
            {
                result = Convert.ToInt32(inputData.Period) * 12;
            }else if( inputData.PeriodType== TypeOfPeriod.Period.Month)
            {
                result = Convert.ToInt32(inputData.Period);
            }
            return result;
        }
    }
}