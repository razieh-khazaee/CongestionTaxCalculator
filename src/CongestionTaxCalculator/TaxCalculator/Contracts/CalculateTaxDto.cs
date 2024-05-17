using CongestionTaxCalculator.Vehicles.Abstractions;
using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.TaxCalculator.Contracts
{
    public class CalculateTaxDto
    {
        public Vehicle Vehicle { get; set; }
        public List<DateTime> Dates { get; set; }
        public CalculateTaxRulesDto Rules { get; set; }
    }
}
