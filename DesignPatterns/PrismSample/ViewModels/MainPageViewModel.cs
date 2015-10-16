using Prism.Commands;
using Prism.Events;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace PrismSample.ViewModels
{

    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;
        private IEventAggregator _eventAggr;

        public DelegateCommand  DownloadBtnTouched { get; private set; }

        public MainPageViewModel(IDataRepository dataRepository, INavigationService navService, IEventAggregator eventAggr)
        {
            _dataRepository = dataRepository;

            MainText = "Runtime Text";

            _eventAggr = eventAggr;

            //NavigateCommand = new DelegateCommand(() => navService.Navigate("UserInput", null));

            DownloadBtnTouched = new DelegateCommand(async() =>
            {
                Windows.Web.Syndication.SyndicationClient client = new SyndicationClient();

                try
                {
                    var txt = await MyTestAsyncClass.MyMethodAsync();
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

                // Force the SyndicationClient to download the information.
                client.BypassCacheOnRetrieve = true;

                Uri feedUri
                    = new Uri("http://blogs.windows.com/feed/"); //"http://windowsteamblog.com/windows/b/windowsexperience/atom.aspx");

                try
                {
                    // Call SyndicationClient RetrieveFeedAsync to download the list of blog posts.
                    SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);

                    // The rest of this method executes after await RetrieveFeedAsync completes.
                    var Text = feed.Title.Text + Environment.NewLine;

                    foreach (SyndicationItem item in feed.Items)
                    {
                         Text += item.Title.Text + ", " +
                                         item.PublishedDate.ToString() + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {
                    // Log Error.
                    //rssOutput.Text =
                    //    "I'm sorry, but I couldn't load the page," +
                    //    " possibly due to network problems." +
                    //    "Here's the error message I received: "
                    //    + ex.ToString();
                }
            });
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


    public class MyTestAsyncClass
    {
        public static async Task<string> MyMethodAsync()
        {
            await Task.Delay(400);

            throw new Exception("test");
            return "sdgd";
        }
    }
}
