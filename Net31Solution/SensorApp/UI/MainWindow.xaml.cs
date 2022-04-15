﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;
using System.Linq;
using System.IO;
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


        }

        private void DeleteSensor(object sender, RoutedEventArgs e)
        {
            var sensor = (e.Source as Button).DataContext as Sensor;

            SensorsCollection.RemoveSensor(sensor);
        }

        private void LoadXmlConfigFile(object sender, RoutedEventArgs e)
        {
            ConfigReader.BuildXmlConfig();
            this.myGrid.ItemsSource = SensorsCollection.CreateSensors();
        }

        private void LoadJsonConfigFile(object sender, RoutedEventArgs e)
        {
            ConfigReader.BuildJsonConfig();
            this.myGrid.ItemsSource = SensorsCollection.CreateSensors();
        }

        private void TransitionSensorState(object sender, RoutedEventArgs e)
        {
            var sensor = (e.Source as Button).DataContext as Sensor;
            sensor.TransitionTo();
        }
    }
}
