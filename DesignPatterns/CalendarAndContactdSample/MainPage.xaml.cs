using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CalendarAndContactdSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<String> contacts;
        public ObservableCollection<String> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }


        public MainPage()
        {
            Contacts = new ObservableCollection<string>();
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var ctPicker = new Windows.ApplicationModel.Contacts.ContactPicker();

            ctPicker.CommitButtonText = "Selectttt";
            ctPicker.SelectionMode = Windows.ApplicationModel.Contacts.ContactSelectionMode.Fields;

            var contact = await ctPicker.PickContactAsync();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();
            appointment.StartTime = new DateTimeOffset(DateTime.Now);

            appointment.Subject = "test";
            appointment.Location = "testlocation";
                   
            var rect = GetElementRect(sender as FrameworkElement);
            var appointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(appointment, rect);
        }

        private Rect GetElementRect(FrameworkElement frameworkElement)
        {
            return frameworkElement.RenderTransform.TransformBounds(new Rect(0, 0, frameworkElement.Width, frameworkElement.Height));        
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            var store = await Windows.ApplicationModel.Contacts.ContactManager.RequestStoreAsync(Windows.ApplicationModel.Contacts.ContactStoreAccessType.AllContactsReadOnly);

            if(store != null )
            {
                var contactReader =  store.GetContactReader();
                var contactBatch = await contactReader.ReadBatchAsync();


                if(contactBatch.Contacts.Count > 0 && contactBatch.Status == Windows.ApplicationModel.Contacts.ContactBatchStatus.Success)
                {
                    foreach (var item in contactBatch.Contacts)
                    {
                        Contacts.Add(item.Name);
                    }
                }
                
            }
        }
    }
}
