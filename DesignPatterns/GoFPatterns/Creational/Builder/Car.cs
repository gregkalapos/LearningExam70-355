using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Builder
{
    class Car
    {
        public int Seats { get; set; }
        public int CcM { get; set; }

        public string Color { get; set; }

        public void PrintProperties()
        {
            Console.WriteLine(String.Format("Seats: {0}", Seats));
            Console.WriteLine(String.Format("ccm: {0}", CcM));
            Console.WriteLine(String.Format("Color: {0}", Color));
        }
    }
}
