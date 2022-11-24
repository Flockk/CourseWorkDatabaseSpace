﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Space.Models
{
    public partial class PlanetarySystems
    {
        public PlanetarySystems()
        {
            Stars = new HashSet<Stars>();
        }

        public int PlanetsystemId { get; set; }
        public int? ConsId { get; set; }
        public int? GlxId { get; set; }
        public string PlanetsystemName { get; set; }
        public byte PlanetsystemConfirmedPlanets { get; set; }

        public virtual Constellations Cons { get; set; }
        public virtual Galaxies Glx { get; set; }
        public virtual ICollection<Stars> Stars { get; set; }
    }
}