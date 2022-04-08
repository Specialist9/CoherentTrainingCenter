using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SensorApp
{
    internal class Sensor : INotifyPropertyChanged
    {
        public int MeasuredValue { get; }

        private string _name;
        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        
        public Guid Id { get; set; }
        public int MeasurementInterval { get; set; }
        public string SensorType { get; set; }
        public Mode SensorMode { get; set; }

        public enum Mode
        {
            Idle,
            Calibration,
            Working
        }
        

        public Sensor(string name, int value)
        {
            MeasuredValue = value;
            Name = name;
        }

        public Sensor(ISensorConfig config)
        {
            Id = Guid.NewGuid();
            MeasuredValue = config.MeasuredValue;
            MeasurementInterval = config.MeasurementInterval;
            SensorType = config.SensorType;
            SensorMode = (Mode)config.SensorMode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
