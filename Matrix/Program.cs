using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
	class Program
	{
        static void TestRank()
        {
            int[,] matrix1 =
            {
                {1,0,2 },
                {0,2,0 },
                {2,0,3 }
            };
            MatrixCalculations.Display(matrix1, 3, 3);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix1, 3, 3));


            int[,] matrix2 =
            {
                {3,-3,-5,8 },
                {-3,2,4,-6 },
                {2,-5,-7,5 },
                {-4,3,5,-6 }
            };
            MatrixCalculations.Display(matrix2, 4, 4);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix2, 4, 4));

            int[,] matrix3 =
            {
                {2,4,6},
                {1,2,3},
                {3,6,9}
            };
            MatrixCalculations.Display(matrix3, 3, 3);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix3, 3, 3));

            int[,] matrix4 =
                {
                    {10, 20, 10},
                    {-20, -30, 10},
                    {30, 50, 0}
                };
            MatrixCalculations.Display(matrix4, 3, 3);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix4, 3, 3));
            int[,] matrix5 =
            {
                {1,-1,7,-5,3 },
                {2,5,-3,9,4 },
                {3,-2,8,1,5 },
                {4,6,-4,2,6 }
            };
            MatrixCalculations.Display(matrix5, 4, 5);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix5, 4, 5));

            int[,] matrix6 =
            {
                {1,2,0,5},
                {2,4,-1,0},
                {-2,-4,1,0},
                {1,0,2,1}
            };
            MatrixCalculations.Display(matrix6, 4, 4);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix6, 4, 4));
            int[,] matrix7 =
            {
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
                {0,0,0,0},
            };
            MatrixCalculations.Display(matrix7, 4, 4);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix7, 4, 4));
            int[,] matrix8 =
            {
                {1,1,1,1},
                {1,1,1,1},
                {1,1,1,1},
                {0,0,0,0},
            };
            MatrixCalculations.Display(matrix8, 4, 4);
            Console.WriteLine("Rank of the matrix is : "
                              + MatrixCalculations.RankOfMatrix(matrix8, 4, 4));
        }
        static void Main(string[] args)
		{
            TestRank();
            Console.ReadKey();
        }
	}
}
