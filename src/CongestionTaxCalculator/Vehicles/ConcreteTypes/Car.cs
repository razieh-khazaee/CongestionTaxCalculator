using CongestionTaxCalculator.Vehicles.Abstractions;
using CongestionTaxCalculator.Vehicles.Enums;

namespace CongestionTaxCalculator.Vehicles.ConcreteTypes
{
    public class Car : Vehicle
    {
        public override ConcreteVehicleTypes GetVehicleType()
        {
            return ConcreteVehicleTypes.Car;
        }
    }
}