using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class ShopController: IGenericAPIController<Shop, ShopDTO>
{
    public ShopController(IGenericService<Shop, ShopDTO> service) : base(service) { }
}