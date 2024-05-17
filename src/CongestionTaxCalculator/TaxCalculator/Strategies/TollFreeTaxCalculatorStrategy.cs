using CongestionTaxCalculator.TaxCalculator.Contracts;
using CongestionTaxCalculator.TaxCalculator.Strategies.Abstractions;
using CongestionTaxCalculator.Vehicles.Abstractions;
using System;

namespace CongestionTaxCalculator.TaxCalculator.Strategies
{
    public class TollFreeTaxCalculatorStrategy : ITaxCalculatorStrategy
    {
        public int CalculateTax(Vehicle vehicle, DateTime date, CalculateTaxRulesDto taxCalculatorRules)
        {
            return 0;
        }
    }
}
