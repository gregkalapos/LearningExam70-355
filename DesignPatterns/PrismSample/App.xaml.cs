using Prism.Events;
using Prism.Mvvm;
using Prism.Windows;
using PrismSample.ViewModels;
using PrismSample.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace PrismSample
{
    public interface IDataRepository
    {
        List<string> GetFeatures();
        string GetUserEnteredData();
        void SetUserEnteredData(string data);
    }


    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismApplication
    {

        IDataRepository _dataRepository;
        IEventAggregator eventaggr;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            //    this.Suspending += OnSuspending;
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
          
            NavigationService.Navigate("Login", null);

            //eventaggr.GetEvent<Messages.LogoutMsg>().Publish("aaaaaaaaaa");
            return Task.FromResult<object>(null);
        }


        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // New up the singleton data repository, and pass it the state service it depends on from the base class
            //   _dataRepository = new DataRepository(SessionStateService);

            // Register factory methods for the ViewModelLocator for each view model that takes dependencies so that you can pass in the
            // dependent services from the factory method here.

            eventaggr = new EventAggregator();

            ViewModelLocationProvider.Register(typeof(MainPage).ToString(), () => new MainPageViewModel(null, NavigationService, eventaggr));
            ViewModelLocationProvider.Register(typeof(LoginPage).ToString(), () => new LoginPageViewModel(NavigationService));

            return base.OnInitializeAsync(args);
        }
    }
}
