using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class WorkingState : ISensorState
    {
        public int StartValue;
        public Random Random1 = new Random();

        public WorkingState()
        {
            GenerateWorkingValue();
        }
        public int GetMeasuredValue(Sensor sensor)
        {
            return StartValue;
            //return 27;
        }

        public async Task GenerateWorkingValue()
        {
            while (true)
            {
                Random random = new Random();
                StartValue = random.Next();
                await Task.Delay(1000);
            }
        }
        public void TransitionToState(Sensor sensor)
        {
            sensor.SensorState = new IdleState();
        }
    }
}
