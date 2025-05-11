using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;

namespace GISDevelopment.APIControllers;

[ApiController]
[Route("api/[controller]")]
public class MunicipalityController : ControllerBase
{
    private readonly IGenericService<Municipality, MunicipalityDTO> _service;
    
    public MunicipalityController(IGenericService<Municipality, MunicipalityDTO> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Index(int id)
    {
        var dto = _service.Get(id);
        var wktWriter = new WKTWriter();
        string wkt = string.Empty;
        if(dto != null) wkt = wktWriter.Write(dto.Geometry);
        return Ok(wkt);
    }
}