using CongestionTaxCalculator.TaxCalculator.Contracts;
using CongestionTaxCalculator.TaxCalculator.Services;
using CongestionTaxCalculator.Vehicles.ConcreteTypes;

namespace CongestionTaxCalculator.UnitTests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void GetTax_Should_CalculateTax_WhenVehicleIsNotTollFree()
        {
            // Arrange

            var dates = new List<DateTime>
            {
                new DateTime(2024,5,16,6,15,0),
                new DateTime(2024,5,16,6,25,0),
                new DateTime(2024,5,16,7,10,0),

                new DateTime(2024,5,16,7,30,0),
                new DateTime(2024,5,16,8,15,0),

                new DateTime(2024,5,16,11,00,0),

                new DateTime(2024,5,16,13,15,0)
            };
            var tollFeePerHourSettings = new List<TollFeePerHourDto>()
               {
                   new TollFeePerHourDto(new TimeSpan(6, 0, 0) ,new TimeSpan(6, 29, 0),8),
                   new TollFeePerHourDto(new TimeSpan(6, 30, 0) ,new TimeSpan(6, 59, 0),13),
                   new TollFeePerHourDto(new TimeSpan(7, 0, 0) ,new TimeSpan(7, 59, 0),18),
                   new TollFeePerHourDto(new TimeSpan(8, 0, 0) ,new TimeSpan(8, 29, 0),13),
                   new TollFeePerHourDto( new TimeSpan(8, 30, 0),new TimeSpan(14, 59, 0),8),
                   new TollFeePerHourDto(new TimeSpan(15, 0, 0) , new TimeSpan(15, 29, 0),13),
                   new TollFeePerHourDto (new TimeSpan(15, 30, 0) ,new TimeSpan(16, 59, 0),18),
                   new TollFeePerHourDto (new TimeSpan(17, 0, 0) ,new TimeSpan(17, 59, 0),13),
                   new TollFeePerHourDto ( new TimeSpan(18, 0, 0), new TimeSpan(18, 29, 0),13),
                   new TollFeePerHourDto (new TimeSpan(18, 30, 0), new TimeSpan(23, 59, 0),8),
                   new TollFeePerHourDto (new TimeSpan(0, 0, 0) ,new TimeSpan(5, 59, 0),8),
               };
            var tollFreeVehicles = new List<string>
            {
                "Motorcycle" ,
                "Tractor" ,
                "Emergency",
                "Diplomat",
                "Foreign" ,
                "Military",
            };
            var tollFreeDates = new List<DateTime>
            {
                new DateTime(2013,1,1),
                new DateTime(2013,3,28),
                new DateTime(2013,3,29),
                new DateTime(2013,4,1),
                new DateTime(2013,4,30),
                new DateTime(2013,5,1),
                new DateTime(2013,5,8),
                new DateTime(2013,5,9),
                new DateTime(2013,6,5),
                new DateTime(2013,6,6),
                new DateTime(2013,6,21),
                new DateTime(2013,11,1),
                new DateTime(2013,12,24),
                new DateTime(2013,12,25),
                new DateTime(2013,12,26),
                new DateTime(2013,12,31),
            };
            var julyDateRange = Enumerable.Range(0, DateTime.DaysInMonth(2013, 7))
                       .Select(i => new DateTime(2013, 7, 1).AddDays(i))
                       .ToList();

            tollFreeDates.AddRange(julyDateRange);

            var taxCalculatorInput = new CalculateTaxDto()
            {
                Vehicle = new Car(),
                Dates = dates,
                Rules = new CalculateTaxRulesDto()
                {
                    MaxSEK = 60,
                    SingleChargeMinutes = 60,
                    TollFeePerHourSettings = tollFeePerHourSettings,
                    TollFreeWeekDays = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday },
                    TollFreeVehicles = tollFreeVehicles,
                    TollFreeDates = tollFreeDates,
                }
            };
            var taxCalculator = new TaxCalculatorService();

            // Act
            var tax = taxCalculator.GetTax(taxCalculatorInput);

            // Assert
            Assert.Equal(52, tax);
        }
    }
}