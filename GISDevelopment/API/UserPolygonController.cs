using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class UserPolygonController: IGenericAPIController<UserPolygon, UserPolygonDTO>
{
    public UserPolygonController(IGenericService<UserPolygon, UserPolygonDTO> service) : base(service) { }
}