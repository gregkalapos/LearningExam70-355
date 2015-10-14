using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.AbstractFactory
{
    public interface IAbstractProductB
    {
        void PrintSomeMsg();
    }

    class ProductB1 : IAbstractProductB
    {
        public void PrintSomeMsg()
        {
            Console.WriteLine("This is product type1 from B");
        }
    }

    class ProductB2 : IAbstractProductB
    {
        public void PrintSomeMsg()
        {
            Console.WriteLine("This is product type2 from B");
        }
    }
}
