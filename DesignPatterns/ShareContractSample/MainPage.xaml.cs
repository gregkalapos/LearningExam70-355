using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShareContractSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }

        private void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.SetText("The teeext");
          
            args.Request.Data.Properties.Title = "My new title";
            args.Request.Data.Properties.Description = "description";

            //args.Request.FailWithDisplayText("failed");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "eb819cd2-07bc-4048-9cf7-c438f2b6f290_vx85t7qpa6fm0";

            var launcherUri = new Uri("mytestprotocol:");

            var res = await Launcher.LaunchUriForResultsAsync(launcherUri, options);
                        
            var msgDialog = new MessageDialog("result: " + res.Result["Result"].ToString());
            await msgDialog.ShowAsync();

        }
    }
}
