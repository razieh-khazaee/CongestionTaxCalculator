using CongestionTaxCalculator.Vehicles.Enums;

namespace CongestionTaxCalculator.Vehicles.Abstractions
{
    public abstract class Vehicle
    {
        public abstract ConcreteVehicleTypes GetVehicleType();
    }
}