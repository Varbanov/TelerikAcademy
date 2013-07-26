using System;
using System.Text;

    class Matrix
    {
        //* Write a class Matrix, to holds a matrix of integers. 
        //Overload the operators for adding, subtracting and multiplying of
        //matrices, indexer for accessing the matrix content and ToString()

        //fields
        private int rows;
        private int cols;
        private int[,] matrix;

        //constructor
        public Matrix(int row, int col)
        {
            matrix = new int[row, col];
            this.rows = row;
            this.cols = col;
        }
        //property for dimension 0
        public int Row
        {
            get { return rows; }
            set { rows = value; }
        }
        //property for dimension 1
        public int Col
        {
            get { return cols; }
            set { cols = value; }
        }

        //getter/setter to access elements by indexes
        public int this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        //override "+" operator
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Row, m1.Col);

            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        //override * operator
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Row, m1.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result[i, j] = m1[i, j] * m2[i, j];
                }
            }
            return result;
        }

        //override - operator
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Row, m1.Col);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Col; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        //override ToString()
        public override string ToString()
        {
            StringBuilder matrixToString = new StringBuilder();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (j > 0)
                    {
                        matrixToString.Append(" ");
                    }

                    matrixToString.Append(matrix[i, j].ToString());
                }
                if (i != rows - 1)
                {
                    matrixToString.Append("\n");
                }
            }
            return matrixToString.ToString();
        }
    }

