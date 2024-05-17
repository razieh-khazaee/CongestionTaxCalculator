using CongestionTaxCalculator.TaxCalculator.Contracts;
using CongestionTaxCalculator.TaxCalculator.Strategies;
using CongestionTaxCalculator.TaxCalculator.Strategies.Abstractions;
using CongestionTaxCalculator.Vehicles.Abstractions;
using System;
using System.Linq;

namespace CongestionTaxCalculator.TaxCalculator.Contexts
{
    internal class TaxCalculatorContext
    {
        private readonly ITaxCalculatorStrategy taxCalculatorStrategy;
        private readonly Vehicle vehicle;
        private readonly CalculateTaxRulesDto taxCalculatorRules;

        public TaxCalculatorContext(Vehicle vehicle, CalculateTaxRulesDto taxCalculatorRules)
        {
            this.vehicle = vehicle;
            this.taxCalculatorRules = taxCalculatorRules;
            taxCalculatorStrategy = GetTollCalculationStrategy();
        }

        public int GetTollFee(DateTime date)
        {
            return taxCalculatorStrategy.CalculateTax(vehicle, date, taxCalculatorRules);
        }

        private ITaxCalculatorStrategy GetTollCalculationStrategy()
        {
            if (IsTollFreeVehicle(vehicle))
            {
                return new TollFreeTaxCalculatorStrategy();
            }

            return new NonTollFreeCalculationStrategy();

        }

        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return false;
            }

            var vehicleType = vehicle.GetVehicleType().ToString();
            return taxCalculatorRules.TollFreeVehicles.Any(m => vehicleType.Equals(m, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
