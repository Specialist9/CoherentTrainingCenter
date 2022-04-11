using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public interface IValueGenerator
    {
        public int GetMeasuredValue();
    }
}
