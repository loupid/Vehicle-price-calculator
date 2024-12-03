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
    public IResult PriceCalculator([FromBody] PriceCalculationRequest? request)
    {
        if (request is null) return Results.NotFound();

        ICar? car = request.VehicleType switch
        {
            "Common" => new CommonCar(request.BasePrice),
            "Luxury" => new LuxuryCar(request.BasePrice),
            _ => null
        };

        return car == null ? Results.NotFound() : Results.Ok(car.CalculatePrice(request));
    }
}