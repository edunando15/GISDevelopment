using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class MunicipalityDTO : IGenericDTO<Municipality>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Geometry Geometry { get; set; }
    
    public MunicipalityDTO() { }
    
    public MunicipalityDTO(Municipality municipality)
    {
        Id = municipality.Id;
        Name = municipality.Name;
        Geometry = municipality.Geometry;
    }
    
    public Municipality ToEntity()
    {
        return new Municipality()
        {
            Id = Id,
            Name = Name,
            Geometry = Geometry
        };
    }
}