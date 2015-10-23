using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Bridge
{
    class ConcreateImplementorA : IImplementor
    {
        public void OperationImp(int a)
        {
            Console.WriteLine(string.Format("ConcreateImplementorA: {0}", a));
        }
    }
}
