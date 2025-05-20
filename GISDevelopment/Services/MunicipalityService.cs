using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class MunicipalityService : IGenericService<Municipality, MunicipalityDTO>
{
    public MunicipalityService(DbContext context) : base(context) { }
}