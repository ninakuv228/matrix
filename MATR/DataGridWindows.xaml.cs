using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using matr;
using System.Data;

namespace MATR
{
    /// <summary>
    /// Логика взаимодействия для DataGridWindows.xaml
    /// </summary>
    public partial class DataGridWindows : Window
    {
        Random rand = new Random();
        IMatrixClass MatrixA { get; set; }
        IMatrixClass MatrixB { get; set; }
        IMatrixClass MatrixRes { get; set; }
        int Typing { get; set; }
        int CountOfRowsAndColumns { get; set; }
        DataTable AMatricaTable { get; set; }
        DataTable BMatricaTable { get; set; }
        DataTable ResMatricaTable { get; set; }
        public DataGridWindows(int a, int c)
        {
            InitializeComponent();
            this.Typing = c;
            this.CountOfRowsAndColumns = a;
            this.MatrixA = GetType(a);
            this.MatrixB = GetType(a);
            this.MatrixRes = GetType(a);
            //MatrixOne.Columns = a;
            if (Typing == 0)
            {
                MatrixClass<int> Matrix1 = MatrixA as MatrixClass<int>;
                MatrixClass<int> Matrix2 = MatrixB as MatrixClass<int>;
                MatrixClass<int> MatrixResult = MatrixRes as MatrixClass<int>;
                AMatricaTable = Matrix1.ToDataTable<int>();
                BMatricaTable = Matrix2.ToDataTable<int>();
                ResMatricaTable = MatrixResult.ToDataTable<int>();
                MatrixOne.ItemsSource = AMatricaTable.DefaultView;
                MatrixTwo.ItemsSource = BMatricaTable.DefaultView;
                ResMatrix.ItemsSource = ResMatricaTable.DefaultView;
            }
            if (Typing == 1)
            {
                MatrixClass<long> Matrix1 = MatrixA as MatrixClass<long>;
                MatrixClass<long> Matrix2 = MatrixB as MatrixClass<long>;
                MatrixClass<long> MatrixResult = MatrixRes as MatrixClass<long>;
                AMatricaTable = Matrix1.ToDataTable<long>();
                BMatricaTable = Matrix2.ToDataTable<long>();
                ResMatricaTable = MatrixResult.ToDataTable<long>();
                MatrixOne.ItemsSource = AMatricaTable.DefaultView;
                MatrixTwo.ItemsSource = BMatricaTable.DefaultView;
                ResMatrix.ItemsSource = ResMatricaTable.DefaultView;
            }
            if (Typing == 2)
            {
                MatrixClass<float> Matrix1 = MatrixA as MatrixClass<float>;
                MatrixClass<float> Matrix2 = MatrixB as MatrixClass<float>;
                MatrixClass<float> MatrixResult = MatrixRes as MatrixClass<float>;
                AMatricaTable = Matrix1.ToDataTable<float>();
                BMatricaTable = Matrix2.ToDataTable<float>();
                ResMatricaTable = MatrixResult.ToDataTable<float>();
                MatrixOne.ItemsSource = AMatricaTable.DefaultView;
                MatrixTwo.ItemsSource = BMatricaTable.DefaultView;
                ResMatrix.ItemsSource = ResMatricaTable.DefaultView;
            }
            if (Typing == 3)
            {
                MatrixClass<double> Matrix1 = MatrixA as MatrixClass<double>;
                MatrixClass<double> Matrix2 = MatrixB as MatrixClass<double>;
                MatrixClass<double> MatrixResult = MatrixRes as MatrixClass<double>;
                AMatricaTable = Matrix1.ToDataTable<double>();
                BMatricaTable = Matrix2.ToDataTable<double>();
                ResMatricaTable = MatrixResult.ToDataTable<double>();
                MatrixOne.ItemsSource = AMatricaTable.DefaultView;
                MatrixTwo.ItemsSource = BMatricaTable.DefaultView;
                ResMatrix.ItemsSource = ResMatricaTable.DefaultView;
            }
        }



        private IMatrixClass GetType(int Count)
        {
            if (Typing == 0)
            {
                return new MatrixClass<int>(Count);
            }
            else if (Typing == 1)
            {
                return new MatrixClass<long>(Count);
            }
            else if (Typing == 2)
            {
                return new MatrixClass<float>(Count);
            }
            else if (Typing == 3)
            {
                return new MatrixClass<double>(Count);
            }
            else
            {
                throw new Exception("Ошибка типа данных!");
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (Typing == 0)
            {
                MatrixClass<int> Matrix1 = MatrixA as MatrixClass<int>;
                MatrixClass<int> Matrix2 = MatrixB as MatrixClass<int>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                else if (cmbCalcType.SelectedIndex == 1)
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
            }
            else if (Typing == 1)
            {
                MatrixClass<long> Matrix1 = MatrixA as MatrixClass<long>;
                MatrixClass<long> Matrix2 = MatrixB as MatrixClass<long>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                else if (cmbCalcType.SelectedIndex == 1)
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
            }
            else if (Typing == 2)
            {
                MatrixClass<float> Matrix1 = MatrixA as MatrixClass<float>;
                MatrixClass<float> Matrix2 = MatrixB as MatrixClass<float>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                else if (cmbCalcType.SelectedIndex == 1)
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
            }
            else
            {
                MatrixClass<double> Matrix1 = MatrixA as MatrixClass<double>;
                MatrixClass<double> Matrix2 = MatrixB as MatrixClass<double>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                else if (cmbCalcType.SelectedIndex == 1)
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
            }
        }

        private void btRandom_Click(object sender, RoutedEventArgs e)
        {
            if (Typing == 0)
            {
                MatrixClass<int> Matrix1 = MatrixA as MatrixClass<int>;
                MatrixClass<int> Matrix2 = MatrixB as MatrixClass<int>;
                Matrix1.SetRandAll(rand);
                Matrix2.SetRandAll(rand);
                DataGridUpdate(AMatricaTable, Matrix1);
                DataGridUpdate(BMatricaTable, Matrix2);
            }
            else if (Typing == 1)
            {
                MatrixClass<long> Matrix1 = MatrixA as MatrixClass<long>;
                MatrixClass<long> Matrix2 = MatrixB as MatrixClass<long>;
                Matrix1.SetRandAll(rand);
                Matrix2.SetRandAll(rand);
                DataGridUpdate(AMatricaTable, Matrix1);
                DataGridUpdate(BMatricaTable, Matrix2);
            }
            else if (Typing == 2)
            {
                MatrixClass<float> Matrix1 = MatrixA as MatrixClass<float>;
                MatrixClass<float> Matrix2 = MatrixB as MatrixClass<float>;
                Matrix1.SetRandAll(rand);
                Matrix2.SetRandAll(rand);
                DataGridUpdate(AMatricaTable, Matrix1);
                DataGridUpdate(BMatricaTable, Matrix2);
            }
            else
            {
                MatrixClass<double> Matrix1 = MatrixA as MatrixClass<double>;
                MatrixClass<double> Matrix2 = MatrixB as MatrixClass<double>;
                Matrix1.SetRandAll(rand);
                Matrix2.SetRandAll(rand);
                DataGridUpdate(AMatricaTable, Matrix1);
                DataGridUpdate(BMatricaTable, Matrix2);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (Typing == 0)
            {
                MatrixClass<int> Matrix1 = MatrixA as MatrixClass<int>;
                MatrixClass<int> Matrix2 = MatrixB as MatrixClass<int>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 + Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
                else if (cmbCalcType.SelectedIndex == 1)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 * Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
            }
            else if (Typing == 1)
            {
                MatrixClass<long> Matrix1 = MatrixA as MatrixClass<long>;
                MatrixClass<long> Matrix2 = MatrixB as MatrixClass<long>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 + Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
                else if (cmbCalcType.SelectedIndex == 1)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 * Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
            }
            else if (Typing == 2)
            {
                MatrixClass<float> Matrix1 = MatrixA as MatrixClass<float>;
                MatrixClass<float> Matrix2 = MatrixB as MatrixClass<float>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 + Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
                else if (cmbCalcType.SelectedIndex == 1)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 * Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
            }
            else
            {
                MatrixClass<double> Matrix1 = MatrixA as MatrixClass<double>;
                MatrixClass<double> Matrix2 = MatrixB as MatrixClass<double>;
                MTXUpdate(AMatricaTable, Matrix1);
                MTXUpdate(BMatricaTable, Matrix2);
                if (cmbCalcType.SelectedIndex == 0)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 + Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 + Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
                else if (cmbCalcType.SelectedIndex == 1)
                {
                    DataGridUpdate(ResMatricaTable, Matrix1 * Matrix2);
                    System.IO.File.WriteAllText("D://Matrix.csv", (Matrix1 * Matrix2).SaveFile());
                    MessageBox.Show("Файл сохранен в папке: D://Matrix.csv");
                }
            }
        }

        private void MTXUpdate<T>(DataTable Data, MatrixClass<T> MTX) // забираем данные из датагрид в матрицу
        {
            for (int i = 0; i < CountOfRowsAndColumns; i++)
            {
                for (int j = 0; j < CountOfRowsAndColumns; j++)
                {
                    MTX.Arr[i, j] = Data.Rows[i].Field<T>(j);
                }
            }
        }
        private void DataGridUpdate<T>(DataTable Data, MatrixClass<T> Matrica) // забираем данные из матрицы в датагрд
        {
            for (int i = 0; i < CountOfRowsAndColumns; i++)
            {
                for (int j = 0; j < CountOfRowsAndColumns; j++)
                {
                    Data.Rows[i].SetField(j, Matrica.Arr[i, j]); // вводим в окно
                }
            }
        }

    }
}
