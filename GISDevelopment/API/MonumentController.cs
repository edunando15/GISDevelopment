using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class MonumentController: IGenericAPIController<Monument, MonumentDTO>
{
    public MonumentController(IGenericService<Monument, MonumentDTO> service) : base(service) { }
}