(function ($) {

    function AddCategory() {
        var $this = this;
        bindData();
       
        
        function bindData() {
            $.get('/Category/CategoryList', function (data) {
                // Bind the returned data to the elements on your page
                $('#categoryTable tbody').empty(); // Clear existing table rows
                $.each(data, function (index, category) {
                    var serialNumber = index + 1;
                    var row = '<tr>' +
                        '<td>' + serialNumber + '</td>' +
                        '<td>' + category.categoryTitle + '</td>' +
                        '<td>' + category.categoryDecription + '</td>' +
                        '<td>' + category.isActive + '</td>' +
                        '<td>' +
                        '<a href="category/CreateEdit?id=' + category.categoryId + '" class="btn btn-primary editButton" data-id="' + category.categoryId + '">' +
                        '<i class="fas fa-edit"></i> Edit' +
                        '</a>' +
                        '<a href="#" data-target="#modal-delete-category" class="btn btn-danger deleteButton" data-id="' + category.categoryId + '">' +
                        '<i class="fas fa-trash-alt"></i> Delete' +
                        '</a>' +
                        '</td>' +
                        '</tr>';
                    $('#categoryTable tbody').append(row); // Append a new row
                });

               
            });
        }


        
        $this.init = function () {
            
            bindData();
            

        }

    }



    $(
        function () {
            var self = new AddCategory();
            self.init();
        }
    )

})(jQuery)