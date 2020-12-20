
$('#largeImageModalCenter').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var imageUrl = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('#largeImage').attr("src", imageUrl);

    

});



$(document).ready(function () {
    $('#myTable').DataTable();
});
$("#ckbCheckAll").click(function () {
    $(".checkbox").prop('checked', $(this).prop('checked'));
});

$("#removeBtn").click( function () {
    //$('.checkbox').has('input[name="rowCheckBox"]:checked').remove();

    $('.toast').toast('show');

    var values = new Array();

    $.each($("input[name='rowCheckBox']:checked").closest("td").siblings("td"),
        function () {
            var id = $(this).find('form').find('input[id="id"]').val();
            if (id != null) {
                values.push(id);
            }
        });

    if (values.length==0) {
        return false;
    }
    if (confirm("Are you sure to delete " + values.length + " items?")) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/Products/DeleteMultiple/",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(values),
            success: function () {

                location.reload();

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });

    }

    
})

$("rowCheckBox").on("click", function () {
    $("#removeBtn").removeAttr("disabled");
});

$("#deleteForm").submit(function () {
    if (confirm("Are you sure?")) {
        $(this).submit();
    } else {
        return false;
    }
});


$('#toast').on('show.bs.toast', function () {
    alert('The toast is about to be shown.');
});
$('.toast').on('shown.bs.toast', function () {
    alert('The toast is now fully shown.');
});
$('.toast').on('hide.bs.toast', function () {
    alert('The toast is about to be hidden.');
});
$('.toast').on('hidden.bs.toast', function () {
    alert('The toast is now hidden.');
});

$(function () {
    $('.toast').show();
});