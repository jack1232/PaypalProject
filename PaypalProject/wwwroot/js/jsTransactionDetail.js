let items = [];
function getItems(obj) {
    obj.forEach(function (d) {
        items.push({
            name: d.Name,
            desciption: d.Description,
            sku: d.SKU,
            unit_amount: {
                currency_code: "USD",
                value: d.UnitPrice
            },
            quantity: d.Quantity,
            category: "PHYSICAL_GOODS"
        });
    });
}

paypal.Buttons({
    createOrder: function (data, actions) {
        return actions.order.create({
            purchase_units: [
                {
                    reference_id: "SPECIALPRODUCT",
                    description: "Sporting Goods",
                    custom_id: "CUST-Goods",
                    soft_descriptor: "Fashions",
                    amount: {
                        currency_code: "USD",
                        value: $('#totalCost').text(),
                        breakdown: {
                            item_total: {
                                currency_code: "USD",
                                value: $('#productCost').text().split(',')[0]
                            },
                            shipping: {
                                currency_code: "USD",
                                value: $('#shipping').val()
                            },
                            handling: {
                                currency_code: "USD",
                                value: $('#handling').val()
                            },
                            tax_total: {
                                currency_code: "USD",
                                value: $('#totalTax').text().split(',')[0]
                            }
                        }
                    },
                    items: items,
                    shipping: {
                        method: "United States Postal Service",
                        address: {
                            name: {
                                full_name: "John",
                                surname: "Doe"
                            },
                            address_line_1: "1234 Anytown St",
                            admin_area_2: "New York City",
                            admin_area_1: "NY",
                            postal_code: "11234",
                            country_code: "US"
                        }
                    }
                }
            ]
        });
    },
    onApprove: function (data, actions) {
        return actions.order.capture().then(function (details) {
            console.log(JSON.stringify(details, null, 4));
            alert('Transaction completed by ' + details.payer.name.given_name);
        });
    }
}).render('#div_paypal');