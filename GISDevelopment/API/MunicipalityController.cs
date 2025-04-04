using GISDevelopment.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;

namespace GISDevelopment.APIControllers;

[ApiController]
[Route("api/[controller]")]
public class MunicipalityController : ControllerBase
{
    private readonly IMunicipalityService _municipalityService;
    
    public MunicipalityController(IMunicipalityService municipalityService)
    {
        _municipalityService = municipalityService;
    }

    [HttpGet("{id}")]
    public IActionResult Index(int id)
    {
        var dto = _municipalityService.GetMunicipality(id);
        var wktWriter = new WKTWriter();
        string wkt = string.Empty;
        if(dto != null) wkt = wktWriter.Write(dto.Geometry);
        return Ok(wkt);
    }
}