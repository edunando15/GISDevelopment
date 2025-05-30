using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class UserPointService: IGenericService<UserPoint, UserPointDTO>
{
    public UserPointService(DbContext context) : base(context) { }
}