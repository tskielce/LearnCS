﻿using System.IO;
using Calculator;
using Common;

namespace Data.Providers
{
    public class TextFileDataProvider
    {
        private readonly string PathFile;
        private readonly Parameter Parameters;
        private readonly Number Numbers;

        public TextFileDataProvider(Number Numbers, Parameter Parameters)
        {
            this.Numbers = Numbers;
            this.Parameters = Parameters;
            PathFile = $"{Parameters.Path}\\{Parameters.FileName}.txt";

            SendDataToFile();
        }

        private void SendDataToFile()
        {
            CreateDirectoryAndFile();
            WriteDataToFile();
        }

        private void CreateDirectoryAndFile()
        {
            if (!Directory.Exists(Parameters.Path))
            {
                Directory.CreateDirectory(Parameters.Path);
            }

            if (!File.Exists(PathFile))
            {
                File.Create(PathFile);
            }
        }

        public void WriteDataToFile()
        {
            using (StreamWriter sw = File.AppendText(PathFile))
            {
                sw.WriteLine($"{Numbers.Ids[0]}\t{Numbers.Ids[1]}\t{Numbers.addition}");
            }
        }
    }
}
