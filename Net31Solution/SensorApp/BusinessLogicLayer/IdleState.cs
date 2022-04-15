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
            return 0;
        }

        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new CalibrationState();
            sensor.SensorMode = Sensor.Mode.Calibration;
        }
    }
}
