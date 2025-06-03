using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class PlanetOsmLineDTO: IGenericDTO<PlanetOsmLine, PlanetOsmLineDTO>
{
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public PlanetOsmLine ToEntity()
    {
        return new PlanetOsmLine()
        {
            Way = new LineString(Geometry.Coordinates),
            Tags = Tags,
            OsmId = Id,
            Name = Name
        };
    }

    public static PlanetOsmLineDTO FromEntity(PlanetOsmLine entity)
    {
        return new PlanetOsmLineDTO()
        {
            Geometry = entity.Way,
            Tags = entity.Tags,
            Id = entity.OsmId,
            Name = entity.Name
        };
    }
}