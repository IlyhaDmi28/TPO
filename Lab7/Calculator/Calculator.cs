namespace Calc
{
    public static class Calculator
    {
        public static double Sum(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Diff(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Mult(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Div(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Делить на ноль нельзя!");
            }
            return number1 / number2;
        }

        public static double Pow(double number1, int degree)
        {
            if (degree == 0)
                return 1;
            double result = number1;
            for (int i = 1; i < degree; i++)
            {
                result *= number1;
            }
            return result;
        }

        public static double GetSquareRoot(double number, double epsilon = 0.000001)
        {
            if (number < 0) throw new ArithmeticException("Неудаётся получить квадратный корень из отрицательного числа!");

            if (number == 0) return 0;

            double approximation = number; 
            double result = 0.5 * (approximation + number) / approximation;

            while (Math.Abs(result - approximation) > epsilon)
            {
                approximation = result;
                result = 0.5 * (approximation + number / approximation);
            }
            return result;
        }
    }
}