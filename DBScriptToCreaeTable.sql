create Database Products

Use Products

SET ANSI_NULLS ON  
GO  
  
SET QUOTED_IDENTIFIER ON  
GO  
  
SET ANSI_PADDING ON  
GO  
  
CREATE TABLE [dbo].[Items](  
    [ItemID] [int] IDENTITY(1,1) NOT NULL,  
    [ItemName] [varchar](50) NULL,  
    [Description] [varchar](50) NULL,  
	price [float](2) NULL,  
PRIMARY KEY CLUSTERED   
(  
    [ItemID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
  
SET ANSI_PADDING OFF  
GO  


INSERT INTO  dbo.Items values
('Laptop','Dell i7',65000.5),
('Monitor','HP',45000.5),
('Mouse','Dell',1500.75),
('HeadPhones','JBL',15000.0),
('Bluetooth speaker','Boat',1000.5)