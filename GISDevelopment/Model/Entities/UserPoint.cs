using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

/// <summary>
/// Class used to represent a point created by a user.
/// </summary>
public class UserPoint
{
    public long? Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public Point Point { get; set; }
}