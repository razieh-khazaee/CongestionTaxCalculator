using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.TaxCalculator.Contracts
{
    public class CalculateTaxRulesDto
    {
        public int MaxSEK { get; set; }
        public int SingleChargeMinutes { get; set; }
        public List<string> TollFreeVehicles { get; set; }
        public List<TollFeePerHourDto> TollFeePerHourSettings { get; set; }
        public List<DateTime> TollFreeDates { get; set; }
        public List<DayOfWeek> TollFreeWeekDays { get; set; }
    }
}
