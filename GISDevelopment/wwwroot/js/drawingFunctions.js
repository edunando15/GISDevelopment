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
            drawnFeatures.push(selectedFeature);
            const geometryType = selectedFeature.getGeometry().getType();
            let endpoint = '';
            if (geometryType === 'Point') endpoint = apiControllers.Point + 'Add';
            else if (geometryType === 'LineString') endpoint = apiControllers.Line + 'Add';
            else if (geometryType === 'Polygon') endpoint = apiControllers.Polygon + 'Add';
            sendFeatureToController(selectedFeature, endpoint);
        });
    }
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