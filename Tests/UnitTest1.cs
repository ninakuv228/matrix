using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using matr;
using System.Windows;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))] // исключение
        
        public void TestMethod1()
        {
            MatrixClass<int> A = new MatrixClass<int>(0); // нулевая матрица
        }
        [TestMethod]
        public void TestMethod2()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(2); // одинакове ли матрицы (проверка метода Equals)
            MatrixClass<int> MT2 = new MatrixClass<int>(2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MT1.Arr[i, j] = 1;
                    MT2.Arr[i, j] = 1;
                }
            }
            Assert.AreEqual(true, MT1.Equals(MT2));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))] // исклчение
        public void TestMethod3()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(3); // проверка умножения матриц разных размерностей
            MatrixClass<int> MT2 = new MatrixClass<int>(2);

            MatrixClass<int> MT3 = MT1 * MT2;
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod4()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(3);
            MatrixClass<int> MT2 = new MatrixClass<int>(2);

            MatrixClass<int> MT3 = MT1 + MT2;
        }

        [TestMethod]
        public void TestMethod5()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(2);
            MatrixClass<int> MT2 = new MatrixClass<int>(2);
            MatrixClass<int> MT3 = new MatrixClass<int>(2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MT3.Arr[i, j] = 2;
                    MT1.Arr[i, j] = 1;
                    MT2.Arr[i, j] = 1;
                }
            }
            Assert.AreEqual(true, MT3.Equals(MT1 + MT2));
        }
        [TestMethod]
        public void TestMethod6()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(2);
            MatrixClass<int> MT2 = new MatrixClass<int>(2);
            MatrixClass<int> MT3 = new MatrixClass<int>(2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MT3.Arr[i, j] = 2;
                    MT1.Arr[i, j] = 1;
                    MT2.Arr[i, j] = 1;
                }
            }
            Assert.AreEqual(true, MT3.Equals(MT2 * MT1));
        }
        [TestMethod]
        public void TestMethod7()
        {
            MatrixClass<int> MT1 = new MatrixClass<int>(2);
            MatrixClass<int> MT2 = new MatrixClass<int>(2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MT1.Arr[i, j] = 1;
                    MT2.Arr[i, j] = 1;
                }
            }
            Assert.AreEqual(true, (MT2 + MT1).Equals(MT1 + MT2));
        }
        [TestMethod]
        public void TestMethod8()
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            MatrixClass<int> MT1 = new MatrixClass<int>(2);
            MatrixClass<int> MT2 = new MatrixClass<int>(2);
            MT1.SetRandAll(rand1);
            MT2.SetRandAll(rand2);
            Assert.AreEqual(true, (MT2 * MT1).Equals(MT1 * MT2));
        }
        [TestMethod]
        public void TestMethod9()
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            MatrixClass<int> MT1 = new MatrixClass<int>(1); // перемножение матриц размерности 1
            MatrixClass<int> MT2 = new MatrixClass<int>(1);
            MT1.SetRandAll(rand1);
            MT2.SetRandAll(rand2);
            int MT3 = MT1.Arr[0, 0] * MT2.Arr[0, 0];
            Assert.AreEqual(true, MT3.Equals((MT1 * MT2).Arr[0, 0]));

        }
        [TestMethod]
        public void TestMethod10()
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            MatrixClass<int> MT1 = new MatrixClass<int>(1);
            MatrixClass<int> MT2 = new MatrixClass<int>(1);
            MT1.SetRandAll(rand1);
            MT2.SetRandAll(rand2);
            int MT3 = MT1.Arr[0, 0] + MT2.Arr[0, 0];
            Assert.AreEqual(true, MT3.Equals((MT1 + MT2).Arr[0, 0]));
        }
    }
}