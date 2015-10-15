using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.FactoryMethod
{
    class ConcreteProduct : IProduct
    {
        public void PrintThings()
        {
            Console.WriteLine("ConcreteProduct");
        }
    }
}
