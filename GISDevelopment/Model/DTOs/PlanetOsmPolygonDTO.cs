using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class PlanetOsmPolygonDTO: IGenericDTO<PlanetOsmPolygon, PlanetOsmPolygonDTO>
{
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public PlanetOsmPolygon ToEntity()

    {
        return new PlanetOsmPolygon()
        {
            OsmId = Id,
            Way = Geometry,
            Tags = Tags,
            Name = Name
        };
    }

    public static PlanetOsmPolygonDTO FromEntity(PlanetOsmPolygon entity)
    {
        return new PlanetOsmPolygonDTO()
        {
            Id = entity.OsmId,
            Geometry = entity.Way,
            Tags = entity.Tags,
            Name = entity.Name
        };
    }
}