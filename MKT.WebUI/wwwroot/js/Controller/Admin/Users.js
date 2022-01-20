$(function () {
    mktDatatable.button().add(0,
        {
            text: '<i class="fas fa-folder-plus"></i> Add User',
            action: function () { $('#usersModal').modal('show'); },
            className: 'btn btn-primary'
        });
});