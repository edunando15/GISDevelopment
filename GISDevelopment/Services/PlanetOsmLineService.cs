using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class PlanetOsmLineService: IGenericService<PlanetOsmLine, PlanetOsmLineDTO>
{
    public PlanetOsmLineService(DbContext context) : base(context) { }
}