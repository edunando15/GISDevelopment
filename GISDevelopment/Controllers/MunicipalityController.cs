using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Controllers;

public class MunicipalityController : IGenericController<Municipality, MunicipalityDTO>
{
    
    public MunicipalityController(IGenericService<Municipality, MunicipalityDTO> service, DatabaseContext context) : base(service, context) { }
    
    public override IActionResult Index()
    {
        var municipalities = _service.GetAll().OrderBy(m => m.Name);
        return View("Municipalities", municipalities);
    }
}