
var dataTable;

$(document).ready(function() {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/admin/category/GetAll",
            "type": "GET", 
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "50%" }, 
            { "data": "displayOrder", "width": "50%" },
            {
                "data": "id", 
                "render": function(data) {
                    return `<div class="text-center">
                                <a href="/Admin/category/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width: 100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
&nbsp;
                                <a href="/Admin/category/Delete/${data}" class='btn btn-danger text-white' style='cursor:pointer; width: 100px;'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>


                            </div>
                        `;
                }, "width": "30px"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width" : "100%"
    });
}

function Delete(url) {
    swal({
        title: "are you sure you want to delete?", 
        text: "you will not be able to restore the content", 
        type: "warning", 
        showCancelButton: true,
        confirmButtonColor: "#DD6B55", 
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    }, function() {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function(data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }

    );
}
