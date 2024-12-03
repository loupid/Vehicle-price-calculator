namespace progi.Server.Models;

public interface ICar
{
    int BasePrice { get; }

    PriceCalculationResult CalculatePrice(PriceCalculationRequest request);

    double CalculateAssociationCharge()
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
}