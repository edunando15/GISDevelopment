const { Map, View, proj, format, layer, source, style, interaction } = ol;

// Function used to initialise the map with a given center point.
function initialiseMap(center) {
    return new Map({
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
    const data = await response.json();
    const wktFormat = new format.WKT();
    const feature = wktFormat.readFeature(data.geometry, {
        dataProjection: 'EPSG:3857',
        featureProjection: 'EPSG:3857'
    });
    feature.set('name', data.name);
    
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
    map.getView().fit(geometry, {padding: [50, 50, 50, 50], maxZoom: 8});
}
function detectUserController(type) {
    let api = '';
    switch (type) {
        case 'Point':
            api = apiControllers.Point;
            break;
        case 'LineString':
            api = apiControllers.Line;
            break;
        case 'Polygon':
            api = apiControllers.Polygon;
            break;
        case 'Restaurant':
            api = apiControllers.Restaurant;
            break;
        case 'Monument':
            api = apiControllers.Monument;
            break;
        case 'PlaceOfWorship':
            api = apiControllers.PlaceOfWorship;
            break;
        case 'Shop':
            api = apiControllers.Shop;
            break;
        default:
            throw new Error('Unsupported geometry type: ' + type);
    }
    return api;
}