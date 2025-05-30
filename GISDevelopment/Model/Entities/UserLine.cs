using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class UserLine
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public Geometry Geometry { get; set; }
    public string? Description { get; set; }
    public double Length { get; set; } = 0.0;
}