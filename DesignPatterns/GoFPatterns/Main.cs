using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoFPatterns.Creational.AbstractFactory;
using GoFPatterns.Creational.Builder;

namespace GoFPatterns
{
    class MainClass
    {
        public static void Main(String[] ars)
        {
            //Abstract Factory
            Console.WriteLine("Abstract Factory Sample");
            Console.WriteLine("First sample: using concrete factory1");
            var client1 = new Client(new ConcreteFactory1());
            client1.PrintMsgs();
            Console.WriteLine("Second sample: using concrete factory2"); 
            var client2 = new Client(new ConcreteFactory2());
            client2.PrintMsgs();

            //Builder
            Console.WriteLine();
            Console.WriteLine("Builder Pattern");
            RedCabrioBulder carBuilder = new RedCabrioBulder();
            CarFactory cf = new CarFactory(carBuilder);
            cf.BuildCar();
            var car = carBuilder.GetResult();
            car.PrintProperties();
        }
    }
}
