using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SensorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

            this.myGrid.ItemsSource = SensorsFactory.CreateSensors();

            int i = 756;
        }

        private void ChangeSensorMode(object sender, RoutedEventArgs e)
        {
            var sensor = (e.Source as Button).DataContext as Sensor;
            
            sensor.ChangeSensorMode();
        }

        private void DeleteSensor(object sender, RoutedEventArgs e)
        {
            var sensor = (e.Source as Button).DataContext as Sensor;

            SensorsFactory.RemoveSensor(sensor);
        }

        private void LoadXmlConfigFile(object sender, RoutedEventArgs e)
        {
            ConfigReader.BuildXmlConfig();
        }

        private void LoadJsonConfigFile(object sender, RoutedEventArgs e)
        {
            ConfigReader.BuildJsonConfig();
        }

        private void AddPressureSensor_Click(object sender, RoutedEventArgs e)
        {
            SensorsFactory.AddSensor(ConfigReader.PConfig);
        }

        private void AddTemperatureSensor_Click(object sender, RoutedEventArgs e)
        {
            SensorsFactory.AddSensor(ConfigReader.TConfig);
        }

        private void AddMagneticSensor_Click(object sender, RoutedEventArgs e)
        {
            SensorsFactory.AddSensor(ConfigReader.MConfig);
        }
    }
}
