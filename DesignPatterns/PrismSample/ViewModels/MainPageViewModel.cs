using Prism.Events;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSample.ViewModels
{

    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;
        private IEventAggregator _eventAggr;

        public MainPageViewModel(IDataRepository dataRepository, INavigationService navService, IEventAggregator eventAggr)
        {
            _dataRepository = dataRepository;

            MainText = "Runtime Text";

            _eventAggr = eventAggr;

            //NavigateCommand = new DelegateCommand(() => navService.Navigate("UserInput", null));
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            MainText = e.Parameter.ToString();
            
            _eventAggr.GetEvent<Messages.LogoutMsg>().Subscribe(async  (string msg) => 
            {
                var msgDialog = new Windows.UI.Popups.MessageDialog(msg);
                await msgDialog.ShowAsync();

            });
        }

        [RestorableState]
        public string MainText { get; set; }
    }
}
