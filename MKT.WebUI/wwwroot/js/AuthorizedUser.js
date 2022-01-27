var notificationString = `<a class="dropdown-item d-flex align-items-center" href="{notificationLink}" data-notification-id={notificationId}>
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

var bildirimSayiBadgetString = `<span class="badge badge-danger badge-counter" id="bildirimSayisiBadge">{bildirimSayisi}</span>`;

$(function() {
    $.get('/Home/GetNotifications',
        function (result) {
            if (result.length > 0) {
               
            }
            let bildirimSayisi = 0;
            $.each(result,
                function (index, item) {
                    let tempNotification = notificationString;
                    tempNotification = tempNotification.split('{notificationDate}').join(item.date);
                    tempNotification = tempNotification.split('{notificationId}').join(item.notificationId);
                    tempNotification = tempNotification.split('{notificationDescription}').join(item.description);
                    tempNotification = tempNotification.split('{notificationIcon}').join(`/asset/icon/${item.icon}`);
                    tempNotification = tempNotification.split('{notificationLink}').join(item.link);
                    $('#notificationsArea').append(tempNotification);

                    if (localStorage.getItem(item.notificationId) !== 'read') {
                        bildirimSayisi++;
                    }
                });
            if (bildirimSayisi > 0) {
                bildirimSayiBadgetString = bildirimSayiBadgetString.split('{bildirimSayisi}').join(bildirimSayisi);
                $('#bildirimSayiBadget').append(bildirimSayiBadgetString);
            }
        });
});

$(function() {
    $('#notificationDropdown').parent().on('shown.bs.dropdown', function () {
        let notificationArea = $('#notificationsArea');
        let notifications = notificationArea.find('.dropdown-item');
        $.each(notifications, function (index, item) {
            let notificationId = $(item).data('notificationId');
            if (localStorage.getItem(notificationId) !== 'read') {
                localStorage.setItem(notificationId, 'read');
            }
        });
        $('#bildirimSayisiBadge').remove();
    });
});