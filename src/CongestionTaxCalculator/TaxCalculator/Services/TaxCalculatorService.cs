using CongestionTaxCalculator.TaxCalculator.Contexts;
using CongestionTaxCalculator.TaxCalculator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionTaxCalculator.TaxCalculator.Services
{
    public class TaxCalculatorService : ITaxCalculator
    {
        /**
             * Calculate the total toll fee for one day
             *
             * @param vehicle - the vehicle
             * @param dates   - date and time of all passes on one day
             * @return - the total congestion tax for that day
             */

        public int GetTax(CalculateTaxDto input)
        {
            Validate(input.Dates);

            var dates = input.Dates.OrderBy(d => d.Date).ToArray();

            int totalFee = 0;
            var taxCalculatorContext = new TaxCalculatorContext(input.Vehicle, input.Rules);
            var intervalDatesGroups = GetIntervalDates(dates, input.Rules.SingleChargeMinutes);
            foreach (var group in intervalDatesGroups)
            {
                var groupDates = new List<DateTime>() { group.IntervalStart }.Union(group.IntervalDates).ToList();
                var maxTollFeeInGroup = groupDates.Max(date => taxCalculatorContext.GetTollFee(date));
                totalFee += maxTollFeeInGroup;
            }

            if (totalFee > input.Rules.MaxSEK)
            {
                totalFee = input.Rules.MaxSEK;
            }

            return totalFee;
        }

        private List<IntervalDatesDto> GetIntervalDates(DateTime[] dates, int singleChargeMinutes)
        {
            var result = new List<IntervalDatesDto>();

            if (!dates.Any())
            {
                return result;
            }

            result.Add(new IntervalDatesDto { IntervalStart = dates.First() });

            foreach (DateTime date in dates.Skip(1))
            {
                var lastInterval = result.Last();

                var dateDiffInMinutes = date.Subtract(lastInterval.IntervalStart).TotalMinutes;
                if (dateDiffInMinutes <= singleChargeMinutes)
                {
                    lastInterval.IntervalDates.Add(date);
                }
                else
                {
                    result.Add(new IntervalDatesDto { IntervalStart = date });
                }
            }

            return result;
        }

        private void Validate(List<DateTime> dates)
        {
            var distinctDates = dates.Select(m => m.Date).Distinct().ToList();
            if (distinctDates.Count() > 1)
            {
                throw new Exception("Dates must be in one day");
            }
        }
    }
}