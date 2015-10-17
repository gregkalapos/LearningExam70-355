using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
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

namespace BackgroundTaskConsumer
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }


            RegisterBackgroundTask();
            // Ensure the current window is active
            Window.Current.Activate();
        }

        private void RegisterBackgroundTask()
        {
            bool isRegistered = false;

            var backgroundTaskName = "MySecondTestBgTask13";

            foreach (var bgTask in BackgroundTaskRegistration.AllTasks)
            {

                if (bgTask.Value.Name == backgroundTaskName)
                {
                    isRegistered = true;
                }
            }


            if (!isRegistered)
            {
                var builder = new BackgroundTaskBuilder();
                builder.Name = backgroundTaskName;
                builder.TaskEntryPoint = "SecondBackgroundTask.MySecondTestBgTask";
                builder.SetTrigger(new SystemTrigger(SystemTriggerType.InternetAvailable, true));

                //builder.SetTrigger(new TimeTrigger(15, false));

                BackgroundTaskRegistration bgregistration = builder.Register();
                bgregistration.Progress += Bgregistration_Progress;
                bgregistration.Completed += Bgregistration_Completed1; ;

            }
        }

        private void Bgregistration_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {
            //args.Progress 
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                System.Diagnostics.Debug.WriteLine("Progress: " + args.Progress);
            });
        }

        private void Bgregistration_Completed1(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {

            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => {
                var rndNumber = Windows.Storage.ApplicationData.Current.LocalSettings.Values["rndNumber"];

                var msgDialog = new Windows.UI.Popups.MessageDialog("Rundom number from the background task: " + rndNumber.ToString());
                await msgDialog.ShowAsync();
            });


            // int a = 3;
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
