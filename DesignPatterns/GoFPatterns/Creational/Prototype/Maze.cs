using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Prototype
{
    class Maze : IPrototype
    {
        public string Name { get; set; }

        public IPrototype Clone()
        {
            var retVal = new Maze();
            retVal.Name = this.Name;

            return retVal;
        }

        public void PrintPtopeties()
        {
            Console.WriteLine(String.Format("Name: {0}", Name));
        }
    }
}
