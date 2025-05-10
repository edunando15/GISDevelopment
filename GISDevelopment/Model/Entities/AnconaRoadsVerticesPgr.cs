using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace GISDevelopment.Models;

public partial class AnconaRoadsVerticesPgr
{
    public long Id { get; set; }

    public int? Cnt { get; set; }

    public int? Chk { get; set; }

    public int? Ein { get; set; }

    public int? Eout { get; set; }

    public Point? TheGeom { get; set; }
}
