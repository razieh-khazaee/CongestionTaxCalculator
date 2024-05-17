using CongestionTaxCalculator.TaxCalculator.Contracts;
using CongestionTaxCalculator.TaxCalculator.Strategies.Abstractions;
using CongestionTaxCalculator.Vehicles.Abstractions;
using System;
using System.Linq;

namespace CongestionTaxCalculator.TaxCalculator.Strategies
{
    public class NonTollFreeCalculationStrategy : ITaxCalculatorStrategy
    {
        public int CalculateTax(Vehicle vehicle, DateTime date, CalculateTaxRulesDto taxCalculatorRules)
        {
            if (IsTollFreeDate(date, taxCalculatorRules))
            {
                return 0;
            }

            var tollFeePerHourSetting = taxCalculatorRules.TollFeePerHourSettings.SingleOrDefault(m => date.TimeOfDay >= m.StartTime && date.TimeOfDay <= m.EndTime);

            return tollFeePerHourSetting?.TollFee ?? 0;
        }

        private bool IsTollFreeDate(DateTime date, CalculateTaxRulesDto taxCalculatorRules)
        {
            return taxCalculatorRules.TollFreeWeekDays.Contains(date.DayOfWeek) || taxCalculatorRules.TollFreeDates.Contains(date);
        }
    }
}
