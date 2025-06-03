using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class PlanetOsmPointService: IGenericService<PlanetOsmPoint, PlanetOsmPointDTO>
{
    public PlanetOsmPointService(DbContext context) : base(context) { }
}