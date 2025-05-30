using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class UserLineDTO: IGenericDTO<UserLine, UserLineDTO>
{
    public Geometry Geometry { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public UserLine ToEntity()
    {
        return new UserLine()
        {
            Id = Id,
            Name = Name,
            Geometry = Geometry
        };
    }
    public static UserLineDTO FromEntity(UserLine entity)
    {
        return new UserLineDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
            Geometry = entity.Geometry
        };
    }
}