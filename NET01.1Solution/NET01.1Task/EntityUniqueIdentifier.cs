using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET011.Task
{
    static class EntityUniqueIdentifier
    {
        public static void CreateUniqueEntityID(this Entity obj)
        {
            obj.ID = Guid.NewGuid();
        }
    }
}
