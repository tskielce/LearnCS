using Calculator;
using Common;
using System;
using System.Data.SqlClient;

namespace Data.Providers
{
    public class MsSqlDataProvider
    {
        private Number Numbers;
        private string ConnectionString;

        public MsSqlDataProvider(Number numbers, Parameter parameters)
        {
            Numbers = numbers;
            ConnectionString = parameters.ConnectionStringMsSql;

            SendDataToDatabase();
        }

        private void SendDataToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(SetEnvironemnt(), connection);

                sqlCommand.ExecuteNonQuery();
                sqlCommand = new SqlCommand(InserData(),connection);

                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        private string InserData()
        {
            return $"INSERT INTO WebApiDb.dbo.TabCalculation (Number1, Number2, Result) VALUES ({Numbers.Ids[0].ToString()},{Numbers.Ids[1].ToString()},{Numbers.result.ToString()})";
        }

        private string SetEnvironemnt()
        {
            string query = @"
                IF OBJECT_ID('WebApiDb.dbo.TabCalculation') IS NULL
                    CREATE TABLE WebApiDb.dbo.TabCalculation(id INT IDENTITY(1, 1) NOT NULL, Number1 FLOAT, Number2 FLOAT, Result FLOAT, CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL, UpdateDate DATETIME NOT NULL)";
    
            return query;
        }
    }
}
