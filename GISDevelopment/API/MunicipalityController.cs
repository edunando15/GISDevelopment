using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class MunicipalityController: IGenericAPIController<Municipality, MunicipalityDTO>
{
    public MunicipalityController(IGenericService<Municipality, MunicipalityDTO> service) : base(service) { }
}