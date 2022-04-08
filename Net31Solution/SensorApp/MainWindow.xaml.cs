using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;
using System.Linq;
using System.Text;
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
            this.myGrid.ItemsSource = SensorsFactory.CreateSensors(3);
            
            ConfigReader reader = new ConfigReader();
            //reader.BuildXmlConfig();
            reader.BuildJsonConfig();
            Sensor pSensor = new(reader.PConfig);
            Sensor tSensor = new(reader.TConfig);
            Sensor mSensor = new(reader.MConfig);



            int i = 756;
        }

        private void ChangeSensorName(object sender, RoutedEventArgs e)
        {
            var sensor = (e.Source as Button).DataContext as Sensor;
            sensor.Name = Guid.NewGuid().ToString();
        }
    }
}
