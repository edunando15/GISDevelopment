using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class UserPolygonDTO: IGenericDTO<UserPolygon, UserPolygonDTO>
{
    public Geometry Geometry { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public UserPolygon ToEntity()
    {
        return new UserPolygon
        {
            Geometry = Geometry,
            Id = Id,
            Name = Name
        };
    }

    public static UserPolygonDTO FromEntity(UserPolygon entity)
    {
        return new UserPolygonDTO()
        {
            Geometry = entity.Geometry,
            Id = entity.Id,
            Name = entity.Name
        };
    }
}