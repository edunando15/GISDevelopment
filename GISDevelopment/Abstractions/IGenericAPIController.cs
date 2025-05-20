using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.IO;

namespace GISDevelopment.Abstractions;

/// <summary>
/// This abstract class represents a generic API controller.
/// </summary>
/// <typeparam name="T"> Type of real entities. </typeparam>
/// <typeparam name="D"> Type of DTO entities. </typeparam>
[ApiController]
public abstract class IGenericAPIController<T, D> : ControllerBase
    where T : class
    where D : IGenericDTO<T, D>
{
    protected readonly IGenericService<T, D> _service;

    public IGenericAPIController(IGenericService<T, D> service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Method used to get the WKT representation of an entity.
    /// </summary>
    /// <param name="id"> The id of the entity. </param>
    /// <returns> The string representation of the Geometry. </returns>
    [HttpGet("{id}")]
    public virtual IActionResult Index(long id)
    {
        var dto = _service.Get(id);
        var wktWriter = new WKTWriter();
        string wkt = string.Empty;
        if(dto != null) wkt = wktWriter.Write(dto.Geometry);
        return Ok(wkt);
    }
}