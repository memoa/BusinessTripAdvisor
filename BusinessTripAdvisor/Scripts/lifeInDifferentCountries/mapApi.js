// *** Info card - carousel initialization ***

// *** Create map object ***

// Initialize the platform object:
var platform = new H.service.Platform({
    'app_id': 'CH8zl7pTYspa961FEXiT',
    'app_code': 'bKCZBDWX2qKO0OPduRJIYA'
});

// Obtain the default map types from the platform object
var maptypes = platform.createDefaultLayers();
var mapContainer = document.getElementById('mapContainer');


// Instantiate (and display) a map object:
var map = new H.Map(
    mapContainer,
    maptypes.normal.map,
    {
        zoom: 10,
        center: { lng: 13.4, lat: 52.51 }
    }
);

// Define a variable holding SVG mark-up that defines an icon image:
var svgMarkup = '<svg width="24" height="24" ' +
    'xmlns="http://www.w3.org/2000/svg">' +
    '<rect stroke="white" fill="#1b468d" x="1" y="1" width="22" ' +
    'height="22" /><text x="12" y="18" font-size="12pt" ' +
    'font-family="Arial" font-weight="bold" text-anchor="middle" ' +
    'fill="white">H</text></svg>';
// var svgMarkup = '<p>jdfhfjdsh</p>';
// Create an icon, an object holding the latitude and longitude, and a marker:
var icon = new H.map.Icon(svgMarkup),
    coords = { lat: 52.53075, lng: 13.3851 };
//marker = new H.map.Marker(coords, {icon: icon});

// Add the marker to the map and center the map at the location of the marker:
//map.addObject(marker);
map.setCenter(coords);
map.setZoom(12);

// Enable the event system on the map instance:
var mapEvents = new H.mapevents.MapEvents(map);

// Instantiate the default behavior, providing the mapEvents object:
var behavior = new H.mapevents.Behavior(mapEvents);

var places;
var chosenCity;

// Load all matching cities in a list, add function to find and zoom chosen city in a map
function loadPlacesList() {
    var input = $("#inputPlace").val();
    $("#placesList li.place").remove();
    if (input.length > 2) {
        $("#spinner").show();
        $.ajax({
            url: "http://autocomplete.geocoder.api.here.com/6.2/suggest.json",
            data: {
                app_id: "CH8zl7pTYspa961FEXiT",
                app_code: "bKCZBDWX2qKO0OPduRJIYA",
                query: input
            },
            method: "GET",
            success: function (responseData) {
                places = responseData.suggestions;
                for (var placeId in places) {
                    var place = places[placeId];
                    if (place.matchLevel == "city")
                        $("#placesList").append(`<li class="list-group-item list-group-item-action place" onclick="findOnMap('${place.locationId}')">${place.label}</li>`);
                }
                $("#spinner").hide();
            },
            error: function () {
                $("#spinner").hide();
                alert("Something went wrong.");
            }
        });
    }
}

// Find city and zoom it in map using locationId
function findOnMap(locationId) {
    $.ajax({
        url: "https://geocoder.api.here.com/6.2/geocode.json",
        data: {
            app_id: "CH8zl7pTYspa961FEXiT",
            app_code: "bKCZBDWX2qKO0OPduRJIYA",
            locationid: locationId
        },
        method: "GET",
        success: function (responseData) {
            var position = responseData.Response.View[0].Result[0].Location.DisplayPosition;
            coords = {
                lat: position.Latitude,
                lng: position.Longitude
            };
            //var marker = new H.map.Marker(coords, {icon: icon});
            //map.addObject(marker);
            map.setCenter(coords);
            map.setZoom(12);

            var cityName = places.filter(place => place.locationId == locationId)[0].address.city;
            //$("#test").text(cityName);
            $('#infoCardCityName').text(cityName);
            $("#inputPlace").val(cityName);
            $("#placesList li.place").remove();

            chosenCity = {
                name: cityName,
                description: '',
                latitude: position.Latitude,
                longitude: position.Longitude
            };
        },
        error: function () {
            alert("Something went wrong.");
        }
    });
}

// *** Add/remove new marker ***

// Add event listener:
map.addEventListener('tap', function (evt) {
    var geoCoords = toGeoCoords(map, evt.currentPointer.viewportX, evt.currentPointer.viewportY);

    // Log 'tap' and 'mouse' events:
    console.log({
        type: evt.type,
        currentPointer: evt.currentPointer.type,
        viewportX: evt.currentPointer.viewportX,
        viewportY: evt.currentPointer.viewportY,
        viewBounds: map.getViewBounds(),
        viewPort: map.getViewPort(),
        geoCoords: geoCoords
    });
    // Create marker with fa - icon on click/tap
    var domIcon = new H.map.DomIcon('<i class="fas fa-map-marker-alt fa-2x text-primary" style="top:-32px;left:-10px;"></i>');
    var marker = new H.map.DomMarker(geoCoords, { icon: domIcon });
    // Remove marker on longpress
    marker.addEventListener('longpress', function (evt) {
        map.removeObject(this);
    });
    map.addObject(marker);
});

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
