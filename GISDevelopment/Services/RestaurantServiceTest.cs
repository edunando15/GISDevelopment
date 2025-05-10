using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Services;

public class RestaurantServiceTest : IGenericService<Restaurant, RestaurantDTO>
{
    public RestaurantServiceTest(DbContext context) : base(context)
    {
    }
}