//Завдання 4 (додатково)

//Створiть та опишiть клас «Матриця».

//Виконайте перевантаження

//+ (для додавання матриць),

//– (для віднімання матриць).

//* (множення матриць одна на одну, множення матриці на число),

//== та != (перевірка матриць на рівність/не рiвнiсть),

//Використовуйте механізм властивостей полів класу і механізм індексаторів.

namespace HW4_OperatorOverloading.Classes
{
    class Matrix
    {
        private double[,] _matrix;

        public Matrix(int n)
        {
            _matrix = new double[n, n];
        }

        public Matrix(double[,] data)
        {
            _matrix = (double[,])data.Clone();
        }

        public double this[int row, int col]
        {
            get => _matrix[row, col];
            set => _matrix[row, col] = value;
        }

        public double[,] GetMatrix { get => _matrix; }
        public int Rows => _matrix.GetLength(0);
        public int Cols => _matrix.GetLength(1);
        
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if ((a.Rows != b.Rows) || (a.Cols != b.Cols))
                throw new Exception("Matrix have different size");
            else
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        a[i, j] += b[i, j];
                return a;
            }
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if ((a.Rows != b.Rows) || (a.Cols != b.Cols))
                throw new Exception("Matrix have different size");
            else
            {
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Cols; j++)
                        a[i, j] -= b[i, j];
                return a;
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if ((a.Rows != b.Rows) || (a.Cols != b.Cols))
                throw new Exception("Matrix have different size");
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    a[i, j] *= b[i, j];
            return a;
        }

        public static Matrix operator *(Matrix a, double num)
        {
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    a[i, j] *= num;
            return a;
        }
        public static bool operator ==(Matrix a, Matrix b) => a.Equals(b);
        public static bool operator !=(Matrix a, Matrix b) => !a.Equals(b);

        public void PrintMatrix()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
