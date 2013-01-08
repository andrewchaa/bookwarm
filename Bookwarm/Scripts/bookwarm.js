$(function () {
    var pageNumberCheck = function () {
        var pageNumber = $('#pageNumber').val();
        console.log(pageNumber);
        if (!!document.title) {
            $.post('/api/page', {
                userName: 'Andrew',
                pageNumber: pageNumber,
                title: document.title
            });
        }
    };

    window.setInterval(pageNumberCheck, 5000);

});