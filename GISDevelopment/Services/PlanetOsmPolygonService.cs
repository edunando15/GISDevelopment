using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class PlanetOsmPolygonService: IGenericService<PlanetOsmPolygon, PlanetOsmPolygonDTO>
{
    public PlanetOsmPolygonService(DbContext context) : base(context) { }
}