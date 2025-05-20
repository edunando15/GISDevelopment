using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Controllers;

public class PlaceOfWorshipController: IGenericController<PlaceOfWorship, PlaceOfWorshipDTO>
{
    public PlaceOfWorshipController(IGenericService<PlaceOfWorship, PlaceOfWorshipDTO> service, ItalyCentreContext context) : base(service, context) { }

    public override IActionResult Index()
    {
        var placesOfWorship = _service.GetAll().OrderBy(p => p.Name);
        return View("PlaceOfWorship", placesOfWorship);
    }
}