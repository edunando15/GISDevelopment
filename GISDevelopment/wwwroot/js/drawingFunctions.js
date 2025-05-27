// Retrieve the source from the existing vector layer
const sourceVector = new source.Vector();

const vector = new layer.Vector({
    source: sourceVector
});

map.addLayer(vector);

const typeSelect = document.getElementById('type');
let draw;
function addInteraction() {
    const value = typeSelect.value;
    if (value != 'None') {
        draw = new interaction.Draw({
            source: sourceVector,
            type: value
        });
        map.addInteraction(draw);
    }
}

typeSelect.onchange = function () {
    map.removeInteraction(draw);
    addInteraction();
}

document.getElementById('undo').addEventListener('click', () => {
    draw.removeLastPoint();
})

addInteraction();