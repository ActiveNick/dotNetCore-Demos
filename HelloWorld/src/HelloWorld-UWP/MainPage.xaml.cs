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
using OpenWeatherMap;
using Windows.UI.Core;

namespace HelloWorld_UWP
{
    /// <summary>
    /// This is a simple UWP project that demonstrates how a PCL created as a .NET Standard 1.4 library
    /// can be called from both a .NET Core console app and a UWP app to facilitate shared code.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text.Trim();

            if (location.Length == 0)
            {
                var dlg = new Windows.UI.Popups.MessageDialog("Make sure you provide a city name and state before asking for a weather report.");
                await dlg.ShowAsync();
            }

            // Instantiate the OpenWeatherMap service object
            OpenWeatherMapService owms = new OpenWeatherMapService();

            WeatherRoot wr = await owms.GetWeather(location);

            if (wr != null)
            {
                // Run this with Dispatcher since we need access to the main UI thread
                var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    // Prepare a weather message
                    string weatherText = $"The current temperature in {wr.Name} is {(int)wr.MainWeather.Temp}°F, with a high today of {(int)wr.MainWeather.MaximumTemp}° and a low of {(int)wr.MainWeather.MinimumTemp}°.";
                    lblResult.Text = weatherText;
                });
            }
            else
            {
                lblResult.Text = "Oops! Somewthing went wrong when retrieving the weather for your location.";
            }
        }
    }
}
