(function ($) {

    // ------------------------------------------------------- //
    // Leaflet
    // ------------------------------------------------------ //
    var cities = L.layerGroup();

    var mbAttr = '&copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors',
        mbUrl = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw';

    var grayscale = L.tileLayer(mbUrl, { id: 'mapbox.light', attribution: mbAttr }),
        streets = L.tileLayer(mbUrl, { id: 'mapbox.streets', attribution: mbAttr });

    var map = L.map('layer-control', {
        center: [39.75, -104.90],
        zoom: 11,
        layers: [grayscale, cities]
    });

    var baseLayers = {
        "Grayscale": grayscale,
        "Streets": streets
    };

    var overlays = {
        "Customers": cities
    };

    var firstIcon = L.icon({
        iconUrl: '/Content/img/avatar/c1.png',
        iconSize: [80, 80], // size of the icon
    });

    var secondIcon = L.icon({
        iconUrl: '/Content/img/avatar/c2.png',
        iconSize: [80, 80], // size of the icon
    });

    var thirdIcon = L.icon({
        iconUrl: '/Content/img/avatar/c3.png',
        iconSize: [80, 80], // size of the icon
    });

    var firstPopup = "La Capitale";
    var secondPopup = "Desjardins";
    var thirdPopup = "IA";

    var marker = L.marker([39.76, -104.90], { icon: firstIcon }).bindPopup(firstPopup).addTo(cities);
    L.marker([39.68, -104.99], { icon: secondIcon }).bindPopup(secondPopup).addTo(cities);
    L.marker([39.73, -104.8], { icon: thirdIcon }).bindPopup(thirdPopup).addTo(cities);
    var popup = marker.getPopup();
    L.control.layers(baseLayers, overlays).addTo(map);
 
    map.on('popupopen',
        function(e) {
            console.log(marker.isPopupOpen()); // false
            console.log(popup.isOpen()); // false
            $("#myDiagramDiv").show();
            $("#popupbutton").show();
             $('#mypopup').popup('show');
            init();
        });
    map.on('popupclose',
        function (e) {
            $("#myDiagramDiv").hide();
        });
})(jQuery);