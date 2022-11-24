﻿#nullable disable
using System;
using System.Collections.Generic;

namespace Space.Models;

public partial class GalaxyGroups
{
    public int GlxgroupId { get; set; }

    public int? ConsId { get; set; }

    public string GlxgroupName { get; set; }

    public string GlxgroupType { get; set; }

    public TimeSpan? GlxgroupRightAscension { get; set; }

    public string GlxgroupDeclination { get; set; }

    public double? GlxgroupRedshift { get; set; }

    public virtual Constellations Cons { get; set; }

    public virtual ICollection<Galaxies> Galaxies { get; } = new List<Galaxies>();
}