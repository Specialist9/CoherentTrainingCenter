using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET011.Task
{
    public interface IVersionable
    {
        string ReadVersion();
        
        void WriteVersion(ulong version);
    }
}
