using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
//using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebApiClientSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private String comapnyName;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public String CompanyName
        {
            get { return comapnyName; }
            set
            {
                comapnyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value;
                RaisePropertyChanged("Price");
            }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value;
                RaisePropertyChanged("Time");
            }
        }

        private string enteredCompanyName;

        public string EnteredCompanyName
        {
            get { return enteredCompanyName; }
            set
            {
                enteredCompanyName = value;
                RaisePropertyChanged("EnteredCompanyName");
            }
        }



        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {                 
                var resp = await httpClient.GetAsync(new Uri("http://localhost:50007/api/Stocks/" + EnteredCompanyName));

                if(resp.IsSuccessStatusCode)
                {
                    try
                    {
                        var jsonObj = JsonObject.Parse(await resp.Content.ReadAsStringAsync());


                        CompanyName = jsonObj.GetNamedString("CompanyName");
                        Price = jsonObj.GetNamedNumber("Price");
                        Time = DateTime.Parse(jsonObj.GetNamedValue("Time").GetString());
                    }
                    catch
                    {

                    }
                   
                }
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            { 
                JsonObject jo = new JsonObject();
                jo["StockId"] =  JsonValue.CreateNumberValue(2);
                jo["Amount"] = JsonValue.CreateNumberValue(23);

                var content = new HttpStringContent(jo.Stringify());
                content.Headers.ContentType.MediaType = "application/json"; 
                var resp = await httpClient.PostAsync(new Uri("http://localhost:50007/api/Stocks"), content);              
            }
        }
    }
}
