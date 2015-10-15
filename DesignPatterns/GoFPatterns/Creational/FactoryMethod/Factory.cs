using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.FactoryMethod
{
    abstract class Factory
    {
        protected abstract IProduct CreateProduct();

        public void DoSomeThing()
        {
            var product = CreateProduct();
            product.PrintThings();
        }
    }
}
