using System;
using System.Data;
using System.Text;
using Microsoft.CSharp;
using Microsoft.CSharp.RuntimeBinder;


namespace matr
{
    public class MatrixClass<T> : IMatrixClass
    {
        int CountOfRowAndColumn { get; set; }
        public T[,] Arr { get; set; }

        public MatrixClass(int CountOfRowAndColumn)
        {
            if (CountOfRowAndColumn > 0)
            {
                this.CountOfRowAndColumn = CountOfRowAndColumn;
                this.Arr = new T[CountOfRowAndColumn, CountOfRowAndColumn];
            }
            else
            {
                throw new Exception("Количество строк и столбцов должно быть больше 0!");
            }
        }

        public void SetRandAll(Random Number)
        {
            for (int i = 0; i < CountOfRowAndColumn; i++)
            {
                for (int j = 0; j < CountOfRowAndColumn; j++)
                {
                    Arr[i, j] = (dynamic)Number.Next(0, 100);
                }
            }
        }

        public static T Add<U>(U x, U y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }
        public static T Mult<U>(U x, U y, U z)
        {
            dynamic dx = x, dy = y, dz = z;
            return dx * dy + dz;
        }

        public static MatrixClass<T> operator +(MatrixClass<T> MatrixA, MatrixClass<T> MatrixB)
        {
            if (MatrixA.CountOfRowAndColumn == MatrixB.CountOfRowAndColumn)
            {
                MatrixClass<T> MatrixResult = new MatrixClass<T>(MatrixA.CountOfRowAndColumn);
                for (int i = 0; i < MatrixA.CountOfRowAndColumn; i++)
                {
                    for (int j = 0; j < MatrixA.CountOfRowAndColumn; j++)
                    {
                        MatrixResult.Arr[i, j] = Add(MatrixA.Arr[i, j], MatrixB.Arr[i, j]);
                    }
                }
                return MatrixResult;
            }
            else
            {
                throw new Exception("Матрицы нельзя сложить!");
            }
        }

        public static MatrixClass<T> operator *(MatrixClass<T> MatrixA, MatrixClass<T> MatrixB)
        {
            if (MatrixA.CountOfRowAndColumn == MatrixB.CountOfRowAndColumn)
            {
                MatrixClass<T> MatrixResult = new MatrixClass<T>(MatrixA.CountOfRowAndColumn);
                for (int i = 0; i < MatrixA.CountOfRowAndColumn; i++)
                {
                    for (int j = 0; j < MatrixA.CountOfRowAndColumn; j++)
                    {
                        for (int k = 0; k < MatrixA.CountOfRowAndColumn; k++)
                        {
                            MatrixResult.Arr[i, j] = Mult(MatrixA.Arr[i, k], MatrixB.Arr[k, j], MatrixResult.Arr[i, j]);
                        }
                    }
                }
                return MatrixResult;
            }
            else
            {
                throw new Exception("Матрицы нельзя перемножить!");
            }
        }

        public DataTable ToDataTable<T>()
        {
            var res = new DataTable();

            for (int i = 0; i < CountOfRowAndColumn; i++)
            {
                var forString = i + 1;
                res.Columns.Add("col" + forString, typeof(T));
            }

            for (int i = 0; i < CountOfRowAndColumn; i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < CountOfRowAndColumn; j++)
                {
                    row[j] = Arr[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
        public string SaveFile() // сохраняем матрицу в файл
        {
            StringBuilder Save = new StringBuilder();
            if (Arr == null) return Save.ToString();

            for (int i = 0; i < CountOfRowAndColumn; i++)
            {
                for (int t = 0; t < CountOfRowAndColumn; t++)
                {
                    Save.Append(Arr[i, t]);
                    Save.Append(";");
                }
                Save.Append("\n");
            }
            return Save.ToString();
        }
        public override bool Equals(object obj) // сотрим одинаковые ли матрицы или нет
        {
            MatrixClass<T> MatrixB = obj as MatrixClass<T>;
            if (CountOfRowAndColumn == MatrixB.CountOfRowAndColumn)
            {
                int NumberEquals = 0;
                for (int i = 0; i < CountOfRowAndColumn; i++)
                {
                    for (int j = 0; j < MatrixB.CountOfRowAndColumn; j++)
                    {
                        if (Arr[i, j] == (dynamic)MatrixB.Arr[i, j])
                        {
                            NumberEquals++;
                        }
                    }
                }
                if (CountOfRowAndColumn * CountOfRowAndColumn == NumberEquals) return true;
                else return false;
            }
            else return false;
        }
    }
}
