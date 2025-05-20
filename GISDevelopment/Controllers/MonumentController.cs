using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using GISDevelopment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Controllers;

public class MonumentController: IGenericController<Monument, MonumentDTO>
{
    public MonumentController(IGenericService<Monument, MonumentDTO> service, ItalyCentreContext context) : base(service, context) { }
    
    public override IActionResult Index()
    {
        var monuments = _service.GetAll().OrderBy(m => m.Name);
        return View("Monuments", monuments);
    }
}