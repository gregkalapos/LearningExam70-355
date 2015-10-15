using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Prototype
{
    class Door: IPrototype
    {
        public bool IsOpen { get; set; }
        public int Height { get; set; }

        public Door()
        {
            IsOpen = false;
            Height = 190;
        }

        public IPrototype Clone()
        {
            var ret = new Door();
            ret.IsOpen = this.IsOpen;
            ret.Height = this.Height;

            return ret;
        }

        public void PrintProperties()
        {
            Console.WriteLine(string.Format("IsOpen: {0}", IsOpen));
            Console.WriteLine(string.Format("Height: {0}", Height));
        }
    }
}
