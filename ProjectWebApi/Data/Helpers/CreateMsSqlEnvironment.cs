using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Helpers
{
    class CreateMsSqlEnvironment
    {
        protected string queryEnv =
"USE master;" +
"IF DB_ID('WebApiDb') IS NULL" +
"BEGIN" +
"    CREATE DATABASE WebApiDb;" +
"END" +
"GO" +
"IF DB_ID('WebApiDb') IS NOT NULL" +
"BEGIN" +
"    USE WebApiDb;" +
"END" +
"GO" +
"IF OBJECT_ID('dbo.TabCalculation') IS NULL" +
"BEGIN" +
"    CREATE TABLE[dbo].[TabCalculation]" +
"    (" +
"       [id] INT        IDENTITY(1, 1) NOT NULL,"+
"       [Number1]       FLOAT(53) NULL,"+
"       [Number2]       FLOAT(53) NULL,"+
"		[Result]        FLOAT(53) NULL,"+
"		[CreateDate]    DATETIME DEFAULT(GETDATE()) NOT NULL,"+
"       [UpdateDate] DATETIME NOT NULL"+
"	);"+
"END";
    }
}
