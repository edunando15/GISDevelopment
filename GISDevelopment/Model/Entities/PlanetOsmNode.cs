using System;
using System.Collections.Generic;

namespace GISDevelopment.Models;

public partial class PlanetOsmNode
{
    public long Id { get; set; }

    public int Lat { get; set; }

    public int Lon { get; set; }

    public string? Tags { get; set; }
}
