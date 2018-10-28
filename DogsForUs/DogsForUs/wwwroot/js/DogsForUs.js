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
               
            })
            .fail(function(jqXHR, textStatus, err) {

            });
    }
    // else show input error
    $('#addNewDogModal').modal('hide');
    $('#accordion').empty();
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
