using Common;
using Calculator;
using Data.Providers;

namespace ProjectWebApi.View
{
    public class Request
    {
        private string _id1;
        private string _id2;
        private Numbers _numbers;
        ICalculate _calculate;
        private Parameters _parameters;

        public Request(string id1, string id2, Parameters parameters)
        {
            _id1 = id1;
            _id2 = id2;
            _parameters = parameters;
        }

        public Numbers SetNumbers()
        {
            _numbers = new Numbers();
            _numbers.number1 = SetId(_id1);
            _numbers.number2 = SetId(_id2);
            _calculate = new Calculate(_numbers);
            _numbers.result = _calculate.Addition();

            return _numbers;
        }

        private bool AreIdsCorrect()
        {
            var ifId1 = HelperStaticMethods.CanVariableParseToInt(_id1);
            var ifId2 = HelperStaticMethods.CanVariableParseToInt(_id2);

            if (ifId1 && ifId2)
            {
                return true;
            }
            return false;
        }
        
        private int SetId(string id)
        {
            return int.Parse(id);
        }

        public Numbers CalculateResult()
        {
            if (AreIdsCorrect())
            {
                Numbers num = SetNumbers();

                TextFileDataProvider textFileDataProvider = new TextFileDataProvider(num, _parameters);
                textFileDataProvider.SendDataToFile();

                MsSqlDataProvider msSqlDataProvider = new MsSqlDataProvider(num, _parameters);
                msSqlDataProvider.SendDataToDatabase();

                return num;
            }
            return null;
        }
    }
}
