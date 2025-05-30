using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class UserPolygonService: IGenericService<UserPolygon, UserPolygonDTO>
{
    public UserPolygonService(DbContext context) : base(context) { }
}