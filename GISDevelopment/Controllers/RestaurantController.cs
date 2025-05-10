using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using GISDevelopment.Services;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.Controllers;

public class RestaurantController : Controller
{
    private readonly IGenericService<Restaurant, RestaurantDTO> _service;
    private readonly ItalyCentreContext _context;
    
    public RestaurantController(IGenericService<Restaurant, RestaurantDTO> service, ItalyCentreContext context)
    {
        _context = context;
        _service = service;
    }
    
    public IActionResult Index()
    {
        var restaurants = _service.GetAll();
        return View("Restaurants", restaurants);
    }
}