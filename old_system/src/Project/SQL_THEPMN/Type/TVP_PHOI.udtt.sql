CREATE TYPE [dbo].[TVP_PHOI] AS TABLE 
(
	[Chon] [bit] NULL,
	[Ngaysanxuat] [datetime] NULL,
	[Casanxuat] [varchar](5) NULL,
	[Kyhieume] [varchar](10) NULL,
	[Loaiphoi] [varchar](20) NULL,
	[Chieudaiphoi] [money] NULL,
	[Macthep] [varchar](15) NULL,
	[Tongsocay] [int] NULL,
	[Tongkhoiluong] [money] NULL,
	[Socaynapnong] [int] NULL,
	[Socaynaptrunggian] [int] NULL,
	[Socayrabai] [int] NULL,
	[SocayPHdai] [int] NULL,
	[KhoiluongPHdai] [money] NULL,
	[SocayPHngan] [int] NULL,
	[KhoiluongPHngan] [money] NULL,
	[SocayCXL] [int] NULL,
	[KhoiluongCXL] [money] NULL,
	[SocayKPH] [int] NULL,
	[KhoiluongKPH] [money] NULL
)