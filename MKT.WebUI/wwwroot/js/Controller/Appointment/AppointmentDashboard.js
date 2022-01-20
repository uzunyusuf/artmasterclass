$(function () {
    $('form').submit(function () {
        $(this).find("button[type='submit']").prop('disabled', true);
    });

    $('#chooseLocationModal').on('shown.bs.modal',
        function(event) {
            var button = $(event.relatedTarget);
            var data = button.data('orderid');
            $('#orderIdInputId').val(data);
        });
});

function AssignOrderToLocation(formSubmitButton) {
    var $form = $(formSubmitButton).parents('form');
    var data = $form.serialize();
    $.ajax({
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
        error: function (xhr, status, error) {
            HataMesajGoster('Error', stringTurkcelestir(xhr.responseJSON.message));
        },
        success: function (response, textStatus, xhr) {
            let a = data;
            let b = $form;
            let orderId = $form.find('#orderIdInputId').val();
            let assignedLocation = $('#chooseLocationModal').find('select').find('option:selected').text();

            $(`#${orderId}`).find('.card-header').addClass('bg-gradient-warning');
            $(`#${orderId}`).find('.header-main-flex').append(`<h6 class="text-white">Assigned to: ${assignedLocation}</h6>`);
            $(`#${orderId}`).find('.header-main-flex').removeClass('justify-content-start');
            $(`#${orderId}`).find('.header-main-flex').addClass('justify-content-between');
            $(`#${orderId}`).find('h6').removeClass('text-primary');
            $(`#${orderId}`).find('h6').addClass('text-white font-weight-bold');

            $('#chooseLocationModal').modal('hide');
        }
    });
}