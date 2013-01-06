$(function () {
    var pageNumberCheck = function() {
        var pageNumber = $('#pageNumber').val();
        console.log(pageNumber);
        $.post('/api/page', {
            userName: 'Andrew',
            pageNumber: pageNumber,
            title: document.title
        });
    };
    window.setInterval(pageNumberCheck, 10000);
});