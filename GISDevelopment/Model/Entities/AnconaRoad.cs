using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public partial class AnconaRoad
{
    public long? OsmId { get; set; }

    public string? Highway { get; set; }

    public double? Cost { get; set; }

    public string? Name { get; set; }

    public string? Ref { get; set; }

    public string? IntRef { get; set; }

    public string? NatRef { get; set; }

    public string? LocName { get; set; }

    public Dictionary<string, string>? Tags { get; set; }

    public Geometry? Way { get; set; }

    public long? Source { get; set; }

    public long? Target { get; set; }
}
