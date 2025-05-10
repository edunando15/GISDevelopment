using NetTopologySuite.Geometries;
using GISDevelopment.Abstractions;

namespace GISDevelopment.Models.DTOs;

public class RestaurantDTO: IGenericDTO<Restaurant, RestaurantDTO>
{
    public long? OsmId { get; set; }
    public string? Amenity { get; set; }
    public string? Denomination { get; set; }
    public string? Layer { get; set; }
    public string? Name { get; set; }
    public Point? Way { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    
    public RestaurantDTO() { }
    
    public RestaurantDTO(Restaurant restaurant)
    {
        OsmId = restaurant.OsmId;
        Amenity = restaurant.Amenity;
        Denomination = restaurant.Denomination;
        Layer = restaurant.Layer;
        Name = restaurant.Name;
        Tags = restaurant.Tags;
        Way = restaurant.Way;
    }
    
    public Restaurant ToEntity()
    {
        return new Restaurant()
        {
            OsmId = OsmId,
            Amenity = Amenity,
            Denomination = Denomination,
            Layer = Layer,
            Name = Name,
            Tags = Tags,
            Way = Way
        };
    }

    public static RestaurantDTO FromEntity(Restaurant entity)
    {
        return new RestaurantDTO(entity);
    }
}