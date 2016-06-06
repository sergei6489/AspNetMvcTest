function Cart(setProductCountCartUrl, removeProductUrl, getCartUrl) {
    self = this;
    self.setProductCountCartUrl = setProductCountCartUrl;
    self.removeProductUrl = removeProductUrl;
    self.getCartUrl = getCartUrl;
    self.products = ko.observableArray([]);
    self.Refresh = function () {
        $.ajax({
            url: self.getCartUrl,
            contentType: "application/json",
            type: "Post",
            complete: function (data, status) {
                var result = JSON.parse(data.responseText);
                self.products.removeAll();
                $.each(result, function (key, value) {
                    self.products.push(new Product(value.Id, value.Name, value.Count, value.Price, setProductCountCartUrl));
                });
            }
        });
    };

    self.remove = function (product) {
        var dataObject = JSON.stringify({productId: product.id()});
        $.ajax({
            url: removeProductUrl,
            data: dataObject,
            contentType: "application/json",
            type: "POST",
            complete: function (key, value) {
                if (value == "success") {
                    self.products.remove(product);
                    var res = $("#countProducts");
                    res.text(parseInt(res.text()) -product.count());
                }
            }
        });
        self.products.remove(product);
    };
};
function Product(id, name, count, price, cartProductUrl) {
    var self = this;
    self.cartProductUrl = cartProductUrl;
    self.id = ko.observable(id);
    self.name = ko.observable(name);
    self.count = ko.observable(count);
    self.price = ko.observable(price);
    self.totalPrice = ko.computed(function ()
    { return self.count() * self.price() });

    self.ajaxProductCart = function () {
        var dataObject = JSON.stringify( { id: self.id(), count: self.count() });
        $.ajax({
            url: self.cartProductUrl,
            contentType: "application/json",
            type: "Post",
            data: dataObject,
            complete: function (data, status) {
                if (status != "success") {
                    alert('Ошибка');
                }
            }
        });
    };

    self.increment = function () {
        var currentCount = self.count();
        currentCount++;
        if (currentCount > 0) {
            self.count(currentCount);
            self.ajaxProductCart();
            var res = $("#countProducts");
            res.text(parseInt(res.text()) + 1);
        }
    };

    self.decrement = function () {
        var currentCount = self.count();
        currentCount--;
        if (currentCount > 0) {
            self.count(currentCount);
            self.ajaxProductCart();
            var res = $("#countProducts");
            res.text(parseInt(res.text()) - 1);
        }
    };
}