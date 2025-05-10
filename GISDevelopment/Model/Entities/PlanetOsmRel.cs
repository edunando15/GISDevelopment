using System;
using System.Collections.Generic;

namespace GISDevelopment.Models;

public partial class PlanetOsmRel
{
    public long Id { get; set; }

    public string Members { get; set; } = null!;

    public string? Tags { get; set; }
}
