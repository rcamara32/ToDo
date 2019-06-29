$(document).ready(function () {
    toastr.options = {
        "positionClass": "toast-bottom-right",
    };

    GetAllTodoListByUser();
});

function GetAllTodoListByUser() {

    $('#todoTable').DataTable({
        destroy: true,
        "order": [[4, "asc"]],

        responsive: {
            details: {
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return col.hidden ? "<tr><td><div class='col-sm-6'>" + col.title + ":</div></td><td><div class='col-sm-6'>" + col.data + "</div></td></tr>" : "";
                    }).join('');

                    return data ? $('<table/>').append(data) : false;
                }
            }
        },

        ajax: {
            type: 'GET',
            url: '/Todo/GetAllTodoListByUser',
            dataFilter: function (data) {
                var json = jQuery.parseJSON(data);                
                return JSON.stringify(json);
            },
            dataSrc: function (json) {
                return json;
            }
        },

        columns: [
            { "data": "Description", title: "Description", "sWidth": "60%" },
            { "data": "ModificationDate", title: "Last Modification", "sWidth": "25%" },
            { "data": "Id", title: "Done", "sWidth": "5%" },
            { "data": "Id", title: "Actions", "sWidth": "10%" },
            { "data": "Id", title: "Id" }
        ],

        "columnDefs": [
            {
                "targets": [0],
                "visible": true,
                "orderable": true,
                render: function (data, type, full, meta) {
                    return "<div class='text-wrap'>" + data + "</div>";
                }
            },
            {
                "targets": [2],
                "visible": true,
                "orderable": false,
                "sWidth": "5%",                
                "render": function (data, type, row) {
                    var done = row.Done ? "checked" : "";
                    return "<td>" +
                        "<input type='checkbox' onchange='DoneTodo(this," + row.Id + ");' " + done + "/>" +
                        "</td> "
                }
            },
            {
                "targets": [3],
                "visible": true,
                "orderable": false,
                "sWidth": "10%",
                "render": function (data, type, row) {

                    var disabledEdit = row.Done ? "disabled" : "";
                    var title = row.Done ? "To do completed!" : "Edit To Do";

                    var editButton = "<td>" +
                        "<button class='btn btn-default' title='" + title + "' onclick='OpenEditTodo(" + row.Id + ");'" + disabledEdit + ">" +
                        "<span class='glyphicon glyphicon-pencil'></span>" +
                        "</button>" +
                        "</td> ";

                    var deleteButton = "<td>" +
                        "<button class='btn btn-default' title='Delete To Do Item' onclick='DeleteTodo(" + row.Id + ");'>" +
                        "<span class='glyphicon glyphicon-trash text-danger'></span>" +
                        "</button>" +
                        "</td> ";

                    return editButton + " " + deleteButton;

                },
            },
            {
                "targets": [4],
                "visible": false           
            }
        ]
    });
}

function DoneTodo(input, id) {

    var cheched = $(input).is(":checked");
    var message = cheched ? "Do you want to change this item to done?" : "Do you want to change this item to not done?";
    var verify = confirm(message);

    if (verify) {
        $.ajax({
            type: "POST",
            url: '/Todo/Done',
            data: {
                Id: id,
                Done: cheched
            },
            success: function (data) {
                if (data) {
                    GetAllTodoListByUser();                   
                    toastr.success('To Do edited successfully...');
                }
            },
            error: function (xhr, status, error) {                
                toastr.error('Error to edit item...')
            }
        });
    } else {
        $(input).prop("checked", !cheched);
    }
}

function OpenEditTodo(id) {
    $.ajax({
        type: "GET",
        url: '/Todo/GetById?id='.concat(id),
        success: function (data) {
            if (data) {
                $('#hiddenEditId').val(data.Id);                
                $('#editLastModification').val(data.ModificationDate);
                $('#editDescription').val(data.Description);
                $('#modalEditTodo').modal('show');
            }
        },
        error: function (xhr, status, error) {
            toastr.error('Error to load item...')
        }
    });
}

function DeleteTodo(id) {

    var deleteItem = confirm("Do you want to delete this item?");
    if (deleteItem) {
        $.ajax({
            type: "POST",
            url: '/Todo/Delete?id='.concat(id),
            success: function (data) {
                if (data) {
                    GetAllTodoListByUser();
                    toastr.success('To Do deleted successfully...');
                }
            },
            error: function (xhr, status, error) {
                toastr.error('Error to delete To Do item...')
            }
        });
    }
}