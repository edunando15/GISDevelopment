using System;
using System.Collections.Generic;

namespace GISDevelopment.Models;

public partial class PlanetOsmWay
{
    public long Id { get; set; }

    public List<long> Nodes { get; set; } = null!;

    public string? Tags { get; set; }
}
