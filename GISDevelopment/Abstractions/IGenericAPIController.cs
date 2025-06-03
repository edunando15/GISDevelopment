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
    /// Method used to get all entities from the database.
    /// </summary>
    /// <returns> All DTOs representing the entities in the database. </returns>
    [HttpGet("GetAll")]
    public virtual IActionResult GetAll()
    {
        try
        {
            var dtos = _service.GetAll().ToList();
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
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
    
    /// <summary>
    /// Method used to add a DTO to the database.
    /// </summary>
    /// <param name="dto"> DTO representing the entity. </param>
    /// <returns> Created if the entity was added, Bad Request otherwise. </returns>
    [HttpPost("Add")]
    public virtual IActionResult Add([FromBody] D dto)
    {
        if (dto == null)
        {
            return BadRequest("DTO cannot be null.");
        }

        try
        {
            _service.Add(dto);
            return Ok();
        }catch (Exception ex)
        {
            // log ex.Message, ex.StackTrace if needed
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Method used to update an entity in the database.
    /// </summary>
    /// <param name="dto"> DTO representing the entity. </param>
    /// <returns> Bad Request if the entity is null, Internal Server Error
    /// if some error occurred, Ok otherwise. </returns>
    [HttpPut("Edit")]
    public virtual IActionResult Edit([FromBody] D dto)
    {
        if (dto == null)
        {
            return BadRequest("DTO cannot be null.");
        }

        try
        {
            _service.Update(dto);
            return Ok();
        }catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public virtual IActionResult Delete(long id)
    {
        try
        {
            _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Server error: " + ex.Message);
        }
    }
    
}