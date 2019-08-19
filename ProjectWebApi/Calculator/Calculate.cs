namespace Calculator
{
    public class Calculate : ICalculate
    {
        public double[] Ids { get; set; }
        public Calculate(double[] ids)
        {
            Ids = ids;
        }
        /// <summary>
        /// Dodawanie
        /// </summary>
        /// <returns></returns>
        public double? Addition()
        {
            double? result = null;

            if (Ids.Length > 0)
            {
                result = Ids[0];
                for (int i = 1; i < Ids.Length; i++)
                {
                    result += Ids[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Dzielenie
        /// </summary>
        /// <returns></returns>
        public double? Division()
        {
            double? result = null;

            if (Ids.Length > 0)
            {
                result = Ids[0];
                for (int i = 1; i < Ids.Length; i++)
                {
                    result /= Ids[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Mnozenie
        /// </summary>
        /// <returns></returns>
        public double? Multiplication()
        {
            double? result = null;

            if (Ids.Length > 0)
            {
                result = Ids[0];
                for (int i = 1; i < Ids.Length; i++)
                {
                    result *= Ids[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Odejmowanie
        /// </summary>
        /// <returns></returns>
        public double? Subtraction()
        {
            double? result = null;

            if (Ids.Length > 0)
            {
                result = Ids[0];
                for (int i = 1; i < Ids.Length; i++)
                {
                    result *= Ids[i];
                }
            }
            return result;
        }
    }
}
