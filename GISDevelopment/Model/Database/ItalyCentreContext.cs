using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Models;

public partial class ItalyCentreContext : DbContext
{
    
    private readonly IConfiguration _configuration;

    public ItalyCentreContext(DbContextOptions<ItalyCentreContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<AnconaRoad> AnconaRoads { get; set; }

    public virtual DbSet<AnconaRoadsVerticesPgr> AnconaRoadsVerticesPgrs { get; set; }

    public virtual DbSet<Monument> Monuments { get; set; }

    public virtual DbSet<Osm2pgsqlProperty> Osm2pgsqlProperties { get; set; }

    public virtual DbSet<PlaceOfWorship> PlaceOfWorships { get; set; }

    public virtual DbSet<PlanetOsmLine> PlanetOsmLines { get; set; }

    public virtual DbSet<PlanetOsmNode> PlanetOsmNodes { get; set; }

    public virtual DbSet<PlanetOsmPoint> PlanetOsmPoints { get; set; }

    public virtual DbSet<PlanetOsmPolygon> PlanetOsmPolygons { get; set; }

    public virtual DbSet<PlanetOsmRel> PlanetOsmRels { get; set; }

    public virtual DbSet<PlanetOsmRoad> PlanetOsmRoads { get; set; }

    public virtual DbSet<PlanetOsmWay> PlanetOsmWays { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ItalyCentreConnection"), x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("pgrouting")
            .HasPostgresExtension("postgis");

        modelBuilder.Entity<AnconaRoad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ancona_roads");

            entity.HasIndex(e => e.OsmId, "ancona_roads_osm_id_idx");

            entity.HasIndex(e => e.Source, "ancona_roads_source_idx");

            entity.HasIndex(e => e.Target, "ancona_roads_target_idx");

            entity.HasIndex(e => e.Way, "ancona_roads_way_idx").HasMethod("gist");

            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.IntRef).HasColumnName("int_ref");
            entity.Property(e => e.LocName).HasColumnName("loc_name");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NatRef).HasColumnName("nat_ref");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Source).HasColumnName("source");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Target).HasColumnName("target");
            entity.Property(e => e.Way).HasColumnName("way");
        });

        modelBuilder.Entity<AnconaRoadsVerticesPgr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ancona_roads_vertices_pgr_pkey");

            entity.ToTable("ancona_roads_vertices_pgr");

            entity.HasIndex(e => e.TheGeom, "ancona_roads_vertices_pgr_the_geom_idx").HasMethod("gist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chk).HasColumnName("chk");
            entity.Property(e => e.Cnt).HasColumnName("cnt");
            entity.Property(e => e.Ein).HasColumnName("ein");
            entity.Property(e => e.Eout).HasColumnName("eout");
            entity.Property(e => e.TheGeom)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("the_geom");
        });

        modelBuilder.Entity<Monument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Monument");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("way");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<Osm2pgsqlProperty>(entity =>
        {
            entity.HasKey(e => e.Property).HasName("osm2pgsql_properties_pkey");

            entity.ToTable("osm2pgsql_properties");

            entity.Property(e => e.Property).HasColumnName("property");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<PlaceOfWorship>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PlaceOfWorship");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("way");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<PlanetOsmLine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("planet_osm_line");

            entity.HasIndex(e => e.OsmId, "planet_osm_line_osm_id_idx");

            entity.HasIndex(e => e.Way, "planet_osm_line_way_idx").HasMethod("gist");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tracktype).HasColumnName("tracktype");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(LineString,3857)")
                .HasColumnName("way");
            entity.Property(e => e.WayArea).HasColumnName("way_area");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<PlanetOsmNode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planet_osm_nodes_pkey");

            entity.ToTable("planet_osm_nodes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lon).HasColumnName("lon");
            entity.Property(e => e.Tags)
                .HasColumnType("jsonb")
                .HasColumnName("tags");
        });

        modelBuilder.Entity<PlanetOsmPoint>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("planet_osm_point");

            entity.HasIndex(e => e.OsmId, "planet_osm_point_osm_id_idx");

            entity.HasIndex(e => e.Way, "planet_osm_point_way_idx").HasMethod("gist");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("way");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<PlanetOsmPolygon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("planet_osm_polygon");

            entity.HasIndex(e => e.OsmId, "planet_osm_polygon_osm_id_idx");

            entity.HasIndex(e => e.Way, "planet_osm_polygon_way_idx").HasMethod("gist");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tracktype).HasColumnName("tracktype");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Geometry,3857)")
                .HasColumnName("way");
            entity.Property(e => e.WayArea).HasColumnName("way_area");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<PlanetOsmRel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planet_osm_rels_pkey");

            entity.ToTable("planet_osm_rels");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Members)
                .HasColumnType("jsonb")
                .HasColumnName("members");
            entity.Property(e => e.Tags)
                .HasColumnType("jsonb")
                .HasColumnName("tags");
        });

        modelBuilder.Entity<PlanetOsmRoad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("planet_osm_roads");

            entity.HasIndex(e => e.OsmId, "planet_osm_roads_osm_id_idx");

            entity.HasIndex(e => e.Way, "planet_osm_roads_way_idx").HasMethod("gist");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tracktype).HasColumnName("tracktype");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(LineString,3857)")
                .HasColumnName("way");
            entity.Property(e => e.WayArea).HasColumnName("way_area");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<PlanetOsmWay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("planet_osm_ways_pkey");

            entity.ToTable("planet_osm_ways");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nodes).HasColumnName("nodes");
            entity.Property(e => e.Tags)
                .HasColumnType("jsonb")
                .HasColumnName("tags");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Restaurant");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("way");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Shop");

            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.AddrHousename).HasColumnName("addr:housename");
            entity.Property(e => e.AddrHousenumber).HasColumnName("addr:housenumber");
            entity.Property(e => e.AddrInterpolation).HasColumnName("addr:interpolation");
            entity.Property(e => e.AdminLevel).HasColumnName("admin_level");
            entity.Property(e => e.Aerialway).HasColumnName("aerialway");
            entity.Property(e => e.Aeroway).HasColumnName("aeroway");
            entity.Property(e => e.Amenity).HasColumnName("amenity");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barrier).HasColumnName("barrier");
            entity.Property(e => e.Bicycle).HasColumnName("bicycle");
            entity.Property(e => e.Boundary).HasColumnName("boundary");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Bridge).HasColumnName("bridge");
            entity.Property(e => e.Building).HasColumnName("building");
            entity.Property(e => e.Capital).HasColumnName("capital");
            entity.Property(e => e.Construction).HasColumnName("construction");
            entity.Property(e => e.Covered).HasColumnName("covered");
            entity.Property(e => e.Culvert).HasColumnName("culvert");
            entity.Property(e => e.Cutting).HasColumnName("cutting");
            entity.Property(e => e.Denomination).HasColumnName("denomination");
            entity.Property(e => e.Disused).HasColumnName("disused");
            entity.Property(e => e.Ele).HasColumnName("ele");
            entity.Property(e => e.Embankment).HasColumnName("embankment");
            entity.Property(e => e.Foot).HasColumnName("foot");
            entity.Property(e => e.GeneratorSource).HasColumnName("generator:source");
            entity.Property(e => e.Harbour).HasColumnName("harbour");
            entity.Property(e => e.Highway).HasColumnName("highway");
            entity.Property(e => e.Historic).HasColumnName("historic");
            entity.Property(e => e.Horse).HasColumnName("horse");
            entity.Property(e => e.Intermittent).HasColumnName("intermittent");
            entity.Property(e => e.Junction).HasColumnName("junction");
            entity.Property(e => e.Landuse).HasColumnName("landuse");
            entity.Property(e => e.Layer).HasColumnName("layer");
            entity.Property(e => e.Leisure).HasColumnName("leisure");
            entity.Property(e => e.Lock).HasColumnName("lock");
            entity.Property(e => e.ManMade).HasColumnName("man_made");
            entity.Property(e => e.Military).HasColumnName("military");
            entity.Property(e => e.Motorcar).HasColumnName("motorcar");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Natural).HasColumnName("natural");
            entity.Property(e => e.Office).HasColumnName("office");
            entity.Property(e => e.Oneway).HasColumnName("oneway");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.OsmId).HasColumnName("osm_id");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Population).HasColumnName("population");
            entity.Property(e => e.Power).HasColumnName("power");
            entity.Property(e => e.PowerSource).HasColumnName("power_source");
            entity.Property(e => e.PublicTransport).HasColumnName("public_transport");
            entity.Property(e => e.Railway).HasColumnName("railway");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.Religion).HasColumnName("religion");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Shop1).HasColumnName("shop");
            entity.Property(e => e.Sport).HasColumnName("sport");
            entity.Property(e => e.Surface).HasColumnName("surface");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Toll).HasColumnName("toll");
            entity.Property(e => e.Tourism).HasColumnName("tourism");
            entity.Property(e => e.TowerType).HasColumnName("tower:type");
            entity.Property(e => e.Tunnel).HasColumnName("tunnel");
            entity.Property(e => e.Water).HasColumnName("water");
            entity.Property(e => e.Waterway).HasColumnName("waterway");
            entity.Property(e => e.Way)
                .HasColumnType("geometry(Point,3857)")
                .HasColumnName("way");
            entity.Property(e => e.Wetland).HasColumnName("wetland");
            entity.Property(e => e.Width).HasColumnName("width");
            entity.Property(e => e.Wood).HasColumnName("wood");
            entity.Property(e => e.ZOrder).HasColumnName("z_order");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
