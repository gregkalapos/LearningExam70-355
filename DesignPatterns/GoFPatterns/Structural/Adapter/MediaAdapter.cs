using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Adapter
{
    class MediaAdapter : IMediaPlayer
    {
        IAdvancedAudioPlayer advancedAudioPlayer = new AdvancedAudioPlayer();

        public void Play(string FileFormat, string FileName)
        {
            if(FileFormat == "mp4")
            {
                advancedAudioPlayer.PlayMp4(FileName);
            }
        }
    }
}
