USE [EasyCommerce]
GO

/****** Object: Table [dbo].[Products] Script Date: 09-Jun-20 10:19:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Products];


GO
CREATE TABLE [dbo].[Products] (
    [ProductID]    INT            NOT NULL,
    [Code]         NVARCHAR (50)  NULL,
    [ProductName]  NVARCHAR (100) NULL,
    [CategoryID]   INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL
);


