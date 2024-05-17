using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.TaxCalculator.Services
{
    internal class IntervalDatesDto
    {
        public DateTime IntervalStart { get; set; }

        public List<DateTime> IntervalDates { get; set; } = new List<DateTime>();
    }
}
