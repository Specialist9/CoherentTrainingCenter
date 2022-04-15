using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class CalibrationState : ISensorState
    {
        private int _currentValue = 0;
        private System.Timers.Timer _checkTimer = null;

        public CalibrationState()
        {
            _checkTimer = new();
            _checkTimer.Interval = 1000;
            _checkTimer.Elapsed += ElapsedTimerEventHandler;
            _checkTimer.Start();

        }
        public int GetMeasuredValue(Sensor sensor)
        {
            return _currentValue;
        }

        void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            _currentValue += 1;
        }
        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new WorkingState();
            sensor.SensorMode = Sensor.Mode.Working;
        }
    }
}
