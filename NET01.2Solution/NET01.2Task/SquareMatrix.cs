using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2Task
{
    internal class SquareMatrix<T>
    {
        public int Size { get; set; }
        public T[] Values { get; set; }

        public SquareMatrix(int size)
        {
            Size = size >= 0 ? size : throw new ArgumentOutOfRangeException(nameof(size), "Matrix size cannot be negative");
            Values = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                int index;
                
                if(i < 0 || i >= Values.Length || j < 0 || j >= Values.Length)
                {
                    throw new ArgumentOutOfRangeException("Invalid matrix element index");
                }
                else
                {
                     index = i * Size + j;
                }

                return Values[index];
            }

            set
            {
                int index;

                if (i < 0 || i >= Values.Length || j < 0 || j >= Values.Length)
                {
                    throw new ArgumentOutOfRangeException("Invalid matrix element index");
                }
                else
                {
                    index = i * Size + j;
                }

                Values[index] = value;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var cell in Values)
            {
                sb.Append(cell.ToString());
            }
            return sb.ToString();
        }
    }
}
