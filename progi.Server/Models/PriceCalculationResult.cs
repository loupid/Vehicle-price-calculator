using System.Text.Json;

namespace progi.Server.Models;

public class PriceCalculationResult
{
    public decimal Basic { get; set; }
    public decimal Special { get; set; }
    public decimal Association { get; set; }
    public int Storage => 100;
    public decimal Total { get; set; }
}