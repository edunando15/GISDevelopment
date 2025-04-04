using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public class Municipality
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Geometry Geometry { get; set; }
}