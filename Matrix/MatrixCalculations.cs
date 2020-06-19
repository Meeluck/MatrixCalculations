using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
	public class MatrixCalculations 
	{
        #region Определитель
        //получение миноров для расчета определителя матрицы
        static void GetMinor(int[,] matr, ref int[,] p, int i, int j, int s)
        {
            int ki;
            int kj;
            int di = 0;
            int dj = 0;

            for (ki = 0; ki < s - 1; ki++)
            {
                // проверка индекса строки
                if (ki == i)
                    di = 1;
                dj = 0;
                for (kj = 0; kj < s - 1; kj++)
                {
                    // проверка индекса столбца
                    if (kj == j)
                        dj = 1;
                    p[ki, kj] = matr[ki + di, kj + dj];
                }
            }
        }

        public static int Determinant(int[,] matr, int s)
        {

            int i, d, k, n;
            int[,] p = new int[s, s]; //матрица для миноров 
            d = 0; //детерминанте
            k = 1; //(-1) в степени i
            n = s - 1; //размер минора

            if (s == 1)
            {
                d = matr[0, 0];
                return d;
            }

            if (s == 2)
            {
                d = (matr[0, 0] * matr[1, 1]) - matr[1, 0] * matr[0, 1];
                return d;
            }

            if (s > 2)
            {
                for (i = 0; i < s; i++)
                {
                    GetMinor(matr, ref p, i, 0, s);
                    d = d + k * matr[i, 0] * Determinant(p, n);
                    k = -k;
                }
            }

            return d;
        }
        #endregion

        #region Ранг матрицы
        static void Swap(int[,] mat, int row1, int row2, int col)
        {
            for (int i = 0; i < col; i++)
            {
                int temp = mat[row1, i];
                mat[row1, i] = mat[row2, i];
                mat[row2, i] = temp;
            }
        }
        public static void Display(int[,] mat, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                    Console.Write(" " + mat[i, j]);
                Console.Write("\n");
            }
        }

        // function for finding rank of matrix  
        public static int RankOfMatrix(int[,] mat, int R, int C)
        {
            int rank = Math.Min(R, C);

            for (int row = 0; row < rank; row++)
            {
                //Приводим матрицу к ступенчатому виду
                if (mat[row, row] != 0)
                {
                    for (int col = 0; col < R; col++)
                    {
                        if (col != row)
                        {
                            double mult = (double)mat[col, row] / mat[row, row];

                            for (int i = 0; i < rank; i++)
                                mat[col, i] -= (int)(mult * mat[row, i]);
                        }
                    }
                }

                /*
                 * Если диагональный элемент равен 0 возникает 2 случая
                 *  1)  Если под этим элементом есть строка с ненулевым элементом
                 *      меняем местами тещую строку с той строкой, где найден 
                 *      ненулевой элемент
                 *  2)  Если все элементы текущем столбце ниже диагонального 
                 *      элемента равны 0, тогда меняем местами данные столбец 
                 *      с крайним и уменьшаем количество столбцов на 1
                 */

                else
                {
                    bool reduce = true;

                    // Ищем ненулевой элемент в текущем столбце
                    for (int i = row + 1; i < R; i++)
                    {
                        //меняем строку с ненулевым элементов на текущую строку
                        if (mat[i, row] != 0)
                        {
                            Swap(mat, row, i, rank);
                            reduce = false;
                            break;
                        }
                    }

                    /*
                     * Если мы не нашли ни одной строки с ненулевым элементом
                     * в текущем столбце, то все значения в этом столбце равны 0.
                     */
                    if (reduce)
                    {
                        //Уменьшаяем ранг матрицы
                        rank--;

                        // Копируем последний столбце
                        for (int i = 0; i < R; i++)
                            mat[i, row] = mat[i, rank];
                    }
                    row--;
                }
            }

            return rank;
        }
        #endregion

        #region Собсвтенные значения матрицы
        public static void Eigenvalues(int [,] matr, int n)
        {
            double[] w0 = new double[n];     //случайный ненулевой вектор
            double[] w0norm = new double[n]; //нормализованный ненулевой вектор
            double summ;        //промежуточная переменная суммы вектора
            double e;           //проверка на точность
            double d;           //собственное значение после итерации 
            double d0;		    //собственное значение до итерации 

            int i, j, k;
            //Инициализация случайного ненулевого вектора
            for (i = 0; i < n; i++)
                w0[i] = 0;
            w0[0] = 1;

            do
            {
                summ = 0;
                // Нормализация ненулевого вектора для исключения получения переполнения и комплексных значений
                for (i = 0; i < n; i++)
                    summ = summ + w0[i] * w0[i];
                d0 = Math.Sqrt(summ);
                for (i = 0; i < n; i++)
                    w0norm[i] = w0[i] / d0;

                //Произведение  Y[n] = Y[n - 1] * A
                for (i = 0; i < n; i++)
                {
                    w0[i] = 0;
                    for (j = 0; j < n; j++)
                        w0[i] = w0[i] + matr[i,j] * w0norm[j];
                }

                //вычисление собственного значения (с проверкой на необходимую точность)
                summ = 0;
                for (i = 0; i < n; i++)
                    summ = summ + w0[i] * w0[i];
                d = Math.Sqrt(summ);

                e = Math.Abs(d - d0);
            }
            while (e > 0.001);

            Console.WriteLine("Максимальное собственное число= " + d);
        }
          
    }
    #endregion
}
