namespace progi.Server.Models;

public class LuxuryCar(decimal basePrice) : Car(basePrice)
{
    protected override decimal SpecialRate => 0.04m;

    protected override decimal CalculateBasicCharge()
    {
        var basicCharge = base.CalculateBasicCharge();

        return basicCharge switch
        {
            < 25 => 25m,
            > 200 => 200m,
            _ => base.CalculateBasicCharge()
        };
    }
}