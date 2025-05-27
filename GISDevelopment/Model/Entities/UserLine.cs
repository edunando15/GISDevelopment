using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class UserLine
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Descrition { get; set; }
    public Geometry Geometry { get; set; }
    public double Length { get; set; } = 0.0;
}