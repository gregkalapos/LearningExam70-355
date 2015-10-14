using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.AbstractFactory
{
    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA ProductA
        {
            get
            {
                return new ProductA1();
            }       
        }

        public IAbstractProductB ProductB
        {
            get
            {
                return new ProductB1();
            }
        }
    }
}
