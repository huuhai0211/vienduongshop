var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function(){
        $('.btnAddToCart').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            $.ajax({
                url: '/ShoppingCart/Add',
                data: {
                    productId: productId,

                },
                type: 'POST',
                dataType: 'json',
                success: function (res) {
                    if (res.status) {
                        alert('Thêm sản phẩm thành công');
                    }
                }
            });
        });
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html(); 
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: item.Product.Price,
                            Quantity: item.Quantity,
                            SubTotal: item.Quantity * item.Product.Price,
                        });
                    });
                    $('#cartBody').html(html);
                }
            }
        })
    },
    addItem: function(productId){
      
    },
}
cart.init();