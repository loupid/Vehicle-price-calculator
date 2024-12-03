namespace progi.Server.Models;

public class PriceCalculationResult
{
    public double Basic { get; set; }
    public double Special { get; set; }
    public double Association { get; set; }
    public int Storage => 100;
    public double Total { get; set; }
}