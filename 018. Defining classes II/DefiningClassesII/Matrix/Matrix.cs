using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesII.Matrix
{
    class Matrix<T>
        where T: IComparable<T>, IComparable
    {
        /*Define a class Matrix<T> to hold a matrix of numbers 
         * (e.g. integers, floats, decimals). 
        Implement an indexer this[row, col] to access the inner matrix cells.
        */
        private int rows;
        private int cols;
        private readonly T[,] matrix;

        //constructor
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[rows, cols];
        }

        //properties for row and col
        public int Rows
        {
            get { return rows; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rows should be positive!");
                }
                rows = value;
            }
        }

        public int Cols
        {
            get { return cols; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cols should be positive!");
                }
                cols = value;
            }
        }

        //indexer
        public T this[int row, int column]
        {
            get
            {
                if (row >= matrix.GetLength(0) ||
                    row < 0 || column >= matrix.GetLength(1) || column < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }
                return this.matrix[row, column];
            }
            set 
            {
                if (row >= matrix.GetLength(0) || row < 0 ||
                    column >= matrix.GetLength(1) || column < 0)
                {
                    throw new IndexOutOfRangeException("Invalid index!");
                }
                this.matrix[row, column] = value;

            }
        }

       //operators
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArithmeticException("Invalid operation: different matrices");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (T)((dynamic)m1[i, j] + (dynamic)m2[i, j]);
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {

            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArithmeticException("Invalid operation: different matrices");
            }
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = (T)((dynamic)m1[i, j] - (dynamic)m2[i, j]);
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new ArithmeticException("Invalid operation: different matrices");
            }
            else
            {
                Matrix<T> res = new Matrix<T>(m1.Rows, m2.Cols);


                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m2.Cols; j++)
                    {
                        dynamic sum = 0;
                        for (int x = 0; x < m1.Cols; x++)
                        {
                            sum = sum + (T)((dynamic)m1[i, x] * (dynamic)m2[x, j]);
                        }
                        res[i, j] = sum;
                    }
                }
                return res;
            }
        }


    }
}
