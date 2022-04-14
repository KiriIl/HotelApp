$(document).ready(function () {

    $.get(`/User/UpdateNotifications`);

    const unchecked = 1;
    const checked = 2;

    var counter = 0;
    getNotifications();
    setInterval(getNotifications, 100000);

    $('.notification').click(function () {
        $('.notification-popup').toggleClass('hide');
    })

    function getNotifications() {

        $('.notification-element').remove();
        $.get('/User/GetNotifications')
            .done(function (data) {
                counter = 0;
                for (var i = data.length - 1; i >= 0; i--) {
                    if (data[i].status == 1) {
                        counter++;
                    }

                    var block = $('.notification-popup');
                    block.append(
                        `<div class="notification-element">` +
                        `<div class="notification-content">` +
                        `<div class="notification-id hide">${data[i].id} </div >` +
                        `<div class="notification-status hide">${data[i].status} </div >` +
                        `<div class="notification-message">${data[i].message} </div >` +
                        `</div>` +
                        `</div>`
                    );
                }

                $('.notification-element').hover(function () {
                    updateStatus(this);
                }, function () { });

                updateCounter();
            })
    }

    function updateCounter() {
        if (counter == 0) {
            $('.notify-counter').addClass('hide');
        }
        else {
            $('.notify-counter').removeClass('hide').empty().append(counter);
        }
    }

    function updateStatus(context) {
        var block = $(context).find('.notification-status');
        if (block.html().trim() == unchecked) {
            var id = $(context).find('.notification-id').html().trim();
            block.empty().append(checked);
            counter--;
            updateCounter();
            $.get(`/User/ChangeNotificationStatus?notificationId=${id}&status=${checked}`);
        }
    }
});