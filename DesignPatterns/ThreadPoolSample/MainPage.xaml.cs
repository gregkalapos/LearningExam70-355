using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThreadPoolSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        IAsyncAction lastWorkItem;
        ThreadPoolTimer periodicTimer;
        int periodicCounts;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ThreadPoolTimerTextBox.Text = "ThreadPool timer scheduled";

            ThreadPoolTimer.CreateTimer((source) =>
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {

                    ThreadPoolTimerTextBox.Text = "ThreadPool Thread done";
                });

            }, TimeSpan.FromSeconds(5));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(lastWorkItem != null && lastWorkItem.Status == AsyncStatus.Started)
            {
                lastWorkItem.Cancel();
            }

            ulong nOfProme = 9999;
            int result = 0;

            var m_workItem = Windows.System.Threading.ThreadPool.RunAsync((workitem) =>
            {

                ulong primeFound = 0;
                int i = 2;

                while (primeFound < nOfProme - 1)
                {
                    if(workitem.Status == AsyncStatus.Canceled)
                    {
                        break;
                    }

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

                        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
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
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        new DispatchedHandler(() =>
                        {
                            PrimeCalculationTextblock.Text = "The value is: " + result;
                        }));

            });

            lastWorkItem = m_workItem;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (periodicTimer == null)
            {

                button2.Content = "Stop per. Timer";

                periodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
                {

                    periodicCounts++;

                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        PeriodicSampleTextBlock.Text = "Periodic timer runs: " + periodicCounts;
                    });
                }, TimeSpan.FromSeconds(3), (source) =>
                {

                    periodicCounts = 0;

                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        button2.Content = "Start per. Timer";
                        PeriodicSampleTextBlock.Text = "Stopped";
                    });
                });
            }
            else
            {
                periodicTimer.Cancel();
                periodicTimer = null;
            }
        }
    }
}
