using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[,] expected = new int[,] 
            {
                {1,10,11,12},
                {9,2,15,13},
                {8,16,3,14},
                {7,6,5,4}
            };

            var matrix = Matrix.GetFilledMatrix(4);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.AreEqual(matrix[i, j], expected[i, j]);
                }
            }
        }
    }
}
