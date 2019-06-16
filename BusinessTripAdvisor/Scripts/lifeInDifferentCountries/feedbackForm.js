var feedbackMapContainer = document.getElementById('feedbackMapContainer');

// Map objects as global variables
var feedbackMap;
var feedbackMapEvents;
var feedbackMapBehavior;
var feedbackMapUi;

// Create marker icon with fa - icon on click/tap
var feedbackDomIcon = new H.map.DomIcon('<i class="fas fa-map-marker-alt fa-2x text-primary" style="top:-32px;left:-10px;"></i>');
var feedbackMarker;

// Converts viewport coordinates to geo coordinates
function toGeoCoords(map, vX, vY) {
    var viewBounds = map.getViewBounds();
    var viewPort = map.getViewPort();
    var geoHeight = Math.abs(viewBounds.ja - viewBounds.ka);
    var geoWidth = Math.abs(viewBounds.ga - viewBounds.ha);
    var ratioW = geoWidth / viewPort.width;
    var ratioH = geoHeight / viewPort.height;
    return {
        lng: Math.min(viewBounds.ga, viewBounds.ha) + vX * ratioW,
        lat: Math.max(viewBounds.ja, viewBounds.ka) - vY * ratioH
    }
}

$('#feedbackModal').on('shown.bs.modal', function (e) {
    // Create map inside a form
    feedbackMap = new H.Map(
        feedbackMapContainer,
        defaultLayers.normal.map, { pixelRatio: pixelRatio }
    );

    // Enable the event system on the map instance:
    feedbackMapEvents = new H.mapevents.MapEvents(feedbackMap);

    // Instantiate the default behavior, providing the mapEvents object:
    feedbackMapBehavior = new H.mapevents.Behavior(feedbackMapEvents);

    // Create the default UI components
    feedbackMapUi = H.ui.UI.createDefault(feedbackMap, defaultLayers);

    // Focus on city on map
    feedbackMap.setCenter({
        lat: chosenCity.latitude,
        lng: chosenCity.longitude
    });
    feedbackMap.setZoom(12);

    // *** Add/remove new marker ***

    // Add event listener:
    feedbackMap.addEventListener('tap', function (evt) {
        var geoCoords = toGeoCoords(feedbackMap, evt.currentPointer.viewportX, evt.currentPointer.viewportY);

        // Log 'tap' and 'mouse' events:
        console.log(feedbackMarker);

        // Remove previous marker
        if (feedbackMarker !== undefined)
            feedbackMap.removeObject(feedbackMarker);
        // Add new marker
        feedbackMarker = new H.map.DomMarker(geoCoords, { icon: feedbackDomIcon });

        feedbackMap.addObject(feedbackMarker);

        // Fill form with coordinates from map
        $('#feedbackForm #latitude').val(geoCoords.lat);
        $('#feedbackForm #longitude').val(geoCoords.lng);
    });
});

$('#feedbackModal').on('hidden.bs.modal', function (e) {
    // Clear form
    $('#feedbackForm #title').val('');
    $('#feedbackForm #comment').val('');
    $('#feedbackForm #rating').val('');
    $('#feedbackForm #latitude').val('');
    $('#feedbackForm #longitude').val('');

    // Remove previous marker
    if (feedbackMarker !== undefined)
        feedbackMap.removeObject(feedbackMarker);
    $('#feedbackMapContainer').empty();
    feedbackMarker = undefined;
    feedbackMapUi = undefined;
    feedbackMapBehavior = undefined;
    feedbackMapEvents = undefined;
    feedbackMap = undefined;
});

function onFeedback() {
    $('#feedbackModal').modal('show');
}
