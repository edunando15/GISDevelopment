using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.Controllers;

public class UserController: Controller
{
    private readonly ItalyCentreContext _context;
    private readonly IGenericService<UserPoint, UserPointDTO> _userPointService;
    private readonly IGenericService<UserLine, UserLineDTO> _userLineService;
    private readonly IGenericService<UserPolygon, UserPolygonDTO> _userPolygonService;
    
    public UserController(ItalyCentreContext context, 
                          IGenericService<UserPoint, UserPointDTO> userPointService,
                          IGenericService<UserLine, UserLineDTO> userLineService,
                          IGenericService<UserPolygon, UserPolygonDTO> userPolygonService)
    {
        _context = context;
        _userPointService = userPointService;
        _userLineService = userLineService;
        _userPolygonService = userPolygonService;
    }

    public IActionResult Index()
    {
        var points = _userPointService.GetAll();
        var lines = _userLineService.GetAll();
        var polygons = _userPolygonService.GetAll();
        var result = new
        {
            Points = points,
            Lines = lines,
            Polygons = polygons
        };
        return View("UserEntities2", result);
    }
}