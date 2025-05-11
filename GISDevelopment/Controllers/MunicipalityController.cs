using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.Controllers;

public class MunicipalityController : Controller
{
    private readonly IGenericService<Municipality, MunicipalityDTO> _service;
    private readonly DatabaseContext _context;
    
    public MunicipalityController(IGenericService<Municipality, MunicipalityDTO> service, DatabaseContext context)
    {
        _context = context;
        _service = service;
    }
    
    public IActionResult Index()
    {
        var municipalities = _service.GetAll();
        return View("Municipalities", municipalities);
    }
}