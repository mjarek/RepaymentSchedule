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
        private InputData _inputData;
        private decimal _capitalInstalment;
        private decimal _lastCapitalInstalment;
        private const int _monthInYear = 12;

        public ConstantCapitalInstalment(InputData data)
        {
            _inputData = data;
        }

        public List<RepaymentScheduleDetail> Calc(InputData data,IProduct product)
        {
            CalculateCapitalInstalment();
            CalculateLastCapitalInstalment();
            decimal counterAmount = data.Amount;
            int counterPeriod = 1;


            while (counterAmount > 0)
            {
                var detail = CreateWholeInstalment(counterAmount, counterPeriod, product);
                counterAmount = SetNewCounterAmount(counterAmount);
                counterPeriod += 1;
                list.Add(detail);
            }

            return list;
        }

        private decimal SetNewCounterAmount(decimal oldAmount)
        {
            if (oldAmount == _lastCapitalInstalment)
            {
                oldAmount -= _lastCapitalInstalment;
               
            }
            else
            {
                oldAmount -= _capitalInstalment;
            }
            return oldAmount;
        }

        private decimal CalculateInterest(decimal counterAmount, IProduct product)
        {
            return Math.Round((counterAmount * product.Interest) / _monthInYear, 2, MidpointRounding.ToEven);
        }

        private RepaymentScheduleDetail CreateWholeInstalment(decimal counterAmount,int counterPeriod, IProduct product)
        {
            return new RepaymentScheduleDetail
            {
                Capital = SetCapital(counterAmount),
                Id = counterPeriod,
                Interest = CalculateInterest(counterAmount, product),
                RemainingCapital = counterAmount
            };
        }

        private decimal SetCapital(decimal counterAmount)
        {
            if (counterAmount == _lastCapitalInstalment) return _lastCapitalInstalment;

            return _capitalInstalment;
        }

       

        private void CalculateLastCapitalInstalment()
        {
            _lastCapitalInstalment=  _inputData.Amount - (_capitalInstalment * (_inputData.NumberOfInstalments - 1));
        }

        private void CalculateCapitalInstalment()
        {
            _capitalInstalment= Math.Round(_inputData.Amount / _inputData.NumberOfInstalments, 2, MidpointRounding.ToEven);
        }
    }
}