using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    internal class WorkingValueGenerator : IValueGenerator
    {
        public int GetMeasuredValue()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}
