using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class ShopDTO: IGenericDTO<Shop, ShopDTO>
{
    public long? Id { get; set; }
    public string? Amenity { get; set; }
    public string? Denomination { get; set; }
    public string? Layer { get; set; }
    public string? Name { get; set; }
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public Shop ToEntity()
    {
        return new Shop()
        {
            OsmId = Id,
            Amenity = Amenity,
            Denomination = Denomination,
            Layer = Layer,
            Name = Name,
            Tags = Tags,
            Way = Geometry.InteriorPoint
        };
    }

    public static ShopDTO FromEntity(Shop entity)
    {
        return new ShopDTO()
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