$(document).ready(function () {
    getData();
});

function saveDog() {
    var name = document.getElementById('dogBreedInput').value;
    var description = document.getElementById('dogDescriptionInput').value;
    if (name) {
        if (!description) {
            description = 'No Description'; // description can be blank
        }
        var uri = 'api/dogs/' + name + '/' + description;
        $.getJSON(uri)
            .done(function(data) {
                $('#addNewDogModal').modal('hide');
                alert("Dog added successfully!");
                clearData();
            })
            .fail(function(jqXHR, textStatus, err) {
                alert("Unable to add dog, please check that it does not already exist!");
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
