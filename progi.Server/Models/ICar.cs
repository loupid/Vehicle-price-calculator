namespace progi.Server.Models;

public interface ICar
{
    decimal BasePrice { get; }
    PriceCalculationResult CalculatePrice(PriceCalculationRequest? request);
    decimal CalculateAssociationCharge();
}