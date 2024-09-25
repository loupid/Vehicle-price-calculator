namespace progi.Server.Models;

public abstract class Car(decimal basePrice) : ICar
{
    public decimal BasePrice { get; } = basePrice;

    protected abstract decimal SpecialRate { get; }

    private static decimal BasicRate => 0.1m;

    public PriceCalculationResult CalculatePrice(PriceCalculationRequest? request)
    {
        var basicCharge = CalculateBasicCharge();
        var specialCharge = CalculateSpecialCharge();
        var associationCharge = CalculateAssociationCharge();

        var result = new PriceCalculationResult
        {
            Basic = basicCharge,
            Special = specialCharge,
            Association = associationCharge
        };

        result.Total = CalculateTotalPrice(result);
        return result;
    }

    public decimal CalculateAssociationCharge()
    {
        return BasePrice switch
        {
            >= 1 and <= 500 => 5,
            > 500 and <= 1000 => 10,
            > 1000 and <= 3000 => 15,
            > 3000 => 20,
            _ => 0
        };
    }

    protected virtual decimal CalculateBasicCharge() => BasePrice * BasicRate;

    private decimal CalculateSpecialCharge() => BasePrice * SpecialRate;

    private decimal CalculateTotalPrice(PriceCalculationResult result)
    {
        return BasePrice + result.Basic + result.Special + result.Association + result.Storage;
    }
}