using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class UserPointDTO: IGenericDTO<UserPoint, UserPointDTO>
{
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public UserPoint ToEntity()
    {
        return new UserPoint()
        {
            Id = Id,
            Name = Name,
            Point = Geometry.InteriorPoint
        };
    }

    public static UserPointDTO FromEntity(UserPoint entity)
    {
        return new UserPointDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
            Geometry = entity.Point
        };
    }
}