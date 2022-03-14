using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET012.Task
{
    /// <summary>
    /// Class that stores the event data for the event of changing a matrix element value
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class MatrixElementChangedEventArgs<T> : EventArgs
    {
        public readonly T OldValue;
        public readonly T NewValue;
        public readonly int ElementIndexI;
        public readonly int ElementIndexJ;


        public MatrixElementChangedEventArgs(T oldValue, T newValue, int elementIndexI, int elementIndexJ)
        {
            OldValue = oldValue;
            NewValue = newValue;
            ElementIndexI = elementIndexI;
            ElementIndexJ = elementIndexJ;
        }
    }

}
