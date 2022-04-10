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
        private int _measuredValue;
        private Mode _sensorMode;
        private string _name;

        public int MeasuredValue
        {
            get
            {
                return _measuredValue;
            }
            set
            {
                _measuredValue = value;
                RaisePropertyChanged(nameof(MeasuredValue));
            }
        }

        
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
        public Mode SensorMode
        {
            get
            {
                return _sensorMode;
            }
            set
            {
                _sensorMode = value;
                RaisePropertyChanged(nameof(SensorMode));
            }
        }

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

        public void ChangeSensorMode()
        {
            if (SensorMode == Mode.Calibration) SensorMode = Mode.Working;
            else if (SensorMode == Mode.Working) SensorMode = Mode.Idle;
            else if(SensorMode == Mode.Idle) SensorMode = Mode.Calibration;
        }

    }
}
