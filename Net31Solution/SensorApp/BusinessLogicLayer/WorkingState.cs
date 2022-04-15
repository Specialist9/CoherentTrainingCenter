using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class WorkingState : ISensorState
    {
        public int currentValue;
        public System.Timers.Timer checkTimer = null;
        public Random Random1 = new Random();

        public WorkingState()
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
            currentValue = Random1.Next();
        }

        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new IdleState();
            sensor.SensorMode = Sensor.Mode.Idle;
        }
    }
}
