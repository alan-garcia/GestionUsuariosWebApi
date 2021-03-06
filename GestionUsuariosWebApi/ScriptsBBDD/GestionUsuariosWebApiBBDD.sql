CREATE DATABASE [GestionUsuariosWebApi]
GO
USE [GestionUsuariosWebApi]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04/03/2021 12:36:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[balance] [decimal](12, 4) NULL,
	[date] [datetime2](7) NULL,
	[username] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Balance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [balance], [date], [username]) VALUES (4, CAST(425.8800 AS Decimal(12, 4)), CAST(N'2021-02-21T09:26:11.4930000' AS DateTime2), N'jose')
INSERT [dbo].[User] ([id], [balance], [date], [username]) VALUES (5, CAST(812.0000 AS Decimal(12, 4)), CAST(N'2021-03-04T11:26:13.0110000' AS DateTime2), N'manuel')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
