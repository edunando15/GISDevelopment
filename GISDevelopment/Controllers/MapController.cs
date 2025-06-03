using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.Controllers;

public class MapController: Controller
{
    private readonly ItalyCentreContext _context;
    private readonly IGenericService<Monument, MonumentDTO> _monumentService;
    private readonly IGenericService<Restaurant, RestaurantDTO> _restaurantService;
    private readonly IGenericService<Shop, ShopDTO> _shopService;
    private readonly IGenericService<PlaceOfWorship, PlaceOfWorshipDTO> _placeOfWorshipService;
    
    public MapController(ItalyCentreContext context,
        IGenericService<Monument, MonumentDTO> monumentService,
        IGenericService<Restaurant, RestaurantDTO> restaurantService,
        IGenericService<Shop, ShopDTO> shopService,
        IGenericService<PlaceOfWorship, PlaceOfWorshipDTO> placeOfWorshipService)
    {
        _context = context;
        _monumentService = monumentService;
        _restaurantService = restaurantService;
        _shopService = shopService;
        _placeOfWorshipService = placeOfWorshipService;
    }
    
    public virtual IActionResult Index()
    {
        /*var monuments = _monumentService.GetAll();
        var restaurants = _restaurantService.GetAll();
        var shops = _shopService.GetAll();
        var placesOfWorship = _placeOfWorshipService.GetAll();
        var entities = new
        {
            Monuments = monuments,
            Restaurants = restaurants,
            Shops = shops,
            PlacesOfWorship = placesOfWorship
        };
        */
        return View("Map");
    }
}