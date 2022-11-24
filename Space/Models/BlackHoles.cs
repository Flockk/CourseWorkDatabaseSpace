﻿#nullable disable
using System;
using System.Collections.Generic;

namespace Space.Models;

public partial class BlackHoles
{
    public int BlackHoleId { get; set; }

    public int ConsId { get; set; }

    public int? GlxId { get; set; }

    public string BlackholeName { get; set; }

    public string BlackholeType { get; set; }

    public TimeSpan? BlackholeRightAscension { get; set; }

    public string BlackholeDeclination { get; set; }

    public double? BlackholeDistance { get; set; }

    public virtual Constellations Cons { get; set; }

    public virtual Galaxies Glx { get; set; }
}