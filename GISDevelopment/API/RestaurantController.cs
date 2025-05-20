using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController: IGenericAPIController<Restaurant, RestaurantDTO>
{
    public RestaurantController(IGenericService<Restaurant, RestaurantDTO> service) : base(service) { }
}