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
        bool isForFileSharing = false;

        public MainPage()
        {
            this.InitializeComponent();

            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
            
        }

        private async void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (!isForFileSharing)
            {

                args.Request.Data.SetText("The teeext");
                
                args.Request.Data.Properties.Title = "My new title";
                args.Request.Data.Properties.Description = "description";
            }
            else
            {
                //todo: make filesharing
                args.Request.Data.Properties.Title = "Sharing a file";
                args.Request.Data.Properties.Description = "description";

                //  ->  \test.sharetest

                var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\test.sharetest");
                args.Request.Data.SetStorageItems(new List<Windows.Storage.IStorageItem>{ file });


                isForFileSharing = false;
            }


            //args.Request.FailWithDisplayText("failed");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //uses the  Share contract
            DataTransferManager.ShowShareUI();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            //Launches the target app with protocol activation and returns a result
            var options = new LauncherOptions();
            options.TargetApplicationPackageFamilyName = "eb819cd2-07bc-4048-9cf7-c438f2b6f290_vx85t7qpa6fm0";

            var launcherUri = new Uri("mytestprotocol:");

            var res = await Launcher.LaunchUriForResultsAsync(launcherUri, options);
                        
            var msgDialog = new MessageDialog("result: " + res.Result["Result"].ToString());
            await msgDialog.ShowAsync();

        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            //It opens this app in the sample reciever
            string fileLocation = @"Assets\LockScreenLogo.scale-200.png";

            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileLocation);

            if (file != null)
            {
                var result = await Launcher.LaunchFileAsync(file);
            }
        }

        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            //The ShareContractSampleReciever is registered for this!
            //For this you need a file type assosiation in the reciever app
            string fileFolaction = @"Assets\test.ddd";

            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileFolaction);

            if(file != null)
            {
                var res = await  Launcher.LaunchFileAsync(file);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            isForFileSharing = true;
            DataTransferManager.ShowShareUI();
        }
    }
}
