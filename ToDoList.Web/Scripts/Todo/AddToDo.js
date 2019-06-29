$(document).ready(function () {

    $('#modalNewTodo').on('hidden.bs.modal', function () {
        $('#newDescription').val('');
    });

 
});

$(function () {
    var input = $('#newDescription'),
        display = $('#text-limit'),
        count = 0,
        limit = 255;

    count = input.val().length;
    var remaining = limit - count;

    update(remaining);

    input.keyup(function (e) {
        count = $(this).val().length;
        remaining = limit - count;
        update(remaining);
    });

    function update(count) {
        var txt = (Math.abs(count) === 1) ? count + ' Character Remaining' : count + ' Characters Remaining'
        display.html(txt);
    }

});

function AddTodo() {

    var newTodoDescription = $("#newDescription").val();

    if (newTodoDescription == null || newTodoDescription == "") {
        toastr.info('Please enter a description to save new To do item');
    } else {
        $.ajax({
            type: "POST",
            url: "/Todo/Add",
            data: {
                Description: newTodoDescription
            },
            success: function (data) {
                if (data) {
                    GetAllTodoListByUser();
                    $('#modalNewTodo').modal('hide');
                    toastr.success('To Do added successfully...');
                }
            },
            error: function (xhr, status, error) {
                toastr.error('Error to add To Do item...')
            }
        });
    }

   
}