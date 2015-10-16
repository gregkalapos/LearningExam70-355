using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSample.DesignTime
{
    public class MainPageDtViewModel: ViewModelBase
    {
        public string MainText { get; set; }

        public MainPageDtViewModel()
        {
            MainText = "Design Time Text";
        }
    }
}
