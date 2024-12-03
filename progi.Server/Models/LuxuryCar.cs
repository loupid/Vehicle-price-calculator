namespace progi.Server.Models;

public class LuxuryCar(int basePrice) : Car(basePrice)
{
    protected override decimal SpecialRate => 0.04m;

    public override decimal CalculateBasicCharge()
    {
        var basicCharge = base.CalculateBasicCharge();

        return basicCharge switch
        {
            < 25 => 10m,
            > 200 => 50m,
            _ => base.CalculateBasicCharge()
        };
    }
}