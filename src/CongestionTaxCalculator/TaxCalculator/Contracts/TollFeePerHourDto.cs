using System;

namespace CongestionTaxCalculator.TaxCalculator.Contracts
{
    public class TollFeePerHourDto
    {
        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public int TollFee { get; private set; }

        public TollFeePerHourDto(TimeSpan startTime, TimeSpan endTime, int tollFee)
        {
            StartTime = startTime;
            EndTime = endTime;
            TollFee = tollFee;
        }
    }
}
