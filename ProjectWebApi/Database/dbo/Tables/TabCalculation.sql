CREATE TABLE [dbo].[TabCalculation] (
    [id]         INT        IDENTITY (1, 1) NOT NULL,
    [Number1]    FLOAT (53) NULL,
    [Number2]    FLOAT (53) NULL,
    [Result]     FLOAT (53) NULL,
    [CreateDate] DATETIME   DEFAULT (getdate()) NOT NULL,
    [UpdateDate] DATETIME   NOT NULL
);