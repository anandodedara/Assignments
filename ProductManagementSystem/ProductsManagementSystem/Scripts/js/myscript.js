
$('#largeImageModalCenter').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var imageUrl = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    
    if (imageUrl == "not available") {
        modal.find('#ImageDescription').text("Large Image Not Available");
        modal.find('#largeImage').attr("src", "");
    }
    else
    {
        modal.find('#largeImage').attr("src", imageUrl);
        modal.find('#ImageDescription').text("");
    }

});



$(document).ready(function () {
    $('#myTable').DataTable();
});
$("#chkSelectAll").click(function () {
    $(".checkbox").prop('checked', $(this).prop('checked'));
    var selecteCount = getSelectedCheckbox().length;
    if (selecteCount > 0)
        $('#multipleDeleteBtn').attr("disabled", false);
    else
        $('#multipleDeleteBtn').attr("disabled", true);
});

$(".checkbox").click(function () {
    var selecteCount = getSelectedCheckbox().length;
    if (selecteCount > 0)
        $('#multipleDeleteBtn').attr("disabled", false);
    else
        $('#multipleDeleteBtn').attr("disabled", true);
});


function getSelectedCheckbox() {
    var selectedCheckboxList = new Array();

    $.each($("input[name='rowCheckBox']:checked").closest("td").siblings("td"),
        function () {
            var id = $(this).find('form').find('input[id="id"]').val();
            if (id != null) {
                selectedCheckboxList.push(id);
            }
        });
    return selectedCheckboxList;
}

$("#multipleDeleteBtn").click(function () {
    

    $('.toast').toast('show');

    var values = getSelectedCheckbox();

    if (values.length == 0) {
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
                
                
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                location.reload();
            }
        });

    }


})


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