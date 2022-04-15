using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class WorkingState : ISensorState
    {
        private int _currentValue;
        private System.Timers.Timer _checkTimer = null;
        private Random _random = null;

        public WorkingState()
        {
            _random = new();

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
            _currentValue = _random.Next();
        }

        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new IdleState();
            sensor.SensorMode = Sensor.Mode.Idle;
        }
    }
}
