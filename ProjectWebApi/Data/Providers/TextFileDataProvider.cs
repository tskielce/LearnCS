using Calculator;
using Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace Data.Providers
{
    public class TextFileDataProvider
    {
        private string _path;
        private string _pathFile;
        private List<Numbers> _result;
        private Numbers _numbers;

        public TextFileDataProvider(Numbers numbers, Parameters parameters)
        {
            _numbers = numbers;
            _path = parameters.path;
            _pathFile = $"{parameters.path}\\{parameters.fileName}.txt";
        }


        public void SendDataToFile()
        {
            Create();

            var stream = ReadData();

            var listFromStream = ConvertStreamToList(stream);

            var listData = AddNewElementToExistingList(listFromStream);

            WriteData(listData);
        }

        public void Create()
        {
            if (!DoesFileExist())
            {
                File.Create(_pathFile);
            }
        }

        private string[] ReadData()
        {
            if (DoesFileExist())
            {
                using (StreamReader reader = new StreamReader(_pathFile))
                {
                    var stream = reader.ReadToEnd().Split('\n');
                    reader.Close();
                    return stream;
                }
            }

            return null;
        }

        private List<Numbers> ConvertStreamToList(string[] stream)
        {
            List<Numbers> listNum = new List<Numbers>();

            bool streamNull = (stream[0] == "") ? true : false;

            if (!streamNull)
            {
                foreach (var result in stream)
                {
                    if (result.ToString().IndexOf("\r") >= 0)
                    {
                        listNum.Add(new Numbers
                        {
                            number1 = Convert.ToInt32(result.Split(',')[0]),
                            number2 = Convert.ToInt32(result.Split(',')[1]),
                            result = Convert.ToInt32(result.Split(',')[2])
                        });
                    };
                }
            }

            return listNum;
        }

        private List<Numbers> AddNewElementToExistingList(List<Numbers> list)
        {
            list.Add(new Numbers { number1 = _numbers.number1, number2 = _numbers.number2, result = _numbers.result });

            return list;
        }

        public void WriteData(List<Numbers> numbers)
        {
            using (TextWriter tw = new StreamWriter(_pathFile))
            {
                foreach (var item in numbers)
                {
                    tw.WriteLine($"{item.number1},{item.number2},{item.result}");
                }
                
                tw.Close();
            }
        }

        private bool DoesFileExist() => File.Exists(_pathFile);
    }
}
