using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SensorApp
{
    public class Sensor : INotifyPropertyChanged
    {
        private int _measuredValue;
        private Mode _sensorMode;
        public ISensorState SensorState { get; set; }


        public int MeasuredValue
        {
            get
            {
                return this.SensorState.GetMeasuredValue(this);
            }
            set
            {
                _measuredValue = value;
                RaisePropertyChanged(nameof(MeasuredValue));
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

        public Sensor(ISensorState iState)
        {
            SensorState = iState;
        }
        
        public Sensor(SensorConfig config)
        {
            Id = Guid.NewGuid();
            MeasurementInterval = config.MeasurementInterval;
            SensorType = config.SensorType;
            SensorState = new IdleState();
        }

        public void TransitionTo()
        {
            this.SensorState.TransitionToState(this);
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
