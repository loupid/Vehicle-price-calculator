namespace progi.Server.Models;

public class CommonCar(int basePrice) : Car(basePrice)
{
    protected override decimal SpecialRate => 0.02m;

    public override decimal CalculateBasicCharge()
    {
        var basicCharge = base.CalculateBasicCharge();

        return basicCharge switch
        {
            < 10 => 10m,
            > 50 => 50m,
            _ => base.CalculateBasicCharge()
        };
    }
}