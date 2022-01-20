$(function () {
    mktDatatable.button().add(0,
        {
            text: '<i class="fas fa-folder-plus"></i> Add Location',
            action: function () { $('#companyModal').modal('show'); },
            className: 'btn btn-primary'
        });
});