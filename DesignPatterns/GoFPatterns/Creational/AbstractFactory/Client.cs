using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.AbstractFactory
{
    class Client
    {
        private IAbstractProductA prodA;
        private IAbstractProductB prodB;

        public Client(IAbstractFactory factory)
        {
            prodA = factory.ProductA;
            prodB = factory.ProductB;
        }

        public void PrintMsgs()
        {
            prodA.PrintMessage();
            prodB.PrintSomeMsg();
        }
    }
}
