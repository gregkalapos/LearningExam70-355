using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppLifecycleSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Application.Current.Suspending += Current_Suspending;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var oldStrValue = e.Parameter as string;

            if(oldStrValue != null && oldStrValue != string.Empty)
            {
                textBlock.Text = oldStrValue;
            }
            base.OnNavigatedTo(e);
        }

        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            var d = e.SuspendingOperation.GetDeferral();
            ExtendedSuspensionMethid(d);
        }

        public async void ExtendedSuspensionMethid(Windows.ApplicationModel.SuspendingDeferral d)
        {
            await System.Threading.Tasks.Task.Delay(11000);
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["TxtValue"] = textBlock.Text;
            d.Complete();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = textBox.Text;
        }
    }
}
