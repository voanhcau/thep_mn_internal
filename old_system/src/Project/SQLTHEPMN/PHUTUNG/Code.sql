USE [R50THEPMN3_2016_03_17]
GO

/****** Object:  Table [dbo].[R81DMBARCODEPT]    Script Date: 03/30/2016 08:07:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[R81DMBARCODEPT](
	[Barcode] [varchar](20) NOT NULL,
	[Ma_Vt] [varchar](20) NULL,
	[Ngay_Ct_Nhap] [datetime] NULL,
	[Ngay_Ct_Xuat] [datetime] NULL,
	[Create_Log] [varchar](50) NULL,
	[LastModify_Log] [varchar](50) NULL,
	[Ma_Data] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Barcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[R81DMBARCODEPT] ADD  DEFAULT ('') FOR [Barcode]
GO


