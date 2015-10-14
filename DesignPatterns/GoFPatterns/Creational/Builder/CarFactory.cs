using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Builder
{
    class CarFactory
    {
        private ICarBuilder carBuilder;

        public CarFactory(ICarBuilder CarBuilder)
        {
            carBuilder = CarBuilder;
        }

        public void BuildCar()
        {
            carBuilder.SetColor();
            carBuilder.SetSeats();
            carBuilder.SetCcm();
        }
    }
}
