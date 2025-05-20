using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class ShopService: IGenericService<Shop, ShopDTO>
{
    public ShopService(DbContext context) : base(context) { }
}