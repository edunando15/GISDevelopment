using GISDevelopment.Abstractions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Controllers;

public class ShopController: IGenericController<Shop, ShopDTO>
{
    public ShopController(IGenericService<Shop, ShopDTO> service, ItalyCentreContext context) : base(service, context) { }

    public override IActionResult Index()
    {
        var shops = _service.GetAll().OrderBy(p => p.Name);
        return View("Shop", shops);
    }
}