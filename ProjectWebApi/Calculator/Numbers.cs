namespace Calculator
{
    public class Number
    {
        public double[] Ids;
        public double? result;

        public Number()
        {
        }

        public Number(double[] ids, ICalculate calculate)
        {
            Ids = ids;
            result = calculate.Addition();
        }
    }
}
