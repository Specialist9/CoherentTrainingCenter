using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SensorApp
{
    internal class CalibrationValueGenerator : IValueGenerator
    {
        private static int orderNumber = 0;

        public int GetMeasuredValue()
        {
            return Interlocked.Increment(ref orderNumber);
        }

    }
}
