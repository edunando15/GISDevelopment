using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models.DTOs;

public class UserLineDTO: IGenericDTO<UserLineDTO, UserLineDTO>
{
    public Geometry Geometry { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public UserLineDTO ToEntity()
    {
        return new UserLineDTO()
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Geometry = Geometry
        };
    }

    public static UserLineDTO FromEntity(UserLineDTO entity)
    {
        return new UserLineDTO()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Geometry = entity.Geometry
        };
    }
}