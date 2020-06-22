var controller = {
    init: function () {
        controller.getListCart();
        controller.registerEvent();

    },

    registerEvent: function () {
        
        $(".Xoa").off('click').on('click', function () {
            var id = $(this).data('id');
            controller.DeleteCartItem(id);
        });


    },
    getListCart: function () {
        $(document).ready(function () {
            $.ajax({
                url: '/Cart/GetListGioHang',
                dataType: 'json',
                type: 'GET',
                success: function (response) {
                    if (response.status) {
                        var result = response.data;
                        var GetListCart = $("#GetListCart");

                        $.each(result, function (index, item) {
                            GetListCart.append('  <li id="sp-' + item.product.MaSanPham + '"><div class="row"><div class= "col"> <img class="Ava" src="'+item.product.Linkanh+'" style="height: 100px;width: 100px "></div>'
                                +'<div class="product">'
                                    +'<div class="col"><label class="setColor">'+item.product.TenSanPham+' </label></div>'
                                    +'<div class="col"><label id="Gia" class="setColor">'+item.product.Gia+'</label></div>'
                                    +'<div class="col"><input id="txtTopping" class="toppingColor" type="text" value="'+item.Topping+'" disabled></div>'
                                   +'<div class="col"><input id="SOluong" class="sizeColor" type="number" value="'+item.Quanity+'" min="1"> </div>'
                                   +'<div class="col"> <input id="txtSize" class="sizeColor" type="text" value="'+item.TenSize+'" disabled></div>'
                                  +'<button type="button" class="Xoa" data-id='+item.product.MaSanPham+'>Xóa</button> </div> </div> </li>');
                        });
                        controller.registerEvent();
                    }
                },  
                  error: function (err) {
                    alert(err.status)
                }

            })
        })

    },
    DeleteCartItem: function (id) {
        $(document).ready(function () {
            $.ajax({
                data: {id: id },
                url: '/Cart/XoaSanPham',
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    if (response.status) {
                        var total = response.data;
                        var Tien = response.tien;
                        $('#sp-' + id).remove();

                        total--;

                        $("#TongTien").val("" + Tien);
                        $('.NotiQuanity').html('<i class="fas fa-shopping-cart"></i>&nbsp;(' + total + ')')  ;
                        $("#QuanityCart").text("GIỎ HÀNG ("+total+" Sản phẩm)");
                    }
                },
                error: function (err) {
                    alert(err.status)
                }

            })
        })
     

    }


}

controller.init();