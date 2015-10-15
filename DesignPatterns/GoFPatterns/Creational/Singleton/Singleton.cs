using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Singleton
{
    class Singleton
    {
        private Singleton()
        {
        }

        public int IntProperty { get; set; }

        private static volatile Singleton instance;
        private static object lockObj = new Object();

        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(lockObj)
                    {
                        if(instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }
    }
}
