using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public interface IListener
    {
        public void WriteToLogFile(string message);

        public int MinLogLevel { get; }
    }
}
