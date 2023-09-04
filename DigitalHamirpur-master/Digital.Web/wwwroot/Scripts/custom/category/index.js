(function ($) {
    function CategoryIndex() {
        debugger;
        var $this = this;
        var CategoryDetailsGrid = '';
        function initializeGrid() {
            if ($.fn.DataTable.isDataTable(CategoryDetailsGrid)) {
                $(CategoryDetailsGrid).DataTable().destroy();
            }
            CategoryDetailsGrid = new Global.GridHelper('#grid-category-details', {
                "columnDefs": [
                    { "targets": [0], "visible": false }, //Id
                    { "targets": [1], "visible": true, "sortable": false, "searchable": false }, //count
                    { "targets": [2], "sortable": true, "searchable": true }, //name
                    { "targets": [3], "sortable": true, "searchable": true }, //createddate

                    {
                        "targets": [4], "sortable": false, "searchable": false, "data": "4",
                        "render": function (data, type, row, meta) {
                            var json = {
                                type: "checkbox",
                                class: "switchBox switch-small",
                                value: row[0],
                                'data-on': "success",
                                'data-off': "danger",
                                'data-on-text': "Yes",
                                'data-off-text': "No"
                            };

                            if (data === "True") {
                                json.checked = true;
                            }
                            return $('<input/>', json).get(0).outerHTML;
                        }
                    },//IsActive
                    {
                        "targets": [5], "data": "0", "searchable": false, "sortable": false,
                        "render": function (data, type, row, meta) {
                            var actionLink = $("<a/>", {
                                href: "/admin/Category/CreateEdit/" + row[0],
                                class: "btn btn-primary",
                                title: 'Edit',
                                oncontextmenu: 'return false',
                                text:'Edit',
                                //html: $("<i/>", {
                                //    class: "fa fa-edit"
                                //})
                            }).get(0).outerHTML + "&nbsp;"; // Edit 

                            actionLink += $("<a />", {
                                href: "/admin/Category/View?id=" + row[0],
                                class: "btn btn-outline-success btn-sm copy-new-project",
                                'data-id': row[0],
                                title: 'Copy',
                                oncontextmenu: 'return false',
                                text: 'View',
                                //html: $("<i/>", {
                                //    class: "fa fa-copy"
                                //})
                            }).get(0).outerHTML + "&nbsp;";// Copy New

                            actionLink += $("<a/>", {
                                href: "javascript:void(0);",
                                class: "btn btn-danger btn-md delete-project",
                                'data-id': row[0],
                                title: 'Delete',
                                text: 'Delete',
                                oncontextmenu: 'return false',
                                //html: $("<i/>", {
                                //    class: "fa fa-trash" // Delete 
                                //})
                            }).get(0).outerHTML;

                            return actionLink;
                        }
                    }
                ],
                "direction": "rtl",
                "bPaginate": true,
                "sPaginationType": "simple_numbers",
                "bProcessing": true,
                "bServerSide": true,
                "bAutoWidth": false,
                "stateSave": true,
                "sAjaxSource": "/admin/Category/Index",
                "fnServerData": function (url, data, callback) {

                    $.ajax({
                        "url": url,
                        "data": data,
                        "success": callback,
                        "contentType": "application/x-www-form-urlencoded; charset=utf-8",
                        "dataType": "json",
                        "type": "POST",
                        "cache": false,
                        "error": function () {

                        }
                    });
                },
                "fnDrawCallback": function (oSettings) {
                    initGridControlsWithEvents();

                    if (oSettings._iDisplayLength > oSettings.fnRecordsDisplay()) {
                        $(oSettings.nTableWrapper).find('.dataTables_paginate').hide();
                    }
                    else {
                        $(oSettings.nTableWrapper).find('.dataTables_paginate').show();
                    }
                },
            });
        }

        $(document).on('click', '.delete-project', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            alertify.confirm('Delete', 'Do you want to delete this project?', function (e) {
                $.ajax({
                    url: '/admin/Category/deleteproject',
                    type: 'GET',
                    data: { id: id },
                    contentType: 'application/json',
                    dataType: 'json',
                    success: function (result) {
                        $('#grid-project-details').DataTable().ajax.reload(null, false);
                        if (result) {
                            alertify.confirm().close();
                            alertify.success('Category deleted successfully');
                        }
                        else {
                            alertify.confirm().close();
                            alertify.error('Category not delete project. Please check with support!');
                        }
                    },
                    error: function (result) {
                        alertify.confirm().close();
                        alertify.error('Category not delete project. Please check with support!');
                    }
                });


            }
                , function () { });

        });



        function initGridControlsWithEvents() {
            if ($('.switchBox').data('bootstrapSwitch')) {
                $('.switchBox').off('switchChange.bootstrapSwitch');
                $('.switchBox').bootstrapSwitch('destroy');
            }

            $('.switchBox').bootstrapSwitch()
                .on('switchChange.bootstrapSwitch', function () {
                    var switchElement = this;
                    $.get('/admin/Category/UpdateStatus', { id: this.value }, function (result) {
                        if (!result.isSuccess) {
                            $(switchElement).bootstrapSwitch('toggleState', true);
                        }
                        else {
                            alertify.success(result.data, 0);
                        }
                    });
                });
        }



        $this.init = function () {
            debugger;
            initializeGrid();
        };
    }

    $(function () {
        debugger;
        var self = new CategoryIndex();
        self.init();
    })

})(jQuery)