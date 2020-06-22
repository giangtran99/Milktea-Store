var controller = {
    init: function () {
        controller.registerEvent();
        
    },

    registerEvent: function () {

        $("#btnXacNhan").off('click').on('click', function () {
            var tk = $('#tk').val();
            var sdt = $('#sdt').val();
            var email = $('#email').val();
            var mk = $('#mk').val();
            var diachi = $('#dc').val();
            var ten = $('#ten').val();


            controller.Noti(tk,sdt,email,mk,diachi,ten);
        });

    },
    Noti: function (tk,sdt,email,mk,dc,ten) {
        $(document).ready(function () {
            $.ajax({
                url: '/Cart/ThanhToan?tk=' + tk + '&mk='+mk+'&ten='+ten+'&diachi='+dc+'&sdt=' + sdt + '&email=' + email +'',
                dataType: 'json',
                type: 'GET',
                success: function (response) {
                    if (response.status) {
                        var result = response.data;
                        alert(result);
                    }
                },
                async: false,
                error: function (err) {
                    alert(err.status);

                }
            })

        }
        )
     
    }


}

controller.init();