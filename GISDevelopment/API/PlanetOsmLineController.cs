using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class PlanetOsmLineController: IGenericAPIController<PlanetOsmLine, PlanetOsmLineDTO>
{
    public PlanetOsmLineController(IGenericService<PlanetOsmLine, PlanetOsmLineDTO> service) : base(service) { }
}