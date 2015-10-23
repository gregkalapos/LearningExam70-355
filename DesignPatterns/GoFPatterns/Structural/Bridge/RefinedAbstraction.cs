using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Bridge
{
    class RefinedAbstraction : IAbstraction
    {
        private IImplementor implementor;

        public RefinedAbstraction()
        {
            //RefinedAbstraction do not have to know a concrete implementor.. this is here just a sample that you can set that this way,
            //but there are many ways to do this
            implementor = new ConcreateImplementorA();
        }

        public IImplementor Implementor
        {
            get
            {
                return implementor;
            }

            set
            {
                implementor = value;
            }
        }

        public void Operation()
        {
            implementor.OperationImp(42);
        }
    }
}
