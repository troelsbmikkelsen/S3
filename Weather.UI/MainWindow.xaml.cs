using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Weather.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        private async void btnGetData_Click(object sender, RoutedEventArgs e) {
            Services.Client client = new Services.Client();
            Entities.WeatherData wd = await client.CallWeatherApi(textBoxCityName.Text);

            labelCityValue.Content = wd.City;
            labelTempValue.Content = $"{Math.Round(double.Parse(wd.Temperature, CultureInfo.InvariantCulture))} {Entities.Constants.DegreesC}";
        }
    }
}
