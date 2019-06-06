using Calculator;
using Common;
using System;
using System.Data.SqlClient;

namespace Data.Providers
{
    public class MsSqlDataProvider
    {
        private Numbers _numbers;
        private string _connectionString;

        public MsSqlDataProvider(Numbers numbers, Parameters parameters)
        {
            _numbers = numbers;
            _connectionString = parameters.ConnectionStringMsSql;
        }

        public void SendDataToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
            return $"INSERT INTO WebApiDb.dbo.TabCalculation (Number1, Number2, Result, UpdateDate) VALUES ({_numbers.number1},{_numbers.number2},{_numbers.result},'{DateTime.Now.ToString("yyyy-MM-dd")}')";
        }

        private string SetEnvironemnt()
        {
            string query = @"
                IF DB_ID('WebApiDb') IS NULL
                    CREATE DATABASE WebApiDb;
                
                IF OBJECT_ID('WebApiDb.dbo.TabCalculation') IS NULL
                    CREATE TABLE WebApiDb.dbo.TabCalculation(id INT IDENTITY(1, 1) NOT NULL, Number1 FLOAT, Number2 FLOAT, Result FLOAT, CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL, UpdateDate DATETIME NOT NULL)";
    
            return query;
        }
    }
}
