const geoFormat = new format.GeoJSON({ dataProjection: 'EPSG:4326', featureProjection: 'EPSG:3857' });

function sendFeatureToController(feature, controller, name = 'exampleName') {
    const geometry = geoFormat.writeGeometryObject(feature.getGeometry());
    
    const dto = {
        Geometry: geometry,
        Id: null,
        Name: name
    }
    
    fetch(controller, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    }).then(response => {
        if (!response.ok) {
            throw new Error('Failed to add feature.');
        }
        // Only parse if there's content
        return response.text();
    })
        .then(text => {
            if (text) {
                try {
                    const json = JSON.parse(text);
                    console.log('Feature sent:', json);
                } catch (err) {
                    console.log('Response is not valid JSON:', text);
                }
            } else {
                console.log('Feature sent successfully (no JSON returned)');
            }
        })
        .catch(err => {
            console.error('Error sending feature:', err);
        });
}

const sourceVector = new source.Vector();

const vector = new layer.Vector({
    source: sourceVector
});

let draw;

map.addLayer(vector);

const typeSelect = document.getElementById('type');

function addInteraction() {
    const value = typeSelect.value;
    if (value != 'None') {
        draw = new interaction.Draw({
            source: sourceVector,
            type: value
        });
        map.addInteraction(draw);

        draw.on('drawend', function (event) {
            const selectedFeature = event.feature;
            const popup = document.getElementById("popupForm");
            popup.style.display = "block";
            popup.style.top = "100px";
            popup.style.left = "50px";
            drawnFeatures.push(selectedFeature);
            const geometryType = selectedFeature.getGeometry().getType();
            let endpoint = '';
            endpoint = detectUserController(geometryType) + 'Add';
            sendFeatureToController(selectedFeature, endpoint);
        });
    }
}

// Function to detect the controller based on the geometry type and operation.
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

typeSelect.onchange = function () {
    map.removeInteraction(draw);
    addInteraction();
}

let drawnFeatures = [];
addInteraction();

document.getElementById('undo').addEventListener('click', () => {
    const last = drawnFeatures.pop();
    if(last) {
        sourceVector.removeFeature(last);
    }
    if(draw) {
        draw.removeLastPoint();
    }
})

function submitFeature(controller) {
    const name = document.getElementById("featureName").value;
    const description = document.getElementById("featureDescription").value;
    const wkt = new format.WKT().writeFeature(selectedFeature);
    const type = selectedFeature.getGeometry().getType();
    let endpoint = detectUserController(type) + 'Edit/';
    fetch(controller, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, description, wkt })
    })
        .then(() => {
            alert('Feature sent successfully!');
            document.getElementById('popupForm').style.display = 'none';
        });
}

function cancelFeature() {
    sourceVector.removeFeature(drawnFeatures.pop());
    document.getElementById('popupForm').style.display = 'none';    
}

function loadAllEntities() {
    const endpoints = [
        { url: apiControllers.Point + 'GetAll', type: 'Point' },
        { url: apiControllers.Line + 'GetALl', type: 'LineString' },
        { url: apiControllers.Polygon + 'GetAll', type: 'Polygon' }
    ];

    endpoints.forEach(endpoint => {
        fetch(endpoint.url)
            .then(res => res.json())
            .then(data => {
                data.forEach(entity => {
                    let feature = new ol.format.WKT().readFeature(entity.wkt);
                    feature.setId(entity.id);
                    feature.setProperties({
                        name: entity.name,
                        description: entity.description,
                        entityType: endpoint.type
                    });
                    vectorSource.addFeature(feature);
                });
            });
    });
}

function updateFeature(feature) {
    const name = prompt("Edit name:", feature.get("name"));
    const description = prompt("Edit description:", feature.get("description"));
    const wkt = new format.WKT().writeFeature(feature);
    const id = feature.getId();
    const type = feature.get("entityType");

    let apiUrl = detectUserController(type) + 'Edit/' + id;

    fetch(apiUrl, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, description, wkt })
    });
}

function deleteFeature(feature) {
    const id = feature.getId();
    const type = feature.get("entityType");
    let apiUrl = detectUserController(type) + 'Delete/' + id;

    fetch(apiUrl, { method: 'DELETE' })
        .then(() => vectorSource.removeFeature(feature));
}
