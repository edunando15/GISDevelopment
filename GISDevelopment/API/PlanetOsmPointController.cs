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
    
    [HttpGet][HttpPost("Search")]
    public override IActionResult Search([FromQuery] string name = "", [FromBody]Dictionary<string, string>? tags = null)
    {
        try
        {
            string query = "";
            if (tags != null)
            {
                if (tags.ContainsKey("Shop")) query = @"SELECT * FROM ""planet_osm_point"" WHERE shop is not null";
                if (tags.ContainsKey("Restaurant")) query = @"SELECT * FROM ""planet_osm_point"" WHERE amenity IN ('restaurant')";
                if (tags.ContainsKey("PlaceOfWorship")) query = @"SELECT * FROM ""planet_osm_point"" WHERE amenity IN ('crypt', 'monastery', 'place_of_worship', 'grave_yard', 'Mosque')";
                if (tags.ContainsKey("Monument")) query = @"SELECT * FROM ""planet_osm_point"" WHERE historic IN ('archaeological_site', 'memorial', 'milestone', 'military', 'monument', 'obelisk', 'temple', 'tomb', 'ancient path', 'antica_fontana')";
            }
            var results = _service.Search(name, query);
            var adaptedResults = results.Select(e => new
            {
                id = e.Id,
                name = e.Name,
                tags = e.Tags,
                geometry = new
                {
                    type = "Point",
                    coordinates = new[]
                    {
                        e.Geometry.Coordinate.X,
                        e.Geometry.Coordinate.Y
                    }
                }
            });
            return Ok(adaptedResults);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }
}