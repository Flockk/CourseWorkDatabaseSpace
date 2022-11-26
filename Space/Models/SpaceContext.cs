﻿#nullable disable
using Microsoft.EntityFrameworkCore;

namespace Space.Models
{
    public partial class SpaceContext : DbContext
    {
        public SpaceContext()
        {
        }

        public SpaceContext(DbContextOptions<SpaceContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=BIMO\\SQLEXPRESS;Initial Catalog=Space;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        public virtual DbSet<Asteroids> Asteroids { get; set; }
        public virtual DbSet<BlackHoles> BlackHoles { get; set; }
        public virtual DbSet<Comets> Comets { get; set; }
        public virtual DbSet<Constellations> Constellations { get; set; }
        public virtual DbSet<Galaxies> Galaxies { get; set; }
        public virtual DbSet<GalaxyClusters> GalaxyClusters { get; set; }
        public virtual DbSet<GalaxyGroups> GalaxyGroups { get; set; }
        public virtual DbSet<Nebulae> Nebulae { get; set; }
        public virtual DbSet<PlanetarySystems> PlanetarySystems { get; set; }
        public virtual DbSet<Planets> Planets { get; set; }
        public virtual DbSet<StarClusters> StarClusters { get; set; }
        public virtual DbSet<Stars> Stars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asteroids>(entity =>
            {
                entity.HasKey(e => e.AstId);

                entity.HasIndex(e => e.AstName, "UQ__Asteroids_ast_name")
                    .IsUnique();

                entity.Property(e => e.AstId).HasColumnName("ast_id");

                entity.Property(e => e.AstArgumentOfPerihelion).HasColumnName("ast_argument_of_perihelion");

                entity.Property(e => e.AstDiameter).HasColumnName("ast_diameter");

                entity.Property(e => e.AstMeanAnomaly).HasColumnName("ast_mean_anomaly");

                entity.Property(e => e.AstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ast_name");

                entity.Property(e => e.AstOrbitalEccentricity).HasColumnName("ast_orbital_eccentricity");

                entity.Property(e => e.AstOrbitalInclination).HasColumnName("ast_orbital_inclination");

                entity.Property(e => e.StarId).HasColumnName("star_id");

                entity.HasOne(d => d.Star)
                    .WithMany(p => p.Asteroids)
                    .HasForeignKey(d => d.StarId)
                    .HasConstraintName("FK_Asteroids_Stars");
            });

            modelBuilder.Entity<BlackHoles>(entity =>
            {
                entity.HasKey(e => e.BlackHoleId);

                entity.HasIndex(e => e.BlackholeName, "UQ__BlackHoles_blackhole_name")
                    .IsUnique();

                entity.Property(e => e.BlackHoleId).HasColumnName("blackHole_id");

                entity.Property(e => e.BlackholeDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("blackhole_declination");

                entity.Property(e => e.BlackholeDistance).HasColumnName("blackhole_distance");

                entity.Property(e => e.BlackholeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("blackhole_name");

                entity.Property(e => e.BlackholeRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("blackhole_right_ascension");

                entity.Property(e => e.BlackholeType)
                    .HasMaxLength(14)
                    .HasColumnName("blackhole_type");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.BlackHoles)
                    .HasForeignKey(d => d.ConsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlackHoles_To_Constellations");

                entity.HasOne(d => d.Glx)
                    .WithMany(p => p.BlackHoles)
                    .HasForeignKey(d => d.GlxId)
                    .HasConstraintName("FK_BlackHoles_To_Galaxies");
            });

            modelBuilder.Entity<Comets>(entity =>
            {
                entity.HasKey(e => e.CometId);

                entity.HasIndex(e => e.CometName, "UQ__Comets__comet_name")
                    .IsUnique();

                entity.Property(e => e.CometId).HasColumnName("comet_id");

                entity.Property(e => e.CometEccentricity).HasColumnName("comet_eccentricity");

                entity.Property(e => e.CometName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("comet_name");

                entity.Property(e => e.CometOrbitalInclination).HasColumnName("comet_orbital_inclination");

                entity.Property(e => e.CometOrbitalPeriod).HasColumnName("comet_orbital_period");

                entity.Property(e => e.CometPerihelion).HasColumnName("comet_perihelion");

                entity.Property(e => e.CometSemiMajorAxis).HasColumnName("comet_semi_major_axis");

                entity.Property(e => e.StarId).HasColumnName("star_id");

                entity.HasOne(d => d.Star)
                    .WithMany(p => p.Comets)
                    .HasForeignKey(d => d.StarId)
                    .HasConstraintName("FK_Comets_Stars");
            });

            modelBuilder.Entity<Constellations>(entity =>
            {
                entity.HasKey(e => e.ConsId);

                entity.HasIndex(e => e.ConsName, "UQ_Constellations_cons_name")
                    .IsUnique();

                entity.HasIndex(e => e.ConsAbbreviation, "UQ_Constellations_cons_abbreviation")
                    .IsUnique();

                entity.HasIndex(e => e.ConsSymbolism, "UQ_Constellations_cons_symbolism")
                    .IsUnique();

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.ConsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cons_name");

                entity.Property(e => e.ConsAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("cons_abbreviation");

                entity.Property(e => e.ConsDeclination)
                    .HasMaxLength(15)
                    .HasColumnName("cons_declination");

                entity.Property(e => e.ConsRightAscension)
                    .HasMaxLength(17)
                    .HasColumnName("cons_right_ascension");

                entity.Property(e => e.ConsSquare).HasColumnName("cons_square");

                entity.Property(e => e.ConsSymbolism)
                    .IsRequired()
                    .HasMaxLength(22)
                    .HasColumnName("cons_symbolism");

                entity.Property(e => e.ConsVisibleInLatitudes)
                    .HasMaxLength(15)
                    .HasColumnName("cons_visible_in_latitudes");

                entity.Property(e => e.ConsImage)
                    .HasMaxLength(50)
                    .HasColumnName("cons_image");
            });

            modelBuilder.Entity<Galaxies>(entity =>
            {
                entity.HasKey(e => e.GlxId)
                    .HasName("PK__Galaxies");

                entity.HasIndex(e => e.GlxName, "UQ_Galaxies_glx_name")
                    .IsUnique();

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxApparentMagnitude).HasColumnName("glx_apparent_magnitude");

                entity.Property(e => e.GlxDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("glx_declination");

                entity.Property(e => e.GlxDistance).HasColumnName("glx_distance");

                entity.Property(e => e.GlxName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("glx_name");

                entity.Property(e => e.GlxRadialVelocity).HasColumnName("glx_radial_velocity");

                entity.Property(e => e.GlxRadius).HasColumnName("glx_radius");

                entity.Property(e => e.GlxRedshift).HasColumnName("glx_redshift");

                entity.Property(e => e.GlxRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("glx_right_ascension");

                entity.Property(e => e.GlxType)
                    .HasMaxLength(14)
                    .HasColumnName("glx_type");

				entity.Property(e => e.GlxImage)
	                .HasMaxLength(50)
	                .HasColumnName("glx_image");

				entity.Property(e => e.GlxclusterId).HasColumnName("glxcluster_id");

                entity.Property(e => e.GlxgroupId).HasColumnName("glxgroup_id");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.Galaxies)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_Galaxies_To_Constellations");

                entity.HasOne(d => d.Glxcluster)
                    .WithMany(p => p.Galaxies)
                    .HasForeignKey(d => d.GlxclusterId)
                    .HasConstraintName("FK_Galaxies_To_GalaxyClusters");

                entity.HasOne(d => d.Glxgroup)
                    .WithMany(p => p.Galaxies)
                    .HasForeignKey(d => d.GlxgroupId)
                    .HasConstraintName("FK_Galaxies_To_GalaxyGroups");
            });

            modelBuilder.Entity<GalaxyClusters>(entity =>
            {
                entity.HasKey(e => e.GlxclusterId);

                entity.HasIndex(e => e.GlxclusterName, "UQ_GalaxyClusters_glxcluster_name")
                    .IsUnique();

                entity.Property(e => e.GlxclusterId).HasColumnName("glxcluster_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxclusterDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("glxcluster_declination");

                entity.Property(e => e.GlxclusterName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("glxcluster_name");

                entity.Property(e => e.GlxclusterRedshift).HasColumnName("glxcluster_redshift");

                entity.Property(e => e.GlxclusterRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("glxcluster_right_ascension");

                entity.Property(e => e.GlxclusterType)
                    .HasMaxLength(20)
                    .HasColumnName("glxcluster_type");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.GalaxyClusters)
                    .HasForeignKey(d => d.ConsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GalaxyClusters_To_Constellations");
            });

            modelBuilder.Entity<GalaxyGroups>(entity =>
            {
                entity.HasKey(e => e.GlxgroupId);

                entity.HasIndex(e => e.GlxgroupName, "UQ_GalaxyGroups_glxgroup_name")
                    .IsUnique();

                entity.Property(e => e.GlxgroupId).HasColumnName("glxgroup_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxgroupDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("glxgroup_declination");

                entity.Property(e => e.GlxgroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("glxgroup_name");

                entity.Property(e => e.GlxgroupRedshift).HasColumnName("glxgroup_redshift");

                entity.Property(e => e.GlxgroupRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("glxgroup_right_ascension");

                entity.Property(e => e.GlxgroupType)
                    .HasMaxLength(11)
                    .HasColumnName("glxgroup_type");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.GalaxyGroups)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_GalaxyGroups_To_Constellations");
            });

            modelBuilder.Entity<Nebulae>(entity =>
            {
                entity.HasKey(e => e.NebulaId)
                    .HasName("PK__Nebulae");

                entity.HasIndex(e => e.NebulaName, "UQ_Nebulae_nebula_name")
                    .IsUnique();

                entity.Property(e => e.NebulaId).HasColumnName("nebula_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.Property(e => e.NebulaDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("nebula_declination");

                entity.Property(e => e.NebulaDistance).HasColumnName("nebula_distance");

                entity.Property(e => e.NebulaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nebula_name");

                entity.Property(e => e.NebulaRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("nebula_right_ascension");

                entity.Property(e => e.NebulaType)
                    .HasMaxLength(20)
                    .HasColumnName("nebula_type");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.Nebulae)
                    .HasForeignKey(d => d.ConsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nebulae_To_Constellations");

                entity.HasOne(d => d.Glx)
                    .WithMany(p => p.Nebulae)
                    .HasForeignKey(d => d.GlxId)
                    .HasConstraintName("FK_Nebulae_Galaxies");
            });

            modelBuilder.Entity<PlanetarySystems>(entity =>
            {
                entity.HasKey(e => e.PlanetsystemId);

                entity.HasIndex(e => e.PlanetsystemName, "UQ_PlanetarySystems_planetsystem_name")
                    .IsUnique();

                entity.Property(e => e.PlanetsystemId).HasColumnName("planetsystem_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.Property(e => e.PlanetsystemConfirmedPlanets).HasColumnName("planetsystem_confirmed_planets");

                entity.Property(e => e.PlanetsystemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("planetsystem_name");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.PlanetarySystems)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_PlanetarySystems_To_Constellations");

                entity.HasOne(d => d.Glx)
                    .WithMany(p => p.PlanetarySystems)
                    .HasForeignKey(d => d.GlxId)
                    .HasConstraintName("FK_PlanetarySystems_Galaxies");
            });

            modelBuilder.Entity<Planets>(entity =>
            {
                entity.HasKey(e => e.PlntId);

                entity.HasIndex(e => e.PlntName, "UQ_Planets_exo_name")
                    .IsUnique();

                entity.Property(e => e.PlntId).HasColumnName("plnt_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.PlntArgumentOfPerihelion).HasColumnName("plnt_argument_of_perihelion");

                entity.Property(e => e.PlntEccentricity).HasColumnName("plnt_eccentricity");

                entity.Property(e => e.PlntMass).HasColumnName("plnt_mass");

                entity.Property(e => e.PlntName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("plnt_name");

                entity.Property(e => e.PlntOrbitalPeriod).HasColumnName("plnt_orbital_period");

                entity.Property(e => e.PlntSemiMajorAxis).HasColumnName("plnt_semi_major_axis");

                entity.Property(e => e.StarId).HasColumnName("star_id");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_Planets_To_Constellations");

                entity.HasOne(d => d.Star)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.StarId)
                    .HasConstraintName("FK_Planets_Stars");
            });

            modelBuilder.Entity<StarClusters>(entity =>
            {
                entity.HasKey(e => e.StarclusterId);

                entity.HasIndex(e => e.StarclusterName, "UQ_StarClusters_starcluster_name")
                    .IsUnique();

                entity.Property(e => e.StarclusterId).HasColumnName("starcluster_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.Property(e => e.StarclusterAge).HasColumnName("starcluster_age");

                entity.Property(e => e.StarclusterDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("starcluster_declination");

                entity.Property(e => e.StarclusterDiameter).HasColumnName("starcluster_diameter");

                entity.Property(e => e.StarclusterDistance).HasColumnName("starcluster_distance");

                entity.Property(e => e.StarclusterName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("starcluster_name");

                entity.Property(e => e.StarclusterRightAscension)
                    .HasColumnType("time(0)")
                    .HasColumnName("starcluster_right_ascension");

                entity.Property(e => e.StarclusterType)
                    .HasMaxLength(20)
                    .HasColumnName("starcluster_type");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.StarClusters)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_StarClusters_To_Constellations");

                entity.HasOne(d => d.Glx)
                    .WithMany(p => p.StarClusters)
                    .HasForeignKey(d => d.GlxId)
                    .HasConstraintName("FK_StarClusters_Galaxies");
            });

            modelBuilder.Entity<Stars>(entity =>
            {
                entity.HasKey(e => e.StarId);

                entity.HasIndex(e => e.StarName, "UQ_Stars_star_name")
                    .IsUnique();

                entity.Property(e => e.StarId).HasColumnName("star_id");

                entity.Property(e => e.ConsId).HasColumnName("cons_id");

                entity.Property(e => e.GlxId).HasColumnName("glx_id");

                entity.Property(e => e.PlanetsystemId).HasColumnName("planetsystem_id");

                entity.Property(e => e.StarApparentMagnitude).HasColumnName("star_apparent_magnitude");

                entity.Property(e => e.StarDeclination)
                    .HasMaxLength(20)
                    .HasColumnName("star_declination");

                entity.Property(e => e.StarDistance).HasColumnName("star_distance");

                entity.Property(e => e.StarName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("star_name");

                entity.Property(e => e.StarStellarClass)
                    .HasMaxLength(10)
                    .HasColumnName("star_stellar_class");

                entity.Property(e => e.StarclusterId).HasColumnName("starcluster_id");

                entity.HasOne(d => d.Cons)
                    .WithMany(p => p.Stars)
                    .HasForeignKey(d => d.ConsId)
                    .HasConstraintName("FK_Stars_Constellations");

                entity.HasOne(d => d.Glx)
                    .WithMany(p => p.Stars)
                    .HasForeignKey(d => d.GlxId)
                    .HasConstraintName("FK_Stars_To_Galaxies");

                entity.HasOne(d => d.Planetsystem)
                    .WithMany(p => p.Stars)
                    .HasForeignKey(d => d.PlanetsystemId)
                    .HasConstraintName("FK_Stars_To_PlanetarySystems");

                entity.HasOne(d => d.Starcluster)
                    .WithMany(p => p.Stars)
                    .HasForeignKey(d => d.StarclusterId)
                    .HasConstraintName("FK_Stars_To_StarClusters");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}