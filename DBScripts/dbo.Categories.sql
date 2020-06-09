USE [EasyCommerce]
GO

/****** Object: Table [dbo].[Categories] Script Date: 09-Jun-20 10:19:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Categories];


GO
CREATE TABLE [dbo].[Categories] (
    [CategoryID] INT           NOT NULL,
    [Name]       NVARCHAR (50) NULL
);


