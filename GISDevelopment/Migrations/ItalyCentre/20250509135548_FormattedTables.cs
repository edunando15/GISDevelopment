using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GISDevelopment.Migrations.ItalyCentre
{
    /// <inheritdoc />
    public partial class FormattedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "ancona_roads",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    cost = table.Column<double>(type: "double precision", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    int_ref = table.Column<string>(type: "text", nullable: true),
                    nat_ref = table.Column<string>(type: "text", nullable: true),
                    loc_name = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Geometry>(type: "geometry", nullable: true),
                    source = table.Column<long>(type: "bigint", nullable: true),
                    target = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ancona_roads_vertices_pgr",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cnt = table.Column<int>(type: "integer", nullable: true),
                    chk = table.Column<int>(type: "integer", nullable: true),
                    ein = table.Column<int>(type: "integer", nullable: true),
                    eout = table.Column<int>(type: "integer", nullable: true),
                    the_geom = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ancona_roads_vertices_pgr_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Monument",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    ele = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "osm2pgsql_properties",
                columns: table => new
                {
                    property = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("osm2pgsql_properties_pkey", x => x.property);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfWorship",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    ele = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_line",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tracktype = table.Column<string>(type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    way_area = table.Column<float>(type: "real", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<LineString>(type: "geometry(LineString,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_nodes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    lat = table.Column<int>(type: "integer", nullable: false),
                    lon = table.Column<int>(type: "integer", nullable: false),
                    tags = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_osm_nodes_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_point",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    ele = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_polygon",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tracktype = table.Column<string>(type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    way_area = table.Column<float>(type: "real", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Geometry>(type: "geometry(Geometry,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_rels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    members = table.Column<string>(type: "jsonb", nullable: false),
                    tags = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_osm_rels_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_roads",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tracktype = table.Column<string>(type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    way_area = table.Column<float>(type: "real", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<LineString>(type: "geometry(LineString,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "planet_osm_ways",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    nodes = table.Column<List<long>>(type: "bigint[]", nullable: false),
                    tags = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("planet_osm_ways_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    ele = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    osm_id = table.Column<long>(type: "bigint", nullable: true),
                    access = table.Column<string>(type: "text", nullable: true),
                    addrhousename = table.Column<string>(name: "addr:housename", type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(name: "addr:housenumber", type: "text", nullable: true),
                    addrinterpolation = table.Column<string>(name: "addr:interpolation", type: "text", nullable: true),
                    admin_level = table.Column<string>(type: "text", nullable: true),
                    aerialway = table.Column<string>(type: "text", nullable: true),
                    aeroway = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    area = table.Column<string>(type: "text", nullable: true),
                    barrier = table.Column<string>(type: "text", nullable: true),
                    bicycle = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    bridge = table.Column<string>(type: "text", nullable: true),
                    boundary = table.Column<string>(type: "text", nullable: true),
                    building = table.Column<string>(type: "text", nullable: true),
                    capital = table.Column<string>(type: "text", nullable: true),
                    construction = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    culvert = table.Column<string>(type: "text", nullable: true),
                    cutting = table.Column<string>(type: "text", nullable: true),
                    denomination = table.Column<string>(type: "text", nullable: true),
                    disused = table.Column<string>(type: "text", nullable: true),
                    ele = table.Column<string>(type: "text", nullable: true),
                    embankment = table.Column<string>(type: "text", nullable: true),
                    foot = table.Column<string>(type: "text", nullable: true),
                    generatorsource = table.Column<string>(name: "generator:source", type: "text", nullable: true),
                    harbour = table.Column<string>(type: "text", nullable: true),
                    highway = table.Column<string>(type: "text", nullable: true),
                    historic = table.Column<string>(type: "text", nullable: true),
                    horse = table.Column<string>(type: "text", nullable: true),
                    intermittent = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    landuse = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    @lock = table.Column<string>(name: "lock", type: "text", nullable: true),
                    man_made = table.Column<string>(type: "text", nullable: true),
                    military = table.Column<string>(type: "text", nullable: true),
                    motorcar = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    natural = table.Column<string>(type: "text", nullable: true),
                    office = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: true),
                    place = table.Column<string>(type: "text", nullable: true),
                    population = table.Column<string>(type: "text", nullable: true),
                    power = table.Column<string>(type: "text", nullable: true),
                    power_source = table.Column<string>(type: "text", nullable: true),
                    public_transport = table.Column<string>(type: "text", nullable: true),
                    railway = table.Column<string>(type: "text", nullable: true),
                    @ref = table.Column<string>(name: "ref", type: "text", nullable: true),
                    religion = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    service = table.Column<string>(type: "text", nullable: true),
                    shop = table.Column<string>(type: "text", nullable: true),
                    sport = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    toll = table.Column<string>(type: "text", nullable: true),
                    tourism = table.Column<string>(type: "text", nullable: true),
                    towertype = table.Column<string>(name: "tower:type", type: "text", nullable: true),
                    tunnel = table.Column<string>(type: "text", nullable: true),
                    water = table.Column<string>(type: "text", nullable: true),
                    waterway = table.Column<string>(type: "text", nullable: true),
                    wetland = table.Column<string>(type: "text", nullable: true),
                    width = table.Column<string>(type: "text", nullable: true),
                    wood = table.Column<string>(type: "text", nullable: true),
                    z_order = table.Column<int>(type: "integer", nullable: true),
                    tags = table.Column<Dictionary<string, string>>(type: "hstore", nullable: true),
                    way = table.Column<Point>(type: "geometry(Point,3857)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "ancona_roads_osm_id_idx",
                table: "ancona_roads",
                column: "osm_id");

            migrationBuilder.CreateIndex(
                name: "ancona_roads_source_idx",
                table: "ancona_roads",
                column: "source");

            migrationBuilder.CreateIndex(
                name: "ancona_roads_target_idx",
                table: "ancona_roads",
                column: "target");

            migrationBuilder.CreateIndex(
                name: "ancona_roads_way_idx",
                table: "ancona_roads",
                column: "way")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "ancona_roads_vertices_pgr_the_geom_idx",
                table: "ancona_roads_vertices_pgr",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "planet_osm_line_osm_id_idx",
                table: "planet_osm_line",
                column: "osm_id");

            migrationBuilder.CreateIndex(
                name: "planet_osm_line_way_idx",
                table: "planet_osm_line",
                column: "way")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "planet_osm_point_osm_id_idx",
                table: "planet_osm_point",
                column: "osm_id");

            migrationBuilder.CreateIndex(
                name: "planet_osm_point_way_idx",
                table: "planet_osm_point",
                column: "way")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "planet_osm_polygon_osm_id_idx",
                table: "planet_osm_polygon",
                column: "osm_id");

            migrationBuilder.CreateIndex(
                name: "planet_osm_polygon_way_idx",
                table: "planet_osm_polygon",
                column: "way")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "planet_osm_roads_osm_id_idx",
                table: "planet_osm_roads",
                column: "osm_id");

            migrationBuilder.CreateIndex(
                name: "planet_osm_roads_way_idx",
                table: "planet_osm_roads",
                column: "way")
                .Annotation("Npgsql:IndexMethod", "gist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ancona_roads");

            migrationBuilder.DropTable(
                name: "ancona_roads_vertices_pgr");

            migrationBuilder.DropTable(
                name: "Monument");

            migrationBuilder.DropTable(
                name: "osm2pgsql_properties");

            migrationBuilder.DropTable(
                name: "PlaceOfWorship");

            migrationBuilder.DropTable(
                name: "planet_osm_line");

            migrationBuilder.DropTable(
                name: "planet_osm_nodes");

            migrationBuilder.DropTable(
                name: "planet_osm_point");

            migrationBuilder.DropTable(
                name: "planet_osm_polygon");

            migrationBuilder.DropTable(
                name: "planet_osm_rels");

            migrationBuilder.DropTable(
                name: "planet_osm_roads");

            migrationBuilder.DropTable(
                name: "planet_osm_ways");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Shop");
        }
    }
}
