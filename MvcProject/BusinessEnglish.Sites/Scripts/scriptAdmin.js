    $("#icon-filter").click(function(e) {
        $(".panel-body").slideToggle();
    });


    $("#btn-toggle").click(function () {

        $(".body-content").toggleClass("toggle-body-content");
        $(".sidebar-wrapper").toggleClass("toggle-sidebar-wrapper");
    });

    $('#deleteModal').on('show.bs.modal', function (e) {
        var deleteName = $(e.relatedTarget).data('delete-name');
        $(e.currentTarget).find('span[name="topicName"]').text(deleteName);
        var deleteLink = $(e.relatedTarget).data('delete-link');
        $(e.currentTarget).find('form').attr("action", deleteLink);
    });