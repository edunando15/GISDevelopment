using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class PlaceOfWorshipController: IGenericAPIController<PlaceOfWorship, PlaceOfWorshipDTO>
{
    public PlaceOfWorshipController(IGenericService<PlaceOfWorship, PlaceOfWorshipDTO> service) : base(service) { }
}