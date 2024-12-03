namespace progi.Server.Models;

public interface ICar
{
    int BasePrice { get; }
    PriceCalculationResult CalculatePrice(PriceCalculationRequest? request);
    decimal CalculateAssociationCharge();
}