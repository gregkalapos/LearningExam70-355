using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace GoFPatterns.Creational.AbstractFactory
{
    public interface IAbstractFactory
    {
        IAbstractProductA ProductA
        {
            get;
        }

        IAbstractProductB ProductB
        {
            get;
        }
    }
}
