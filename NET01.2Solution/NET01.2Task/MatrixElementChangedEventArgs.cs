using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2Task
{
    public class MatrixElementChangedEventArgs<T> : EventArgs
    {
        public T OldValue;
        public T NewValue;
        public int ElementIndexI;
        public int ElementIndexJ;


        public MatrixElementChangedEventArgs(T oldValue, T newValue, int elementIndexI, int elementIndexJ)
        {
            OldValue = oldValue;
            NewValue = newValue;
            ElementIndexI = elementIndexI;
            ElementIndexJ = elementIndexJ;
        }
    }

}
