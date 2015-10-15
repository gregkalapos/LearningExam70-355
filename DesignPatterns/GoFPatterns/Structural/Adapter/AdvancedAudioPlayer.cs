using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Adapter
{
    class AdvancedAudioPlayer : IAdvancedAudioPlayer
    {
        public void PlayMp4(string FileName)
        {
            Console.WriteLine("AdvancedAudioPlayer plays mp4 " + FileName);
        }
    }
}
