using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Structural.Adapter
{
    public interface IMediaPlayer
    {
        void Play(String FileFormat, String FileName);
    }
}
