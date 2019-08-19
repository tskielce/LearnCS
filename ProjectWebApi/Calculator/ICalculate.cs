namespace Calculator
{
    public interface ICalculate
    {
        double[] Ids { get; set; }
        double? Addition();
        double? Subtraction();
        double? Multiplication();
        double? Division();
    }
}
