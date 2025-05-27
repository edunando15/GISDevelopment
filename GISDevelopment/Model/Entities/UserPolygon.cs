using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class UserPolygon
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Geometry Geometry { get; set; }
}