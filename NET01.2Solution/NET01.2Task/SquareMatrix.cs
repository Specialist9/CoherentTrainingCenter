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
        public T[] MatrixValues { get; set; }


        public SquareMatrix(int size)
        {
            Size = size >= 0 ? size : throw new ArgumentOutOfRangeException(nameof(size), "Matrix size cannot be negative");
            MatrixValues = new T[size*size];
        }

        public T this[int i, int j]
        {
            get
            {
                int index;
                
                if(i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Reading matrix element with invalid index");
                }
                else
                {
                     index = i * Size + j;
                }

                return MatrixValues[index];
            }

            set
            {
                int index;

                if (i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Setting matrix element with invalid index");
                }
                else
                {
                    index = i * Size + j;
                    if (MatrixValues[index] != null && MatrixValues[index].Equals(value)) return;
                    T oldValue = MatrixValues[index];
                    MatrixValues[index] = value;
                    OnMatrixElementChanged(new MatrixElementChangedEventArgs<T>(oldValue, value, i, j));
                }

            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var cell in MatrixValues)
            {
                sb.Append($"{cell}, ");
            }
            return sb.ToString();
        }

        public event EventHandler<MatrixElementChangedEventArgs<T>> MatrixElementChanged; // event


        protected virtual void OnMatrixElementChanged(MatrixElementChangedEventArgs<T> e) //broadcaster
        {
            MatrixElementChanged?.Invoke(this, e); //invoke event MatrixElementChangedEventArgs
        }

        public void WriteMatrixElementChangeDetails(object sender, MatrixElementChangedEventArgs<T> e) //method to subscribe to the event in main program
        {
            if(MatrixElementChanged != null)
            {
                Console.WriteLine($"Matrix element [{e.ElementIndexI}, {e.ElementIndexJ}] changed from {e.OldValue} to {e.NewValue}");
            }
        }
    }
}
