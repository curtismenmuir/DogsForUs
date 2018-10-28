$(document).ready(function () {
    getData();
});

function addDog() {
    var name = document.getElementById('dogBreedInput').value;
    var description = document.getElementById('dogDescriptionInput').value;
    if (name) {
        if (!description) {
            description = 'No Description'; // description can be blank
        }
        var uri = 'api/dogs/';
        var newDog = 'name=' + name + '&description=' + description;
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

function clearData() {
    $('#accordion').empty();
    document.getElementById('dogBreedInput').value = '';
    document.getElementById('dogDescriptionInput').value = '';
    document.getElementById('editDogBreedInput').value = '';
    document.getElementById('editDogDescriptionInput').value = '';
    document.getElementById('editDogOriginalName').value = '';
    document.getElementById('deleteDogOriginalName').value = '';
    getData();
}

function getData() {
    var uri = 'api/dogs/'
    var count = 1;
    $.getJSON(uri)
        .done(function(data) {
            $('#accordion').empty();
            $.each(data, function (key, value) {
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
                                value.description +
                                '<br>' +
                                '<button type="button" id="btn' + value.name + '_' + value.description + '" class="btn btn-primary" onclick="confirmEdit(this.id);">Edit</button>' +
                                '<button type="button" id="btn' + value.name + '" class="btn btn-primary" onclick="confirmDelete(this.id);">Delete</button>' +
                            '</div>' +
                        '</div>' +
                    '</div>'
                );
                count = count + 1;
            });
        })
        .fail(function (jqXHR, textStatus, err) {

        });
}

function confirmEdit(btn_id) {
    var details = (btn_id.substr(3)).split('_');
    document.getElementById('editDogBreedInput').value = details[0];
    document.getElementById('editDogDescriptionInput').value = details[1];
    document.getElementById('editDogOriginalName').value = details[0];
    $('#editDogModal').modal('show');
}

function editDog() {
    var originalName = document.getElementById('editDogOriginalName').value;
    var name = document.getElementById('editDogBreedInput').value;
    var description = document.getElementById('editDogDescriptionInput').value;
    var uri = 'api/dogs/' + originalName;
    var newDog = 'name=' + name + '&description=' + description;
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

function confirmDelete(btn_id) {
    document.getElementById('deleteDogOriginalName').value = btn_id.substr(3);
    $('#deleteDogModal').modal('show');
}

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