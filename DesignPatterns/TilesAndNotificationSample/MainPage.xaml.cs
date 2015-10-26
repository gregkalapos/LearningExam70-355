using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TilesAndNotificationSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.NameAndLogo,

                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Small" }
                }
                        }
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Medium" }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Wide" }
                }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Large" }
                }
                        }
                    }
                }
            };


            var tn = new Windows.UI.Notifications.TileNotification(content.GetXml());

            var updater = Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(tn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToastContent tnc = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText()
                    {
                        Text = "aaaaaaaa"
                    }
                }
            };

            var tn = new Windows.UI.Notifications.ToastNotification(tnc.GetXml());
            var notifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

            notifier.Show(tn);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Second);

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.NameAndLogo,

                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Small" + rnd.Next(30) }
                    
                }
                           
                        }
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Medium" + rnd.Next(30) }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Wide" + rnd.Next(30) }
                }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new TileText() { Text = "Large" + rnd.Next(30) }
                }
                        }
                    }
                }
            };

            var stn = new Windows.UI.Notifications.ScheduledTileNotification(content.GetXml(), new DateTimeOffset(DateTime.Now.AddSeconds(10)));

            var updater =  Windows.UI.Notifications.TileUpdateManager.CreateTileUpdaterForApplication();

            updater.AddToSchedule(stn);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var secTile = new SecondaryTile("myTile")
            {
                DisplayName = "Test Secodary",
                Arguments = "aaaaaaaa",
                ShortName = "TestSecTie"
            };

            secTile.VisualElements.Square150x150Logo = new Uri("ms-appx:///Assets/Square150x150Logo.png"); // @"Assets\Square150x150Logo.scale-200.png");

            await secTile.RequestCreateAsync();

        }
    }
}
