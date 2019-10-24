
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
                                <a href="/Admin/category/Delete/${data}" class='btn btn-success text-white' style='cursor:pointer; width: 100px;'>
                                    <i class='far fa-edit'></i> Delete
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

