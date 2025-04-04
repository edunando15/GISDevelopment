using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GISDevelopment.Controllers;

public class MunicipalityController : Controller
{
    private readonly DatabaseContext _context;
    
    private readonly IMunicipalityService _municipalityService;
    
    public MunicipalityController(DatabaseContext context, IMunicipalityService municipalityService)
    {
        _context = context;
        _municipalityService = municipalityService;
    }

    public IActionResult Index()
    {
        List<MunicipalityDTO> municipalities = _municipalityService.GetAllMunicipalities();
        return View("Municipalities", municipalities);
    }
}