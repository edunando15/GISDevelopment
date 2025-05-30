using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.API;

[ApiController]
[Route("api/[controller]")]
public class UserPointController: IGenericAPIController<UserPoint, UserPointDTO>
{
    public UserPointController(IGenericService<UserPoint, UserPointDTO> service) : base(service) { }
}