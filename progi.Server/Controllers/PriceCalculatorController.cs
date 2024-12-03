using Microsoft.AspNetCore.Mvc;
using progi.Server.Models;

namespace progi.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceCalculatorController(ILogger<PriceCalculatorController> logger) : ControllerBase
{
    private readonly ILogger<PriceCalculatorController> _logger = logger;

    [HttpPost(Name = "PostPriceCalculator")]
    [ProducesResponseType(typeof(PriceCalculationResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult PriceCalculator([FromBody] PriceCalculationRequest request)
    {
        ICar car;
        switch (request.VehicleType)
        {
            case "Common":
            {
                car = new CommonCar(request.BasePrice);
                break;
            }
            case "Luxury":
            {
                car = new LuxuryCar(request.BasePrice);
                break;
            }
            default: return Results.NotFound();
        }

        return Results.Ok(car.CalculatePrice(request));
    }
}