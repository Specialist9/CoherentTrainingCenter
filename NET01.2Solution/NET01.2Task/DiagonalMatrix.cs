using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2Task
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
            MatrixValues = new T[size];
        }

        public override T this[int i, int j]
        {
            get
            {
                if(i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(i), "Trying to read diagonal matrix element with invalid indices");
                }
                else if(i == j)
                {
                    return MatrixValues[i];
                }
                else { return default(T); }
            }

            set
            {
                if (i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(i), "Trying to set diagonal matrix element with invalid indices");
                }
                else if(i == j)
                {
                    if (MatrixValues[i] != null && MatrixValues[i].Equals(value)) return;
                    T oldValue = MatrixValues[i];
                    MatrixValues[i] = value;
                    OnMatrixElementChanged(new MatrixElementChangedEventArgs<T>(oldValue, value, i, i));
                }
            }
        }


    }
}
