$(document).ready(function () {
    $(".del-menu").on('click', function () {

        var a = $(this);
        var Id = a.data('id');
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to see  This Menu  !",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: `/Menu/Delete/${Id}`,
                        type: "DELETE",
                        success: function () {
                            swal("Menu  has been deleted!", {
                                icon: "success",


                            });
                            $(`#d${Id}`).remove();
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

    // -------------------

    $(".del-meal").on('click', function () {

        var x = $(this);
        var Ids = x.data('id');
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to see  This meal  !",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: `/Meal/Delete/${Ids}`,
                        type: "DELETE",
                        success: function () {
                            swal("Meal  has been deleted!", {
                                icon: "success",


                            });
                            $(`#tr${Ids}`).remove();
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

