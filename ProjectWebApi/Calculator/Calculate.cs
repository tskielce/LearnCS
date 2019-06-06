namespace Calculator
{
    public class Calculate : ICalculate
    {
        Numbers _numbers;
        public Calculate(Numbers numbers)
        {
            _numbers = numbers;
        }
        /// <summary>
        /// Dodawanie
        /// </summary>
        /// <returns></returns>
        public double Addition()
        {
            return _numbers.number1 + _numbers.number2;
        }

        /// <summary>
        /// Dzielenie
        /// </summary>
        /// <returns></returns>
        public double Division()
        {
            return _numbers.number1 / _numbers.number2;
        }

        /// <summary>
        /// Mnozenie
        /// </summary>
        /// <returns></returns>
        public double Multiplication()
        {
            return _numbers.number1 * _numbers.number2;
        }

        /// <summary>
        /// Odejmowanie
        /// </summary>
        /// <returns></returns>
        public double Subtraction()
        {
            return _numbers.number1 - _numbers.number2;
        }
    }
}
