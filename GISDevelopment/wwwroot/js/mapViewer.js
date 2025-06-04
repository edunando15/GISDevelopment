async function loadPointsOfInterest(type) {
    try {
        let url = detectUserController(type) + 'GetAll';
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error('Failed to fetch points of interest');
        }
        const data = await response.json();
        const vectorSource = new source.Vector();

        data.forEach(point => {
            const latitude = point.geometry.coordinates.y;
            const longitude = point.geometry.coordinates.x;

            if (typeof latitude === 'number' && typeof longitude === 'number') {
                const feature = new ol.Feature({
                    geometry: new ol.geom.Point([longitude, latitude]),
                    name: point.name
                });
                feature.setStyle(new style.Style({
                    image: new style.Circle({
                        radius: 5,
                        fill: new style.Fill({ color: 'blue' }),
                        stroke: new style.Stroke({ color: 'white', width: 2 })
                    })
                }));

                vectorSource.addFeature(feature);
            } else {
                console.error('Invalid coordinates:', point.geometry.coordinates);
            }
        });

        if(window.poiLayer) {
            map.removeLayer(window.poiLayer);
        }
        window.poiLayer = new layer.Vector({
            source: vectorSource
        });

        map.addLayer(window.poiLayer);
    } catch (error) {
        console.error(error);
        alert('Error loading points of interest');
    }
}

function removePointsOfInterest() {
    const layers = map.getLayers().getArray();
    layers.forEach(layer => {
        if (layer instanceof ol.layer.Vector && layer) {
            layer.getSource().clear();
        }
    });

    const popupElement = document.getElementById('popup');
    const popupContent = document.getElementById('popup-content');
    
    if (popupContent) {
        popupContent.innerHTML = '';
    }
    
    if (popupElement) {
        popupElement.style.display = 'none';
    }

    if (window.popupOverlay) {
        popupOverlay.setPosition(undefined);
    }
    
    const sidebar = document.getElementById('sidebar');
    if (sidebar) {
        sidebar.innerHTML = '';
    }
}