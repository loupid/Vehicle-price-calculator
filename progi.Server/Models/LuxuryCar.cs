namespace progi.Server.Models;

public class LuxuryCar(int basePrice) : ICar
{
    private const double BasicRate = 0.1;
    private const double SpecialRate = 0.04;

    public int BasePrice { get; } = basePrice;

    public PriceCalculationResult CalculatePrice(PriceCalculationRequest request)
    {
        var basicCharge = CalculateBasicCharge();
        var specialCharge = CalculateSpecialCharge();
        var associationCharge = ((ICar) this).CalculateAssociationCharge();

        var result = new PriceCalculationResult
        {
            Basic = basicCharge,
            Special = specialCharge,
            Association = associationCharge
        };

        result.Total = CalculateTotalPrice(result);

        return result;
    }


    private double CalculateBasicCharge() => BasePrice * BasicRate;

    private double CalculateSpecialCharge() => BasePrice * SpecialRate;

    private double CalculateTotalPrice(PriceCalculationResult result) =>
        BasePrice + result.Basic + result.Special + result.Association + result.Storage;
}