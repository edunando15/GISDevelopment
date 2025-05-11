using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class MunicipalityService : IGenericService<Municipality, MunicipalityDTO>
{
    private readonly DatabaseContext _context;
    
    public MunicipalityService(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}