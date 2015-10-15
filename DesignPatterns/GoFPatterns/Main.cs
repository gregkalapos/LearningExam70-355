using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoFPatterns.Creational.AbstractFactory;
using GoFPatterns.Creational.Builder;
using GoFPatterns.Creational.FactoryMethod;
using GoFPatterns.Creational.Prototype;
using GoFPatterns.Creational.Singleton;

using GoFPatterns.Structural.Adapter;

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

            //Factory method
            Console.WriteLine();
            Console.WriteLine("Factory method pattern");
            var factory = new ConcreteFactory();
            factory.DoSomeThing();

            //Prototype 
            Console.WriteLine();
            Console.WriteLine("Prototype pattern");
            var prototypeFactory = new MazePrototypeFactory(new Maze { Name = "TestMaze" }, new Door());
            prototypeFactory.MakeMaze().PrintPtopeties();
            prototypeFactory.MakeDoor().PrintProperties();

            //Singleton 
            Console.WriteLine();
            Console.WriteLine("Singleton pattern");
            var instance = Singleton.Instance;
            Console.WriteLine("Instance intvalue: " + instance.IntProperty);
            Singleton.Instance.IntProperty = 33;
            Console.WriteLine("Instance intvalue: " + instance.IntProperty);

            //Singleton 
            Console.WriteLine();
            Console.WriteLine("Adapter pattern");
            AudioPlayer ap = new AudioPlayer();
            ap.Play("mp3", "aaa");
            ap.Play("mp4", "bb");
        }
    }
}
