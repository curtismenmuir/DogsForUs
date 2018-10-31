$(document).ready(function () {
    getData();
});

// function to call HTTP POST to Web Service with new dog information
function addDog() {
    var name = document.getElementById('dogBreedInput').value;
    var description = document.getElementById('dogDescriptionInput').value;
    var subBreeds = document.getElementById('addDogSubBreedDisplay').value;
    if (name) {
        if (!description) {
            description = 'No Description.'; // description can be blank - replace with "No Description."
        }
        var uri = 'api/dogs/';
        var newDog = 'name=' + name + '&description=' + description;
        if (subBreeds) {
            var temp = subBreeds.replace(/\s+/g, ''); // remoove any spaces
            temp = temp.split(',');
            for (var i = 0; i < temp.length; i++) {
                newDog = newDog + '&subbreeds' + '[' + i + ']=' + temp[i];
            }
            newDog.slice(0, -1);
        }   
        $.ajax({
            type: 'POST',
            url: uri,
            contentType: 'application/x-www-form-urlencoded',
            data: newDog,
            success: function (result) {
                $('#addDogModal').modal('hide');
                alert("Dog added successfully!");
                clearData();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Unable to add dog, please check if it already exist!");
            }
        });
    }
    else {
        alert("Please enter the breed of dog to be added!");
    }
}

// function to show and populate edit dog modal popup with dog details
function confirmEdit(btn_id) {
    var details = (btn_id.substr(3)).split('_');
    document.getElementById('editDogBreedInput').value = details[0];
    document.getElementById('editDogDescriptionInput').value = details[1];
    document.getElementById('editDogOriginalName').value = details[0];
    if (details.length > 2){
        details[2] = details[2].replace(/,/g, ', '); // regex to add space after comma
        document.getElementById('editDogSubBreedDisplay').value = details[2];
    }
    $('#editDogModal').modal('show');
}

// function to call HTTP PUT to Web Service with edited dogs details
function editDog() {
    var originalName = document.getElementById('editDogOriginalName').value;
    var name = document.getElementById('editDogBreedInput').value;
    var description = document.getElementById('editDogDescriptionInput').value;
    if (!description) {
        description = 'No Description'; // description can be blank
    }
    var uri = 'api/dogs/' + originalName;
    var newDog = 'name=' + name + '&description=' + description;
    var subBreeds = document.getElementById('editDogSubBreedDisplay').value;
    if (subBreeds) {
        var temp = subBreeds.replace(/\s+/g, ''); // remoove any spaces
        temp = temp.split(',');
        for (var i = 0; i < temp.length; i++) {
            newDog = newDog + '&subbreeds' + '[' + i + ']=' + temp[i];
        }
        newDog.slice(0, -1);
    }   
    $.ajax({
        type: 'PUT',
        url: uri,
        contentType: 'application/x-www-form-urlencoded',
        data: newDog,
        success: function (result) {
            $('#editDogModal').modal('hide');
            alert("Dog edited successfully!");
            clearData();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Unable to edit dog, please check if another dog already exist with the same name!");
        }
    });
}

// Function to display the delete dog modal popup
function confirmDelete(btn_id) {
    document.getElementById('deleteDogOriginalName').value = btn_id.substr(3);
    $('#deleteDogModal').modal('show');
}

// Function to call HTTP DELETE to Web Service with dog name to be removed
function deleteDog() {
    var originalName = document.getElementById('deleteDogOriginalName').value;
    var uri = 'api/dogs/' + originalName;
    $.ajax({
        type: 'DELETE',
        url: uri,
        success: function (result) {
            $('#deleteDogModal').modal('hide');
            alert("Dog deleted successfully!");
            clearData();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Unable to delete dog!");
        }
    });
}

// Function to clear accordion and input fields - calls getData() to refresh dog list
function clearData() {
    $('#accordion').empty();
    document.getElementById('dogBreedInput').value = '';
    document.getElementById('dogDescriptionInput').value = '';
    document.getElementById('editDogBreedInput').value = '';
    document.getElementById('editDogDescriptionInput').value = '';
    document.getElementById('editDogOriginalName').value = '';
    document.getElementById('deleteDogOriginalName').value = '';
    document.getElementById('addDogSubBreedInput').value = '';
    document.getElementById('addDogSubBreedDisplay').value = '';
    document.getElementById('editDogSubBreedInput').value = '';
    document.getElementById('editDogSubBreedDisplay').value = '';
    getData();
}

// Function calls HTTP GET to web service to get the dog collection - will append dogs to the accordion
function getData() {
    var uri = 'api/dogs/'
    var count = 1;
    $.getJSON(uri)
        .done(function(data) {
            $('#accordion').empty();
            $.each(data, function (key, value) {
                if (value.subBreeds !== null) {
                    $('#accordion').append(
                        '<div class="card">' +
                        '<div class="card-header" id="' + value.name + '">' +
                        '<h5 class="mb-0">' +
                        '<button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapse' + value.name + '"' +
                        ' aria-expanded="false" aria-controls="collapse' + value.name + '">' +
                        value.name +
                        '</button>' +
                        '</h5>' +
                        '</div>' +
                        '<div id="collapse' + value.name + '" class="collapse" aria-labelledby="heading' + value.name + '" data-parent="#accordion">' +
                        '<div class="card-body">' +
                        '<h5>Description</h5>' +
                        value.description +
                        '<br>' +
                        '<h5 style="margin-top: 1%;">Sub-Breeds</h5>' +
                        '<p id="subBreed' + value.name + '"></p>' +
                        '<button type="button" id="btn' + value.name + '_' + value.description + '_' + value.subBreeds +'" class="btn btn-primary" onclick="confirmEdit(this.id);" style="margin-right: 0.1%;">Edit</button>' +
                        '<button type="button" id="btn' + value.name + '" class="btn btn-primary" onclick="confirmDelete(this.id);">Delete</button>' +
                        '</div>' +
                        '</div>' +
                        '</div>'
                    );
                    for (var i = 0; i < value.subBreeds.length; i++) {
                        if (i === 0) {
                            $('#subBreed' + value.name).append(value.subBreeds[i]);
                        }
                        else {
                            $('#subBreed' + value.name).append(', ' + value.subBreeds[i]);
                        }
                    }
                }
                else {
                    $('#accordion').append(
                        '<div class="card">' +
                        '<div class="card-header" id="' + value.name + '">' +
                        '<h5 class="mb-0">' +
                        '<button class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapse' + value.name + '"' +
                        ' aria-expanded="false" aria-controls="collapse' + value.name + '">' +
                        value.name +
                        '</button>' +
                        '</h5>' +
                        '</div>' +
                        '<div id="collapse' + value.name + '" class="collapse" aria-labelledby="heading' + value.name + '" data-parent="#accordion">' +
                        '<div class="card-body">' +
                        '<h5>Description</h5>' +
                        value.description +
                        '<br>' +
                        '<button type="button" id="btn' + value.name + '_' + value.description + '" class="btn btn-primary" onclick="confirmEdit(this.id);" style="margin-right: 0.1%;">Edit</button>' +
                        '<button type="button" id="btn' + value.name + '" class="btn btn-primary" onclick="confirmDelete(this.id);">Delete</button>' +
                        '</div>' +
                        '</div>' +
                        '</div>'
                    );
                }
                count = count + 1;
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("We are unable to process your request right now!");
        });
}

// Function to allow user to enter a sub breed to a dog in the add dog modal popup
function addSubBreed() {
    var inputbox = document.getElementById('addDogSubBreedInput');
    if (inputbox.value !== '') {
        if ((document.getElementById('addDogSubBreedDisplay').value) !== '') {
            document.getElementById('addDogSubBreedDisplay').value += ', ' + inputbox.value;
        }
        else {
            document.getElementById('addDogSubBreedDisplay').value += inputbox.value;
        }
        document.getElementById('addDogSubBreedInput').value = '';
    }
    else {
        alert("Please enter a Sub-Breed!");
    }
}

// Function to allow user to clear sub breeds assocaited with a dog in the add dog modal popup
function clearSubBreed() {
    document.getElementById('addDogSubBreedDisplay').value = '';
}

// Function to allow user to enter a sub breed to a dog in the edit dog modal popup
function addEditSubBreed() {
    var inputbox = document.getElementById('editDogSubBreedInput');
    if (inputbox.value !== '') {
        if ((document.getElementById('editDogSubBreedDisplay').value) !== '') {
            document.getElementById('editDogSubBreedDisplay').value += ', ' + inputbox.value;
        }
        else {
            document.getElementById('editDogSubBreedDisplay').value += inputbox.value;
        }
        document.getElementById('editDogSubBreedInput').value = '';
    }
    else {
        alert("Please enter a Sub-Breed!");
    }
}

// Function to allow user to clear sub breeds assocaited with a dog in the edit dog modal popup
function clearEditSubBreed() {
    document.getElementById('editDogSubBreedDisplay').value = '';
}