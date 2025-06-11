using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Abstractions;

public class IGenericController<T, D> : Controller
    where T : class, IHasTags
    where D : IGenericDTO<T, D>
{
    protected readonly IGenericService<T, D> _service;
    protected readonly DbContext _context;
    public IGenericController(IGenericService<T, D> service, DbContext context)
    {
        _context = context;
        _service = service;
    }
    public virtual IActionResult Index()
    {
        var entities = _service.GetAll().OrderBy(e => e.Name);
        return View("Index", entities);
    }
}