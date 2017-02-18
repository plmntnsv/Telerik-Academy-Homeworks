using Cosmetics.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine.Fakes
{
    internal class CosmeticsEngineExtended : CosmeticsEngine
    {
        public CosmeticsEngineExtended(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> CategoriesExposer
        {
            get
            {
                return this.categories;
            }
        }

        public IDictionary<string, IProduct> ProductsExposer
        {
            get
            {
                return this.products;
            }
        }
    }
}
