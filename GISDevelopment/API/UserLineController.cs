using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class UserLineController: IGenericAPIController<UserLine, UserLineDTO>
{
    public UserLineController(IGenericService<UserLine, UserLineDTO> service) : base(service) { }
}