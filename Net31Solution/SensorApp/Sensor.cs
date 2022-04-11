using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SensorApp
{
    internal class Sensor : INotifyPropertyChanged
    {
        private int _measuredValue;
        private Mode _sensorMode;

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
            if (SensorMode == Mode.Calibration)
            {
                SensorMode = Mode.Working;
                GenerateWorkingValue();
            }

            else if (SensorMode == Mode.Working)
            {
                SensorMode = Mode.Idle;
                GenerateIdleValue();
            }

            else if(SensorMode == Mode.Idle)
            {
                SensorMode = Mode.Calibration;
                GenerateCalibrationValue();
            }
        }

        public void GenerateIdleValue()
        {
            MeasuredValue = 0;
        }

        public async Task GenerateCalibrationValue()
        {
            while (SensorMode == Mode.Calibration)
            {
                for(int i = 0; i < 100; i++)
                {
                    MeasuredValue = i;
                    await Task.Delay(1000);
                }
            }
        }

        public async Task GenerateWorkingValue()
        {
            while(SensorMode == Mode.Working)
            {
                Random random = new Random();
                MeasuredValue = random.Next();
                await Task.Delay(MeasurementInterval);
            }
        }

    }
}
