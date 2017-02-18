using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products.Mocks
{
    internal class ShoppingCartExtended : ShoppingCart
    {
        public IList<IProduct> ProductsExposer
        {
            get
            {
                return this.products;
            }
        }
    }
}
