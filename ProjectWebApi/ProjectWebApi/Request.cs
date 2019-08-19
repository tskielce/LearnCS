using Calculator;

namespace ProjectWebApi.View
{
    public class Request
    {
        private readonly double[] Ids = new double[2];
        public Number Numbers;

        public Request(string id1, string id2)
        {
            Ids[0] = ConvertToInt(id1);
            Ids[1] = ConvertToInt(id2);

            var calculate = new Calculate(Ids);

            Numbers = new Number(Ids,calculate);
        }

        private int ConvertToInt(string id)
        {
            return (int.TryParse(id, out _)) ? int.Parse(id) : 0;
        }
    }
}
