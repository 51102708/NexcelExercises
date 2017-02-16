$("#icon-filter").click(function () {
    $(".panel-body").slideToggle();
});

$("#btn-toggle").click(function () {
    $(".sidebar-wrapper").toggleClass("toggle-sidebar-wrapper");
});

$('#btn-search').click(function (e) {
    if ($('#search-input').val() === '') {
        e.preventDefault();
        $('#search-input').focus();
    }
});

$('#deleteModal').on('show.bs.modal', function (e) {
    var deleteName = $(e.relatedTarget).data('delete-name');
    $(e.currentTarget).find('span[name="labelName"]').text(deleteName);

    var deleteLink = $(e.relatedTarget).data('delete-link');
    $(e.currentTarget).find('form').attr("action", deleteLink);
});