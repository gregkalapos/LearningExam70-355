using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Builder
{
    public interface ICarBuilder
    {
        void SetSeats();
        void SetColor();
        void SetCcm();

    }
}
