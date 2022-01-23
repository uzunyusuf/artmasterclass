var notificationString = `<a class="dropdown-item d-flex align-items-center" href="{notificationLink}">
                                    <div class="mr-3">
                                        <div class="icon-circle bg-primary">
                                            <img src="{notificationIcon}" width="40">
                                        </div>
                                    </div>
                                    <div>
                                        <div class="small text-gray-500">{notificationDate}</div>
                                        <span class="font-weight-bold">{notificationDescription}</span>
                                    </div>
                                </a>`;

var bildirimSayiBadgetString = `<span class="badge badge-danger badge-counter">{bildirimSayisi}</span>`;

$(function() {
    $.get('/Home/GetNotifications',
        function (result) {
            if (result.length > 0) {
                bildirimSayiBadgetString = bildirimSayiBadgetString.split('{bildirimSayisi}').join(result.length);
                $('#bildirimSayiBadget').append(bildirimSayiBadgetString);
            }
            $.each(result,
                function (index, item) {
                    let tempNotification = notificationString;
                    tempNotification = tempNotification.split('{notificationDate}').join(item.date);
                    tempNotification = tempNotification.split('{notificationDescription}').join(item.description);
                    tempNotification = tempNotification.split('{notificationIcon}').join(`/asset/icon/${item.icon}`);
                    tempNotification = tempNotification.split('{notificationLink}').join(item.link);
                    $('#notificationsArea').append(tempNotification);
                });
        });
});

$(function() {
    $('#notificationDropdown').parent().on('shown.bs.dropdown', function () {
    });
});