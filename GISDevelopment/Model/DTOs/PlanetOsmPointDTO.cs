using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class PlanetOsmPointDTO: IGenericDTO<PlanetOsmPoint, PlanetOsmPointDTO>
{
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public PlanetOsmPoint ToEntity()
    {
        return new PlanetOsmPoint()
        {
            OsmId = Id,
            Way = Geometry.InteriorPoint,
            Tags = Tags,
            Name = Name
        };
    }

    public static PlanetOsmPointDTO FromEntity(PlanetOsmPoint entity)
    {
        return new PlanetOsmPointDTO()
        {
            Id = entity.OsmId,
            Geometry = entity.Way,
            Tags = entity.Tags,
            Name = entity.Name
        };
    }
}