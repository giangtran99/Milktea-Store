var Controller =  {
     Register: function()
    {
    
       
    },
    loadTraSua: function () {
        $(document).ready(function () {
            $.ajax({
                url: '/Home/GetListTraSua',
                dataType: 'json',
                type: 'GET',
                success: function (response) {
                    if (response.status) {
                        var result = response.data;
                        $.each(result, function (index, item) {
                            var ListTraSua = $('#ListTraSua');
                            ListTraSua.append(' <li><div class= "TraSua">'
                                + '<div class="TraSuaimg">'
                                + ' <a href="/Home/ShopDetail/'+item.MaSanPham+'"><img class="AvaTraSua" src="'+item.Linkanh+'" /></a> </div>'
                                + '<div class="TraSualbl">'
                                + '<label>' + item.TenSanPham + '</label>'
                                + '<br><label>' + item.Gia + ' VND</label>'
                                + '</div><br><a style="text-decoration: none;" class="ChiTiet" href="/Home/ShopDetail/' +item.MaSanPham + '">CHI TIẾT</a></div> </li>');

                        });
                    }
                },
                error: function (err) {
                    alert(err.status)
                }


            })
        })
     
    }
  
    
    
}
Controller.loadTraSua();