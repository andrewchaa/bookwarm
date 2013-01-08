$(function () {
    var pageNumber = $('#pageNumber').val(),
        pageNumberCheck = function () {
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