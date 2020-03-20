USE[BikeStores2]
GO

/****** Create Object:  Table [dbo].[InvoiceDocuments] ******/  
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [sales].[InvoiceDocuments](
	[invoice_id] [int] IDENTITY(1,1) NOT NULL,
	[invoice_PO] [nvarchar](max) NULL,
	[invoice_document] [varbinary](max) NULL,
	[invoice_MIME] [nvarchar](100) NULL,
 CONSTRAINT [PK_InvoiceDocuments] PRIMARY KEY CLUSTERED 
(
	[invoice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



/****** Create Object:  StoredProcedure [dbo].[spGetetAllFiles] ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
 
CREATE PROCEDURE [dbo].[spGetetAllFiles]  
 
AS  
BEGIN  

 SELECT [invoice_id]
		,[invoice_PO]
		,[invoice_document]
		,[invoice_MIME]
 FROM  [sales].[InvoiceDocuments]
END  
  
GO  



/****** Create Object:  StoredProcedure [dbo].[spGetFileDetails]   ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  

CREATE PROCEDURE [dbo].[spGetFileDetails]   
 @invoice_id INT  
AS  
BEGIN  

 SELECT [invoice_id]
		,[invoice_PO]
		,[invoice_MIME]
		,[invoice_document]
 FROM [sales].[InvoiceDocuments]
 WHERE [InvoiceDocuments].[invoice_id] = @invoice_id  
END  
  
GO  


/****** Create Object:  StoredProcedure [dbo].[spAddFile]   ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  

CREATE PROCEDURE [dbo].[spAddFile]  
 @invoice_PO NVARCHAR(MAX),  
 @invoice_MIME NVARCHAR(100),  
 @invoice_document VARBINARY(MAX)
AS  
BEGIN  

 INSERT INTO [sales].[InvoiceDocuments]
           ([invoice_PO]
           ,[invoice_MIME]
           ,[invoice_document])  
     VALUES  
           (@invoice_PO  
           ,@invoice_MIME  
           ,@invoice_document)  
END