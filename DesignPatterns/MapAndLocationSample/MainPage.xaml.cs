using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MapAndLocationSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MapService.ServiceToken = "whSZ4ApBI46BjjjUeHM2~1yr85LgWFJd3eOHnPrL0TA~AuXDFor-Sf5SXTbw1-is7vVZqdwq-d8_MumMbQSzc0uGLfMBF-jkFf5oprDzI30e";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BasicGeoposition cityPosition = new BasicGeoposition { Latitude = 47.604, Longitude = -122.329 };
            Geopoint city = new Geopoint(cityPosition);

            MapControl1.Center = city;
            MapControl1.ZoomLevel = 12;

           // MapControl1.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial3D;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var access = await Geolocator.RequestAccessAsync();

            switch (access)
            {
                case GeolocationAccessStatus.Unspecified:
                    break;
                case GeolocationAccessStatus.Allowed:

                    Geolocator geolocator = new Geolocator();
                    var position =  await geolocator.GetGeopositionAsync();
                    MapControl1.Center = position.Coordinate.Point;

                    break;
                case GeolocationAccessStatus.Denied:
                    break;
                default:
                    break;
            }

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(MapControl1.IsStreetsideSupported)
            {

                StreetsidePanorama ssp = await StreetsidePanorama.FindNearbyAsync(new Geopoint(new BasicGeoposition { Latitude = 47.604, Longitude = -122.329 }));

                if(ssp != null)
                {
                    MapControl1.CustomExperience = new StreetsideExperience(ssp);
                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(MapControl1.Is3DSupported)
            {
                MapControl1.Style = MapStyle.Aerial3DWithRoads;
                MapScene mapScene = MapScene.CreateFromLocationAndRadius(new Geopoint(new BasicGeoposition { Latitude = 47.604, Longitude = -122.329 }), 80, 0, 60);
                MapControl1.TrySetSceneAsync(mapScene);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MapIcon mapIcon = new MapIcon();

            mapIcon.Location = new Geopoint(new BasicGeoposition { Latitude = 47.604, Longitude = -122.329 });
            mapIcon.Title = "My Seattle point";

            MapControl1.MapElements.Add(mapIcon);
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Start at Microsoft in Redmond, Washington.
            BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 47.643, Longitude = -122.131 };

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };

            MapRouteFinderResult result = await MapRouteFinder.GetDrivingRouteAsync(new Geopoint(startLocation), new Geopoint(endLocation));

            if(result.Status == MapRouteFinderStatus.Success)
            {

                MapRouteView mapRouteVIew = new MapRouteView(result.Route);
                mapRouteVIew.RouteColor = Colors.Red;


                MapControl1.Routes.Add(mapRouteVIew);

                StringBuilder sb = new StringBuilder();

                foreach (var legs in result.Route.Legs)
                {
                    foreach (var m in legs.Maneuvers)
                    {
                        sb.AppendLine(m.InstructionText);
                    }
                }

                var msgDialog = new MessageDialog(sb.ToString());
                await msgDialog.ShowAsync();
            }
        }
    }
}
