using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Controllers;

public class RestaurantController : IGenericController<Restaurant, RestaurantDTO>
{
    
    public RestaurantController(IGenericService<Restaurant, RestaurantDTO> service, ItalyCentreContext context): base(service, context) { }
    
    public override IActionResult Index()
    {
        var restaurants = _service.GetAll().OrderBy(r => r.Name);
        return View("Restaurants", restaurants);
    }
}