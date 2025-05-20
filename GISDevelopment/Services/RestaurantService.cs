using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;

namespace GISDevelopment.Services;

public class RestaurantService: IGenericService<Restaurant, RestaurantDTO>
{
    public RestaurantService(ItalyCentreContext context) : base(context) { }
}