using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class PlaceOfWorshipService: IGenericService<PlaceOfWorship, PlaceOfWorshipDTO>
{
    public PlaceOfWorshipService(DbContext context) : base(context) { }
}