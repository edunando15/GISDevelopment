using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class PlanetOsmPolygonController: IGenericAPIController<PlanetOsmPolygon, PlanetOsmPolygonDTO>
{
    public PlanetOsmPolygonController(IGenericService<PlanetOsmPolygon, PlanetOsmPolygonDTO> service) : base(service) { }
}