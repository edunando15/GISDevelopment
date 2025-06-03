using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class PlanetOsmPointController: IGenericAPIController<PlanetOsmPoint, PlanetOsmPointDTO>
{
    public PlanetOsmPointController(IGenericService<PlanetOsmPoint, PlanetOsmPointDTO> service) : base(service) { }

    /// <summary>
    /// Method used to get all restaurants from the database.
    /// </summary>
    /// <returns> A List containing all the points for which amenity is restaurant.</returns>
    [HttpGet]
    public IActionResult GetRestaurants()
    {
        var restaurants = _service.GetAll().Where(p => p.Tags.ContainsKey("amenity") && p.Tags["amenity"] == "restaurant").ToList();
        return Ok(restaurants);
    }

    [HttpGet]
    public IActionResult GetMonuments()
    {
        return Ok();
    }
}