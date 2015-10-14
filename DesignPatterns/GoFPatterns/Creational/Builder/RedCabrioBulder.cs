using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Builder
{
    class RedCabrioBulder : ICarBuilder
    {
        private Car result;

        public RedCabrioBulder()
        {
            result = new Car();
        }

        public void SetCcm()
        {
            result.CcM = 2300;
        }

        public void SetColor()
        {
            result.Color = "Red";
        }

        public void SetSeats()
        {
            result.Seats = 2;
        }

        public Car GetResult()
        {
            return result;
        }
    }
}
