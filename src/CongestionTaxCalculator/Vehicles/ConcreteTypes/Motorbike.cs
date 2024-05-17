using CongestionTaxCalculator.Vehicles.Abstractions;
using CongestionTaxCalculator.Vehicles.Enums;

namespace CongestionTaxCalculator.Vehicles.ConcreteTypes
{
    public class Motorbike : Vehicle
    {
        public override ConcreteVehicleTypes GetVehicleType()
        {
            return ConcreteVehicleTypes.Motorbike;
        }
    }
}