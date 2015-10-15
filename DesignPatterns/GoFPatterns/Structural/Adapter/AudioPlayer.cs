using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Adapter
{
    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mAdapter = new MediaAdapter();

        public void Play(string FileFormat, string FileName)
        {
            if(FileFormat == "mp4")
            {
                mAdapter.Play(FileFormat, FileName);
            }
            else
            {
                Console.WriteLine("playing mp3");
            }
        }
    }
}
