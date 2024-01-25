$(document).ready(function () {
    $(".js-delete").on('click', function () {

        var a = $(this);
        var Id = a.data('id');
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to see  This Restaurant !",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: `/Admin/Delete/${Id}`,
                        type: "DELETE",
                        success: function () {
                            swal("Resturent  has been deleted!", {
                                icon: "success",


                            });
                            $(`#tr${Id}`).remove();
                        }

                        ,
                        error: function () {
                            swal.fire(
                                'Oooops...',
                                'Something went wrong.',
                                'error'
                            );
                        }

                    });


                } else {
                    swal("We Not Do Any Action in Your Data");
                }
            });



    });
}); 

