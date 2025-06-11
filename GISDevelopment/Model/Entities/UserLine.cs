using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class UserLine: IHasTags
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public Geometry Geometry { get; set; }
    public string? Description { get; set; }
    public double Length { get; set; } = 0.0;
    public Dictionary<string, string>? Tags { get; set; }
}