namespace Calculator
{
    public class Number
    {
        public double[] Ids;
        public double? addition;

        public Number()
        {
        }

        public Number(double[] ids, ICalculate calculate)
        {
            Ids = ids;
            addition = calculate.Addition();
        }
    }
}
