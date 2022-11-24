﻿#nullable disable
using System;
using System.Collections.Generic;

namespace Space.Models;

public partial class Planets
{
    public int PlntId { get; set; }

    public int? ConsId { get; set; }

    public int? StarId { get; set; }

    public string PlntName { get; set; }

    public double? PlntEccentricity { get; set; }

    public double? PlntSemiMajorAxis { get; set; }

    public double? PlntOrbitalPeriod { get; set; }

    public double? PlntArgumentOfPerihelion { get; set; }

    public double? PlntMass { get; set; }

    public virtual Constellations Cons { get; set; }

    public virtual Stars Star { get; set; }
}