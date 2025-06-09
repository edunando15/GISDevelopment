let selectedFeature;
let drawnFeatures = [];

function setupDrawing(map) {
    const sourceVector = new ol.source.Vector();

    const vector = new ol.layer.Vector({
        source: sourceVector
    });

    map.addLayer(vector);

    const typeSelect = document.getElementById('type');
    let draw;

    function addInteraction() {
        const value = typeSelect.value;
        if (value !== 'None') {
            draw = new ol.interaction.Draw({
                source: sourceVector,
                type: value
            });

            map.addInteraction(draw);

            draw.on('drawend', function (event) {
                selectedFeature = event.feature;
                document.getElementById("popupForm").style.display = "block";
                drawnFeatures.push(selectedFeature);
                const geometryType = selectedFeature.getGeometry().getType();
                let endpoint = detectUserController(geometryType) + 'Add';
                sendFeatureToController(selectedFeature, endpoint);
            });
        }
    }

    typeSelect.onchange = function () {
        map.removeInteraction(draw);
        addInteraction();
    };

    addInteraction();

    document.getElementById('undo').addEventListener('click', () => {
        const last = drawnFeatures.pop();
        if (last) {
            sourceVector.removeFeature(last);
        }
        if (draw) {
            draw.removeLastPoint();
        }
    });
}

// Export to global scope
window.setupDrawing = setupDrawing;
