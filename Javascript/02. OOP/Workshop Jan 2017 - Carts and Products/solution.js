/*jshint esversion: 6 */

function solve() {
    function getProduct(productType, name, price) {
        return {
            productType: productType,
            name: name,
            price: price
        };
    }

    function getShoppingCart() {
        let cart = [];

        function add(product) {
            cart.push(product);
            return this;
        }

        function remove(product) {
            let indexOfProduct = cart.findIndex(p => p.name === product.name && p.productType === product.productType && p.price === product.price);
            if (cart.length === 0 || indexOfProduct === -1) {
                throw "Empty cart or no such product found";
            }
            cart.splice(indexOfProduct, 1);
            return this;
        }

        function showCost() {
            let cost = cart.reduce((a, b) => a + b.price, 0);
            return cost;
        }

        function showProductTypes() {
            let uniqueProducts = [];
            cart.sort((a, b) => a.productType === b.productType ? 0 : a.productType < b.productType ? -1 : 1);
            for (let i = 0; i < cart.length; i += 1) {
                if (i === 0) {
                    uniqueProducts.push(cart[i].productType);
                    continue;
                }
                if (cart[i].productType === cart[i - 1].productType) {
                    continue;
                }
                uniqueProducts.push(cart[i].productType);
            }
            return uniqueProducts;
        }

        function getInfo() {
            function products() {
                cart.sort((a, b) => a.name === b.name ? 0 : a.name < b.name ? -1 : 1);
                let uniqueProducts = [];
                let pos = 0;

                for (let i = 0; i < cart.length; i += 1) {
                    if (i === 0) {
                        let newProd = {};
                        uniqueProducts.push(newProd);
                        uniqueProducts[pos].name = cart[i].name;
                        uniqueProducts[pos].totalPrice = cart[i].price;
                        uniqueProducts[pos].quantity = 1;
                        continue;
                    }
                    if (cart[i].name === cart[i - 1].name) {
                        uniqueProducts[pos].totalPrice += cart[i].price;
                        uniqueProducts[pos].quantity += 1;
                        continue;
                    }
                    pos += 1;
                    let newProd = {};
                    uniqueProducts.push(newProd);
                    uniqueProducts[pos].name = cart[i].name;
                    uniqueProducts[pos].totalPrice = cart[i].price;
                    uniqueProducts[pos].quantity = 1;
                }
                return uniqueProducts;
            }

            function totalPrice() {
                let price = cart.reduce((a, b) => a + b.price, 0);
                return price;
            }

            return {
                products: products(),
                totalPrice: totalPrice()
            };
        }
        return {
            products: cart,
            add: add,
            remove: remove,
            showCost: showCost,
            showProductTypes: showProductTypes,
            getInfo: getInfo
        };
    }
    return {
        getProduct: getProduct,
        getShoppingCart: getShoppingCart
    };
}

module.exports = solve();

// const {
//     getProduct,
//     getShoppingCart
// } = solve();

// let cart = getShoppingCart();

// // let pr1 = getProduct("Type 1", "Pr 1", 1);
// // let pr2 = getProduct("Type 1", "Pr 1", 2);
// // let pr3 = getProduct("Type 1", "Pr 1", 2);
// // let pr4 = getProduct("Type 1", "Pr 1", 2);
// // let pr5 = getProduct("Type 1", "Pr 1", 3);

// // let pr6 = getProduct("Type 1", "Pr 2", 5);
// // let pr7 = getProduct("Type 1", "Pr 2", 6);

// // cart.add(pr1);
// // cart.add(pr2);
// // cart.add(pr3);
// // cart.add(pr4);
// // cart.add(pr5);
// // cart.add(pr6);
// // cart.add(pr7);

// cart.products.push(getProduct("Type 1", "Pr 1", 1));
// cart.products.push(getProduct("Type 1", "Pr 1", 2));
// cart.products.push(getProduct("Type 1", "Pr 1", 2));
// cart.products.push(getProduct("Type 1", "Pr 1", 2));
// cart.products.push(getProduct("Type 1", "Pr 1", 3));


// cart.products.push(getProduct("Type 1", "Pr 2", 5));
// cart.products.push(getProduct("Type 1", "Pr 2", 6));

// let TEST = cart.getInfo().products;