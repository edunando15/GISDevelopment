const geoFormat = new format.GeoJSON({ dataProjection: 'EPSG:4326', featureProjection: 'EPSG:3857' });
let currentFeature = null;
window.clickedFeature = null;
function setupDrawing(map) {

    window.map.on('click', function (evt) {
        console.log('Single click event:', evt);
        const feature = map.forEachFeatureAtPixel(evt.pixel, f => f);
        const overlay = map.getOverlays().item(0); // Assuming the tooltip overlay is the first

        if (feature) {
            window.clickedFeature = feature;

            const name = feature.get('name') || '';
            const description = feature.get('description') || '';

            // Fill edit popup
            document.getElementById('editFeatureName').value = name;
            document.getElementById('editFeatureDescription').value = description;

            // Position and show the edit popup
            const popup = document.getElementById('editPopupForm');
            popup.style.left = evt.pixel[0] + 'px';
            popup.style.top = evt.pixel[1] + 'px';
            popup.style.display = 'block';

            // Show the tooltip overlay
            const el = overlay.getElement();
            el.innerHTML = `<div class="bg-white p-2 border rounded shadow">${name}</div>`;
            overlay.setElement(el);
            overlay.setPosition(evt.coordinate);
        } else {
            // Hide everything if no feature is clicked
            document.getElementById('editPopupForm').style.display = 'none';
            overlay.setPosition(undefined);
        }
    });


    const sourceVector = new source.Vector();
    const vector = new layer.Vector({ source: sourceVector });
    map.addLayer(vector);

    let draw;
    let selectedFeature;
    let drawnFeatures = [];

    const typeSelect = document.getElementById('type');

    function addInteraction() {
        const value = typeSelect.value;
        if (value !== 'None') {
            draw = new interaction.Draw({
                source: sourceVector,
                type: value
            });
            map.addInteraction(draw);
            draw.on('drawend', function (event) {
                selectedFeature = event.feature;
                currentFeature = selectedFeature;
                const popup = document.getElementById("popupForm");
                popup.style.display = "block";
                popup.style.top = "120px";
                popup.style.left = "calc(50% - 150px)";
                drawnFeatures.push(selectedFeature);
            });
        }
    }

    typeSelect.onchange = function () {
        map.removeInteraction(draw);
        addInteraction();
    }

    document.getElementById('undo').addEventListener('click', () => {
        const last = drawnFeatures.pop();
        if (last) sourceVector.removeFeature(last);
        if (draw) draw.removeLastPoint();
    });

    addInteraction();
    
    // Modify interaction.
    const modify = new interaction.Modify({ source: sourceVector });
    map.addInteraction(modify);

    // Popup overlay for feature info.
    const overlay = new ol.Overlay({
        element: document.createElement('div'),
        positioning: 'bottom-center',
        stopEvent: false,
        offset: [0, -15],
    });
    map.addOverlay(overlay);
    // Right-click to delete feature.
    map.getViewport().addEventListener('contextmenu', function (evt) {
        evt.preventDefault();
        const pixel = map.getEventPixel(evt);
        const feature = map.forEachFeatureAtPixel(pixel, f => f);
        if (feature) {
            let endpoint = detectUserController(feature.getGeometry().getType()) + 'Delete/';
            const confirmDelete = confirm('Delete this feature?');
            if (confirmDelete) {
                sourceVector.removeFeature(feature);
                deleteFeatureFromController(feature, detectUserController(feature.getGeometry().getType()));
            }
        }
    });
}

function sendFeatureToController(feature, controller, name = 'exampleName') {
    const geometry = geoFormat.writeGeometryObject(feature.getGeometry());

    const dto = {
        Geometry: geometry,
        Id: feature.getId() || null,
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

function submitFeature() {
    if(!currentFeature) {
        alert('No feature selected!');
        return;
    }
    const wkt = new format.WKT().writeFeature(currentFeature);
    const type = currentFeature.getGeometry().getType();
    const nameValue = document.getElementById("featureName").value
    currentFeature.set('name', nameValue);
    let endpoint = detectUserController(type) + 'Add/';
    sendFeatureToController(currentFeature, endpoint, nameValue);
    document.getElementById('popupForm').style.display = 'none';
    document.getElementById('featureName').value = '';
    currentFeature = null;
}

function cancelFeature() {
    sourceVector.removeFeature(drawnFeatures.pop());
    document.getElementById('popupForm').style.display = 'none';
}