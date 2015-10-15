using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.FactoryMethod
{
    class ConcreteFactory : Factory
    {
        protected override IProduct CreateProduct()
        {
            return new ConcreteProduct();
        }
    }
}
