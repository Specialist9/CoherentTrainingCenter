using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public interface ISensorState
    {
        public void TransitionToState(Sensor sensor);
        public int GetMeasuredValue(Sensor sensor);
    }
}
