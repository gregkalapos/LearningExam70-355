using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.AbstractFactory
{
    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA ProductA
        {
            get
            {
                return new ProductA2();
            }
        }

        public IAbstractProductB ProductB
        {
            get
            {
                return new ProductB2();
            }
        }
    }
}
