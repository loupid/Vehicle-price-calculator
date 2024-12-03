namespace progi.Server.Models;

public class PriceCalculationRequest
{
    public required int BasePrice { get; set; }
    public required string VehicleType { get; set; }
}