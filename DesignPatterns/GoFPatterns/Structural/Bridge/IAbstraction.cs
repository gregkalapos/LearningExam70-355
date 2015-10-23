using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Bridge
{
    public interface IAbstraction
    {
        IImplementor Implementor { get; set; }
        void Operation();
    }
}
