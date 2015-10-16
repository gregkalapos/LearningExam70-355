using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PrismSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // if (animatedGrid.Opacity == 0)
            ShowStoryboard.Begin();
            //   else
            // HideStoryboard.Begin();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ulong nOfProme = 9999;
            int result = 0;

            var m_workItem = Windows.System.Threading.ThreadPool.RunAsync((workitem) =>
             {

                 ulong primeFound = 0;
                 int i = 2;
                
                 while (primeFound < nOfProme-1)
                 {
                     bool prime = true;

                     i++;

                     for (int j = 2; j < i; ++j)
                     {
                         if (i % j == 0)
                         {
                             prime = false;
                             break;
                         }
                     }

                     if (prime)
                     {
                         primeFound++;
                     
                         Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                         new DispatchedHandler(() =>
                         {
                             PrimeCalculationTextblock.Text = "Primes found: " + primeFound;
                         }));

                         result = i;
                     }
                 }

                
             });

            m_workItem.Completed = new AsyncActionCompletedHandler((workItem, status) =>
            {
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                        new DispatchedHandler(() =>
                        {
                            PrimeCalculationTextblock.Text = "The value is: " + result;
                        }));

            });
        }
    }
}
