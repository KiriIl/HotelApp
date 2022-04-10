$(document).ready(function () {

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
                for (var i = 0; i < data.length; i++) {
                    if (data[i].status == 0) {
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
        if (block.html().trim() == '0') {
            block.empty().append('1');
            counter--;
            updateCounter();
            //request to db, change notify status to checked
        }
    }
});