const { Map, View, proj, format, layer, source, style, interaction } = ol;

function initialiseMap(center) {
    map = new Map({
        target: 'map',
        layers: [
            new layer.Tile({
                source: new source.OSM()
            })
        ],
        view: new View({
            center: proj.fromLonLat(center),
            zoom: 7
        })
    });
}

// Function used to load a polygon, given the API controller to call and the id of the polygon.
async function loadPolygon(controller, id) {
    const response = await fetch(controller + id);
    if (!response.ok) {
        console.error("Failed to load polygon with id " + id + ".");
        return;
    }
    const wkt = await response.text();
    console.log(wkt);
    const wktFormat = new format.WKT();
    const feature = wktFormat.readFeature(wkt, {
        dataProjection: 'EPSG:4326',
        featureProjection: 'EPSG:3857'
    });
    const vectorLayer = new layer.Vector({
        source: new source.Vector({
            features: [feature]
        }),
        style: new style.Style({
            stroke: new style.Stroke({
                color: 'blue',
                width: 2
            }),
            fill: new style.Fill({
                color: 'rgba(0, 0, 255, 0.3)'
            })
        })
    });
    map.addLayer(vectorLayer);
}

// Function used to load a point, given the API controller to call and the id of the point.
async function loadPoint(controller, id) {
    const response = await fetch(controller + id);
    if (!response.ok) {
        console.error("Failed to load point with id " + id + ".");
        return;
    }
    const wkt = await response.text();
    console.log(wkt);
    const wktFormat = new format.WKT();
    const feature = wktFormat.readFeature(wkt, {
        dataProjection: 'EPSG:3857',
        featureProjection: 'EPSG:3857'
    });
    const vectorSource = new source.Vector({
        features: [feature]
    });
    const vectorLayer = new layer.Vector({
        source: vectorSource,
        style: new style.Style({
            image: new style.Circle({
                radius: 2,
                fill: new style.Fill({
                    color: 'blue'
                }),
                stroke: new style.Stroke({
                    color: 'blue',
                    width: 2
                })
            })
        })
    });
    map.addLayer(vectorLayer);
    // Zoom to the point.
    const geometry = feature.getGeometry();
    console.log('Geometry: ', geometry);
    map.getView().fit(geometry, { padding: [50, 50, 50, 50], maxZoom: 8 });
}