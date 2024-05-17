namespace CongestionTaxCalculator.TaxCalculator.Contracts
{
    public interface ITaxCalculator
    {
        int GetTax(CalculateTaxDto input);
    }
}