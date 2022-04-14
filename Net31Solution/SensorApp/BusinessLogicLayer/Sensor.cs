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
        public ISensorState SensorState { get; set; }

        private int _measuredValue;
        private Mode _sensorMode;

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
            SensorState = new WorkingState();
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
        /*
        public void ChangeSensorState()
        {
            if(SensorState is IdleState)
            {
                SensorState = new CalibrationState();
                SensorMode = Mode.Calibration;
            }
            else if(SensorState is CalibrationState)
            {
                SensorState = new WorkingState();
                SensorMode = Mode.Working;
            }
            else if(SensorState is WorkingState)
            {
                SensorState = new IdleState();
                SensorMode = Mode.Idle;
            }
        }
        */



        public void ChangeSensorMode()
        {
            if (SensorMode == Mode.Calibration)
            {
                SensorMode = Mode.Working;
                //GenerateWorkingValue();

                //MeasuredValue = temp.GetMeasuredValue();
            }

            else if (SensorMode == Mode.Working)
            {
                SensorMode = Mode.Idle;
                //GenerateIdleValue();

            }

            else if(SensorMode == Mode.Idle)
            {
                SensorMode = Mode.Calibration;
                //GenerateCalibrationValue();

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
                    if (SensorMode != Mode.Calibration) break;
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
