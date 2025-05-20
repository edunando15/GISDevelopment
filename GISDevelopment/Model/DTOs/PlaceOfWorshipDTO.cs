using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class PlaceOfWorshipDTO: IGenericDTO<PlaceOfWorship, PlaceOfWorshipDTO>
{
    public long? Id { get; set; }
    public string? Amenity { get; set; }
    public string? Denomination { get; set; }
    public string? Layer { get; set; }
    public string? Name { get; set; }
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public PlaceOfWorship ToEntity()
    {
        return new PlaceOfWorship()
        {
            OsmId = Id,
            Amenity = Amenity,
            Denomination = Denomination,
            Layer = Layer,
            Name = Name,
            Way = Geometry.InteriorPoint,
            Tags = Tags
        };
    }

    public static PlaceOfWorshipDTO FromEntity(PlaceOfWorship entity)
    {
        return new PlaceOfWorshipDTO()
        {
            Id = entity.OsmId,
            Amenity = entity.Amenity,
            Denomination = entity.Denomination,
            Layer = entity.Layer,
            Name = entity.Name,
            Tags = entity.Tags,
            Geometry = entity.Way
        };
    }
}