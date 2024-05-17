using CongestionTaxCalculator.TaxCalculator.Contracts;
using CongestionTaxCalculator.Vehicles.Abstractions;
using System;

namespace CongestionTaxCalculator.TaxCalculator.Strategies.Abstractions
{
    public interface ITaxCalculatorStrategy
    {
        int CalculateTax(Vehicle vehicle, DateTime date, CalculateTaxRulesDto taxCalculatorRules);
    }
}
