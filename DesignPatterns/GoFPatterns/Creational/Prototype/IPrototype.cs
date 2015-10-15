using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Prototype
{
    public interface IPrototype
    {
        IPrototype Clone();
    }
}
