$(document).ready(function () {

    $('#modalEditTodo').on('hidden.bs.modal', function () {
        $('#hiddenEditId').val('');
        $('#editLastModification').val('');
        $('#editDescription').val('');
    });

    $('#modalEditTodo').on('shown.bs.modal', function (e) {
        var input = $('#editDescription'),
            count = 0,
            limit = 255;

        count = input.val().length;
        var remaining = limit - count;

        CountDescriptEdit(remaining);

        input.keyup(function (e) {
            count = $(this).val().length;
            remaining = limit - count;
            CountDescriptEdit(remaining);
        });
    });

});

function CountDescriptEdit(count) {
    var display = $('#edit-text-limit');

    var txt = (Math.abs(count) === 1) ? count + ' Character Remaining' : count + ' Characters Remaining'
    display.html(txt);
}

function EditTodo() {
    $.ajax({
        type: "POST",
        url: '/Todo/Edit',
        data: {
            Id: $('#hiddenEditId').val(),
            NewDescription: $('#editDescription').val()
        },
        success: function (data) {
            if (data) {
                GetAllTodoListByUser();
                toastr.success('To Do edited successfully...');
                $('#modalEditTodo').modal('hide');
            } else {
                toastr.info('error to edit item...')
            }
        },
        error: function (xhr, status, error) {            
            toastr.error('error to edit item...')
        }
    });
}