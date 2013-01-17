$(function () {
    var isTitleChanged = false,
        bookTitle;
    var pageNumberCheck = function () {
        var pageNumber = $('#pageNumber').val();
        console.log(pageNumber);

        if (!!document.title) {
            $.post('/api/', {
                userName: 'Andrew',
                pageNumber: pageNumber,
                title: document.title
            });
        }
    };

    window.setInterval(pageNumberCheck, 5000);

});