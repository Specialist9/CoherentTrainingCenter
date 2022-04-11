using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class IdleValueGenerator : IValueGenerator
    {
        public int GetMeasuredValue()
        {
            return 0;
        }
    }
}
