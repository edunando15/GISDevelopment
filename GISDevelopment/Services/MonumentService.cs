using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class MonumentService: IGenericService<Monument, MonumentDTO>
{
    public MonumentService(DbContext context) : base(context) { }
}