using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathProject_v2
{
    internal class Matrix
    {
        private int[,] matrixInt;
        private double[,] matrixDouble;

        public int[,] MatrixIntInput()
        {
            int rows;
            int columns;
            rows = Convert.ToInt32(Console.ReadLine());
            columns = Convert.ToInt32(Console.ReadLine());
            if (rows == 0 || columns == 0)
            {
                throw new ArgumentException("Матрица не может быть null и должна иметь хотя бы одну строку и один столбец.");
            }
            matrixInt = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("Введите элемент {0} {1}", i + 1, j + 1);
                    matrixInt[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return matrixInt;
        }
        public double[,] MatrixInput()//Ввод матриц
        {
            try 
            {
            int rows;
            int columns;
            rows = Convert.ToInt32(Console.ReadLine());
            columns = Convert.ToInt32(Console.ReadLine());
            matrixDouble = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine("Введите элемент {0} {1}", i + 1, j + 1);
                    matrixDouble[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            return matrixDouble;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return matrixDouble;
            }
        }


        public void MatrixOutput(int[,] matrixInt)// Вывод матриц
        {
            int rows = matrixInt.GetLength(0);
            int columns = matrixInt.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrixInt[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void MatrixOutput(double[,] matrixInt)// Вывод матриц
        {
            int rows = matrixInt.GetLength(0);
            int columns = matrixInt.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrixInt[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        
        public double[,] MatrixMultipConst(double[,] matrixDouble, double constant)//Умножение на константу
        {
            try { 
            int rows = matrixDouble.GetLength(0);
            int columns = matrixDouble.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    matrixDouble[i, j] = matrixDouble[i, j] * constant;
                }
            }
            return matrixDouble;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return matrixDouble;
            }
        }


        
        public double[,] MatrixSumm(double[,] matrix1, double[,] matrix2)//Сумма матриц
        {
            double[,] resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
            {
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return resultMatrix;
            }
            else
            {
                Console.WriteLine("Матрицы должны быть одинаковой размерности");
                return resultMatrix;
            }

        }


       
        
        public double[,] MatrixDifference(double[,] matrix1, double[,] matrix2)// Вычитание матриц
        {
            double[,] resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            if (matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1))
            {
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return resultMatrix;
            }
            else
            {
                Console.WriteLine("Матрицы должны быть одинаковой размерности");
                return resultMatrix;
            }

        }


        
        public double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)//Умножение матриц
        {
            double[,] resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                for (int i = 0; i < resultMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < resultMatrix.GetLength(1); j++)
                    {
                        for (int element = 0; element < matrix2.GetLength(0); element++)
                        {
                            resultMatrix[i, j] += matrix1[i, element] * matrix2[element, j];
                        }
                    }
                }
                return resultMatrix;
            }
            else
            {
                Console.WriteLine("Количество столбцов в первой матрице должно быть равно количеству строк во второй");
                return resultMatrix;
            }

        }


        
        public double[] ReturnColumn(double[,] matrix1, int number)//Извелчь столбец
        {
            int rows = matrix1.GetLength(0);
            double[] column = new double[rows];
            try 
            { 
                
                for (int i = 0; i < rows; i++)
                {
                    column[i] = matrix1[i, number - 1];
                }
                return column;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return column;
            }
        }
        public double[] ReturnRow(double[,] matrix1, int number)//Извлечь строку
        {
            int columns = matrix1.GetLength(1);
            double[] row = new double[columns];
            try
            {

            
                for (int i = 0; i < columns; i++)
                {
                    row[i] = matrix1[number - 1, i];
                }
                return row;
            }
            catch
            {
                Console.WriteLine("Введите корректыне данные");
                return row;
            }
        }

        
        public void SetElement(double[,] matrix1, int row, int column, double value) //Изменение элемента
        {
            try
            {
                matrix1[row - 1, column - 1] = value;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
            }
            
        }




        
        public double[,]? TransposedMatrix(double[,] matrix)// Транспонирование матрицы
        {
            int rowsInit = matrix.GetLength(0);   //Inittial  - значения кол-ва строк и столбцов у исходной матрицы
            int columnsInit = matrix.GetLength(1);
            double[,] transposedMatrix = new double[columnsInit, rowsInit];
            try
            { 
            for (int i = 0; i < columnsInit; i++)
            {
                for (int j = 0; j < rowsInit; j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                }
            }
            return transposedMatrix;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return null;
            }
        }

        public double? AlgebraicComplement(double[,] matrix, int row, int column)//Алгебраическое дополнение
        {

            int rowsAmount = matrix.GetLength(0);
            int columnsAmount = matrix.GetLength(1);
            double[,] temporary = new double[rowsAmount - 1, columnsAmount - 1];
            try
            { 
            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    if (i != row && j != column)
                    {
                        temporary[i < row ? i : i - 1, j < column ? j : j - 1] = matrix[i, j];
                    }
                }
            }
            return Determinant(temporary) * Math.Pow(-1, row + column);
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return null;
            }


        }

        public double? Determinant(double[,] matrix)
        {
            try { 
            double rows = matrix.GetLength(0);
            double columns = matrix.GetLength(1);
            if (rows != columns)
            {
                return null;
            }
            if (rows == 1)
            {
                return matrix[0, 0];
            }
            if (rows == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double? det = 0;
                for (int element = 0; element < rows; element++)
                {
                    det += matrix[0, element] * AlgebraicComplement(matrix, 0, element);
                }
                return det;
            }
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return null;
            }
        }//Определитель


        public double[][] ListOfRows(double[,] matrix, params int[] rows)//Список строк
        {
            double[][] valueOfRows = new double[rows.Length][];
            try 
            { 
            

            for (int i = 0; i < rows.Length; i++)
            {
                valueOfRows[i] = new double[matrix.GetLength(1)];
            }
            for (int i = 0; i < rows.Length; i++)
            {
                valueOfRows[i] = ReturnRow(matrix, rows[i]);
            }
            return valueOfRows;
            }
            catch
            {
                Console.WriteLine("Введите корректные данные");
                return valueOfRows;

            }
        }

        public double[][] ListOfColumns(double[,] matrix, params int[] rows)//Список столбцов
        {
            double[][] valueOfColumns = new double[rows.Length][];
            try
            {

            

            for (int i = 0; i < rows.Length; i++)
            {
                valueOfColumns[i] = new double[matrix.GetLength(1)];
            }
            for (int i = 0; i < rows.Length; i++)
            {
                valueOfColumns[i] = ReturnColumn(matrix, rows[i]);
            }
            return valueOfColumns;
            }
            catch
            {
                Console.WriteLine("Введмте корректные даннные");
                return valueOfColumns;
            }
        }


    }
}
