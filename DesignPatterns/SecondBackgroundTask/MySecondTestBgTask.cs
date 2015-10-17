using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace SecondBackgroundTask
{
    public sealed class MySecondTestBgTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            taskInstance.Progress = 0;

            var rnd = new Random(DateTime.Now.Second);

            var rndNumer = rnd.Next(20);

            Windows.Storage.ApplicationData.Current.LocalSettings.Values["rndNumber"] = rndNumer;


            for (uint i =1; i < 100; i++)
            {
              
                taskInstance.Progress = i;
            }
          

            taskInstance.GetDeferral().Complete();

        }
    }
}
