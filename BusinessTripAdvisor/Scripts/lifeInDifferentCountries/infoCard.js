// ************************************
// *** Info Card view functionality ***
// ************************************

function details(id) {
    // View/edit existing city
    if (id !== undefined) {
        chosenCity = citiesInDb.filter(c => c.id == id)[0];
        if (chosenCity !== null) {
            $("#ponuda").hide();

            $('#chooseCity').hide();
            $('#deleteBtn').show();
            $('#feedBtn').show();
            // Fill Info Card
            $("#infoCardCityName").text(chosenCity.name);
            $("#subject").val(chosenCity.description);
            // Focus in the map
            coords = {
                lat: chosenCity.latitude,
                lng: chosenCity.longitude
            };
            map.setCenter(coords);
            map.setZoom(12);

            $("#details").show();
        }
        else {
            alert('There is no such city in database.');
        }
    }
    // Add new city
    else {
        chosenCity = {
            name: 'Choose city',
            description: '',
            latitude: 0,
            longitude: 0
        }

        $("#ponuda").hide();

        $('#deleteBtn').hide();
        $('#feedBtn').hide();

        $('#inputPlace').val('');
        $('#chooseCity').show();

        // Clear Info Card
        $("#infoCardCityName").text(chosenCity.name);
        $("#subject").val(chosenCity.description);
        // Focus on the map
        coords = {
            lat: chosenCity.latitude,
            lng: chosenCity.longitude
        };
        map.setCenter(coords);
        map.setZoom(12);

        $("#details").show();
    }
}

function onSave() {
    if (chosenCity !== undefined) {
        chosenCity.description = $('#subject').val();
        console.log(chosenCity);
        // Validations
        if (chosenCity.name === 'Choose city')
            alert('Choose the city first.');
        else if (chosenCity.id === undefined && citiesInDb.some(city => city.name == chosenCity.name))
            alert('This city already exists in database.');
        else if (chosenCity.description === '')
            alert('Add some information about city.');
        // Write data in database
        else {
            $.ajax({
                url: "/api/cities" + (chosenCity.id === undefined ? "" : '/' + chosenCity.id),
                method: chosenCity.id === undefined ? "POST" : "PUT",
                data: chosenCity,
                success: function (responseData, textStatus, jqXHR) {
                    alert('City saved.');
                    onCancel();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Something wrong happend.");
                }
            });
        }
    }
    else {
        alert('Choose the city first.');
    }
}

function onCancel() {
    $("#details").hide();
    loadCities();
    $("#ponuda").show();
}

function onDelete() {
    var confirmDelete = confirm('Are you sure you want to delete this city?');
    if (confirmDelete) {
        $.ajax({
            url: "/api/cities/" + chosenCity.id,
            method: "DELETE",
            success: function (responseData, textStatus, jqXHR) {
                alert('City deleted.');
                onCancel();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Something wrong happend.");
            }
        });
    }
}
