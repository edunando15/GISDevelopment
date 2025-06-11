using GISDevelopment.Abstractions;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class Municipality: IHasTags
{
    public long? Id { get; set; }
    
    public string Name { get; set; }
    
    public Geometry Geometry { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
}