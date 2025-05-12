function initMap(center) {
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

// Function used to load the polygon of a municipality.
async function loadPolygon(element, id) {
    const response = await fetch(element + id);
    if(!response.ok) {
        console.error("Failed to load polygon with id " + id + ".");
        return;
    }
    const wkt = await response.text();
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