using Calc;
namespace TestCalculator
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void TestSum()
        {
            double n1 = 4;
            double n2 = 6;
            double expected = 10;

            double result = Calculator.Sum(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDiff()
        {
            double n1 = 6;
            double n2 = 4;
            double expected = 2;

            double result = Calculator.Diff(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMult()
        {
            double n1 = 6;
            double n2 = 4;
            double expected = 24;

            double result = Calculator.Mult(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDiv()
        {
            double n1 = 6;
            double n2 = 2;
            double expected = 3;

            double result = Calculator.Div(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPow()
        {
            double n1 = 6;
            int n2 = 2;
            double expected = 36;

            double result = Calculator.Pow(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPowDegreeZero()
        {
            double n1 = 6;
            int n2 = 0;
            double expected = 1;

            double result = Calculator.Pow(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPowDegreeOne()
        {
            double n1 = 6;
            int n2 = 1;
            double expected = n1;

            double result = Calculator.Pow(n1, n2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetSquareRoot()
        {
            double n1 = 9;
            double expected = 3;

            double result = Calculator.GetSquareRoot(n1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetZeroSquareRoot()
        {
            double n1 = 0;
            double expected = 0;

            double result = Calculator.GetSquareRoot(n1);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNegativeSquareRoot()
        {
            double n1 = -9;

            Assert.ThrowsException<ArithmeticException>(() => Calculator.GetSquareRoot(n1));
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            double n1 = 6;
            double n2 = 0;

            Assert.ThrowsException<DivideByZeroException>(() => Calculator.Div(n1, n2));
        }

        
    }
}