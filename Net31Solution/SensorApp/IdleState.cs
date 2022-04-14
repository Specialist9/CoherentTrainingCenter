using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class IdleState : ISensorState
    {
        public int GetMeasuredValue(Sensor sensor)
        {
            return 7;
        }

        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new CalibrationState();
        }
    }
}
