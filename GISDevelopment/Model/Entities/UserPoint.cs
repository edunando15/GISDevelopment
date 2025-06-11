using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

/// <summary>
/// Class used to represent a point created by a user.
/// </summary>
public class UserPoint: IHasTags
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Point Point { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
}