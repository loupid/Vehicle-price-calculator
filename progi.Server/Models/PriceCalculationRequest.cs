namespace progi.Server.Models;

public class PriceCalculationRequest
{
    public required decimal BasePrice { get; set; }
    public required string VehicleType { get; set; }
}