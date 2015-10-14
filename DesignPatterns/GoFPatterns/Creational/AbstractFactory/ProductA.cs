using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.AbstractFactory
{
    public interface IAbstractProductA
    {
         void PrintMessage();
    }

    public class ProductA1 : IAbstractProductA
    {
        public void PrintMessage()
        {
            Console.WriteLine("This is product type1 from A");
        }
    }

    public class ProductA2 : IAbstractProductA
    {
        public void PrintMessage()
        {
            Console.WriteLine("This is Product type2 from A");
        }
    }
}
