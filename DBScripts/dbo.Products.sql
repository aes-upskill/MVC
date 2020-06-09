CREATE TABLE [dbo].[Products] (
    [ProductID]    INT            NOT NULL IDENTITY,
    [Code]         NVARCHAR (50)  NULL,
    [ProductName]  NVARCHAR (100) NULL,
    [CategoryID]   INT            NULL,
    [CreatedDate]  DATETIME       DEFAULT (GETUTCDATE()) NULL,
    [ModifiedDate] DATETIME       DEFAULT (GETUTCDATE()) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

