function initialiseMap(center) {
    map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat(center),
            zoom: 7
        })
    });
}

// Function used to load a polygon, given the API controller to call and the id of the polygon.
async function loadPolygon(controller, id) {
    const response = await fetch(controller + id);
    if(!response.ok) {
        console.error("Failed to load polygon with id " + id + ".");
        return;
    }
    const wkt = await response.text();
    console.log(wkt);
    var format = new ol.format.WKT();
    var feature = format.readFeature(wkt, {
        dataProjection: 'EPSG:4326',
        featureProjection: 'EPSG:3857'
    });
    var vectorLayer = new ol.layer.Vector({
        source: new ol.source.Vector({
            features: [feature]
        }),
        style: new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'blue',
                width: 2
            }),
            fill: new ol.style.Fill({
                color: 'rgba(0, 0, 255, 0.3)'
            })
        })
    });
    map.addLayer(vectorLayer);
}

// Function used to load a point, given the API controller to call and the id of the point.
async function loadPoint(controller, id){
    response = await fetch(controller + id);
    if(!response.ok) {
        console.error("Failed to load point with id " + id + ".");
        return;
    }
    wkt = await response.text();
    console.log(wkt);
    var format = new ol.format.WKT();
    var feature = format.readFeature(wkt, {
        dataProjection: 'EPSG:3857',
        featureProjection: 'EPSG:3857'
    });
    var vectorSource = new ol.source.Vector({
        features: [feature]
    });
    var vectorLayer = new ol.layer.Vector({
        source: vectorSource,
        style: new ol.style.Style({
            image: new ol.style.Circle({
                radius: 2,
                fill: new ol.style.Fill({
                    color: 'rgba(0, 0, 255, 0.3)'
                }),
                fill: new ol.style.Fill({
                    color: 'blue'
                }),
                stroke: new ol.style.Stroke({
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
    map.getView().fit(geometry, {padding: [50, 50, 50, 50], maxZoom: 8});
}