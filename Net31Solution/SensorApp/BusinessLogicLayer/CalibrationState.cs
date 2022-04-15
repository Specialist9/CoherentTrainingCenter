using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class CalibrationState : ISensorState
    {
        public int currentValue = 0;
        System.Timers.Timer checkTimer = null;

        public CalibrationState()
        {
            checkTimer = new();
            checkTimer.Interval = 1000;
            checkTimer.Elapsed += ElapsedTimerEventHandler;
            checkTimer.Start();

        }
        public int GetMeasuredValue(Sensor sensor)
        {
            return currentValue;
        }

        void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            currentValue += 1;
        }
        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new WorkingState();
            sensor.SensorMode = Sensor.Mode.Working;
        }
    }
}
