using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NET01._2Task
{
    public class SquareMatrix<T>
    {
        public int Size { get; private set; }
        public T[] MatrixValues { get; set; }

        /// <summary>
        /// Constructor for the matrix class
        /// </summary>
        /// <param name="size">Number of rows, which is equal to number of columns</param>
        /// <exception cref="ArgumentOutOfRangeException">Checks if size of matrix is positive</exception>
        public SquareMatrix(int size)
        {
            Size = size >= 0 ? size : throw new ArgumentOutOfRangeException(nameof(size), "Matrix size cannot be negative");
            MatrixValues = new T[size*size];
        }

        /// <summary>
        /// Indexer for accessing matrix elements
        /// </summary>
        /// <param name="i">Matrix row number</param>
        /// <param name="j">Matrix column number</param>
        /// <returns>Matrix element with [row,column] OR Sets matrix element [row,column]</returns>
        /// <exception cref="ArgumentOutOfRangeException">Checks if given row/column indices are valid</exception>
        public virtual T this[int i, int j]
        {
            get
            {
                int index; //index value of MatrixValues array element calculated using Row and Column indices of the matrix element
                
                if(i < 0 || i >= Size || j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Reading square matrix element with invalid index");
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
                    throw new ArgumentOutOfRangeException(nameof(index), "Setting square matrix element with invalid index");
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

        /// <summary>
        /// Override standard ToString() to output every matrix cell
        /// </summary>
        /// <returns>String of matrix elements divided by comma</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < Size; row++)
            {
                sb.AppendLine();
                for (int column = 0; column < Size; column++)
                {
                    sb.Append(this[row, column]);
                }
            }
            /*int count = 0;
            var newLine = '\n';
            for (int i = 1; i < sb.Length; i++)
            {
                if(sb[i] is ',')
                {
                    count++;
                }
                if(count %3 == 0)
                {
                    sb[i] = newLine;
                }
            }*/
            return sb.ToString();

        }
        /// <summary>
        /// Delegate of type EventHandler<Class to hold event data> for the event named MatrixElementChanged
        /// </summary>
        public event EventHandler<MatrixElementChangedEventArgs<T>> MatrixElementChanged;

        /// <summary>
        /// Method that fires the event (to be called by the delegate)
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMatrixElementChanged(MatrixElementChangedEventArgs<T> e) //broadcaster
        {
            MatrixElementChanged?.Invoke(this, e); //if MatrixElementChanged is not null invoke it?
        }

        /// <summary>
        /// Method to handle the event of changed matrix element, needs to subscribe to the event to get triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Class that stores the event data</param>
        public void WriteMatrixElementChangeDetails(object sender, MatrixElementChangedEventArgs<T> e) //method to subscribe to the event in main program
        {
            if(MatrixElementChanged != null) //if delegate MatrixElementChanged has a method subscribed to it
            {
                Console.WriteLine($"Matrix element [{e.ElementIndexI}, {e.ElementIndexJ}] changed from {e.OldValue} to {e.NewValue}");
            }
        }
    }
}
