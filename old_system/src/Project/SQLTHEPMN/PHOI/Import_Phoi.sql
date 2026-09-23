select * into #T_Phoi from BTPPHOI where Ngaysanxuat >= '20150408' order by Ngaysanxuat


alter table #T_Phoi add Stt VARCHAR(15) NOT NULL DEFAULT('')
alter table #T_Phoi add Stt0 INT NOT NULL DEFAULT(0)
alter table #T_Phoi add So_Ct VARCHAR(20) NOT NULL DEFAULT('')
alter table #T_Phoi add Ma_Vt VARCHAR(20) NOT NULL DEFAULT('')

UPDATE #T_Phoi set Stt = 'A01PHOI'+CONVERT(VARCHAR(11),Ngaysanxuat,112)
UPDATE #T_Phoi set Ma_Vt = T2.Ma_Vt
FROM #T_Phoi T1 JOIN R81DMVT T2 ON T1.Loaiphoi = T2.Loai_Phoi AND T1.Macthep = T2.Mac_Thep 
WHERE T1.Ma_Vt = ''

select * from #T_Phoi where Ma_Vt = ''
drop table #T_Import
SELECT    Stt, Stt0, So_Ct, CAST('02BTP' AS VARCHAR(15)) AS Ma_Kho, ISNULL(T1.Ma_Vt,'') AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat AS Ca_SX, Kyhieume AS So_Me, 
							T1.Loaiphoi AS Loai_Phoi, PHdai4 AS DDai_Phoi, T1.Macthep AS Mac_Thep, 1 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayPHngan AS So_Luong_Cay, KhoiluongPHngan * 1000 AS So_Luong, KhoiluongPHngan * 1000 AS So_Luong9
				INTO #T_Import
				FROM         #T_Phoi T1 LEFT JOIN R81DMVT T2 ON T1.Loaiphoi = T2.Loai_Phoi AND T1.Macthep = T2.Mac_Thep AND T2.Phoi_Ngan = 1
				WHERE SocayPHngan <> 0
				UNION ALL
SELECT   Stt, Stt0, So_Ct, CAST('02BTP' AS VARCHAR(15)) AS Ma_Kho, ISNULL(T1.Ma_Vt,'') AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat AS Ca_SX, Kyhieume AS So_Me, 
							Loaiphoi AS Loai_Phoi, Chieudaiphoi AS DDai_Phoi, Macthep AS Mac_Thep, 0 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayPHdai AS So_Luong_Cay, KhoiluongPHdai* 1000 AS So_Luong, KhoiluongPHdai * 1000 AS So_Luong9
				FROM         #T_Phoi T1 LEFT JOIN R81DMVT T2 ON T1.Loaiphoi = T2.Loai_Phoi AND T1.Macthep = T2.Mac_Thep AND T2.Phoi_Ngan = 0				
				WHERE SocayPHdai <> 0

update #T_Import set SL_Phoi_Nguoi = So_Luong_Cay where  Sl_Phoi_Nong + Sl_Phoi_Tg + Sl_Phoi_Nguoi <> So_Luong_Cay and Sl_Phoi_Nong + Sl_Phoi_Tg = 0
select * from #T_Import where ngay_ct > '20150407' and Sl_Phoi_Nong + Sl_Phoi_Tg + Sl_Phoi_Nguoi <> So_Luong_Cay and Sl_Phoi_Nong + Sl_Phoi_Tg <> 0 order by Ngay_Ct

select * from #T_Import where So_Me = 'L1741'

EXEC sp_GetColumnList 'R80PH'



EXEC sp_GetColumnList 'R05ctnx'


DECLARE @_Stt VARCHAR(15), @_Ngay_Ct DATETIME 

DECLARE C_ZPhanBo CURSOR FOR 
		SELECT Stt, Ngay_Ct FROM #T_Import
OPEN C_ZPhanBo
	
	FETCH NEXT FROM C_ZPhanBo INTO @_Stt, @_Ngay_Ct
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		DECLARE @_Stt0 INT = 0
		UPDATE #T_Import SET @_Stt0 = @_Stt0 + 1, Stt0 = @_Stt0  where sTT = @_Stt
		UPDATE #T_Import SET So_Ct = CAST(DAY(@_Ngay_Ct) AS VARCHAR(2)) + '/04-15PT'  where sTT = @_Stt
		
	FETCH NEXT FROM C_ZPhanBo INTO @_Stt, @_Ngay_Ct
	END
CLOSE C_ZPhanBo
	DEALLOCATE C_ZPhanBo
	
INSERT INTO R80PH ( Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_Giai, Ct_Di_Kem, Ten_Dv_A, Tk_Nh_A, Ten_Nh_A, Ten_Tp_A, So_CMND_A, Ngay_Cap_A, Noi_Cap_A, Ten_Dv_B, Tk_Nh_B, Ten_Nh_B, Ten_Tp_B, So_CMND_B, Ngay_Cap_B, Noi_Cap_B, Duyet, Ngay_Ct_Lap, So_Ct_Lap, Duyet_Log, TTien0, TTien_Nt0, TTien3, TTien_Nt3, TTien4, TTien_Nt4, TTien5, TTien_Nt5, TTien6, TTien_Nt6, Create_Log, LastModify_Log, Ma_DvCs, TSo_Luong, So_Ct_Px, Locked, Is_Thue, Is_Thue_Modify, Pt_Tt, Thanh_Toan, Nhan_Xet, Danh_Gia, De_Xuat, Duyet_TP, Duyet_KTCDAT, Duyet_KHVT, Duyet_GIAMDOC, Duyet_GD, Duyet_Tp_Log, Duyet_KtCdAt_Log, Duyet_KhVt_Log, Duyet_Gd_Log, Duyet_PXCD, Duyet_PXCD_Log, DaiDien_KTCD, DaiDien_KHVT, DaiDien_PbPx, NhanXet_Bb, KienNghi_Bb, Duyet_Huy, Ngay_Huy, User_Huy, Ghi_Chu_Huy, Ghi_Chu_HD, Duyet_KTTC, Duyet_KTTC_Log, So_Ct_Barem)
SELECT  Stt, 'PNSB', Ngay_Ct, So_Ct, 'M1010', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 1, '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', 'A01', SUM(So_Luong), '', 0, 0, 0, '', '', '', '', '', 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', '', '', '', 0, '', '', '', '', 0, 0, ''
FROM #T_Import
GROUP BY Stt, Ngay_Ct, So_Ct

INSERT INTO R05CTNX ( Stt, Stt0, Ma_Nvu, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Ma_Dt, Ong_Ba, Dia_Chi, Dien_Giai, Ma_Kho, Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, Tk_No, Tk_Co, So_Luong9, He_So9, Gia_Nt9, Tien_Nt9, So_Ct0, Ngay_Ct0, So_Seri0, Ma_KhoN, Ma_Bp, Ma_Km, Ma_Hd, Ma_Vt_Sp, Ma_Job, Ma_DDH, Posted, Auto_Cost, Is_DieuChinh, Stt_Org, Ma_DvCs, Create_Log, LastModify_Log, So_Luong_Cay, So_Me, SL_Phoi_Nong, SL_Phoi_TG, SL_Phoi_Nguoi, Loai_Phoi, DDai_Phoi, Mac_Thep, Phoi_Ngan, So_Xe, Ca_SX)
select Stt, Stt0, 'TP02', 'PNSB', Ngay_Ct, So_Ct, 'VND', 1, 'M1010', '', '', '', Ma_Kho, Ma_Vt, 'Kg', So_Luong, 0, 0, 0, 0, '15511', '1542', So_Luong9, 1, 0, 0, '', '', '', '', '', '', '', '', '', '', 1, 1, 0, '', 'A01', '', '', So_Luong_Cay, So_Me, SL_Phoi_Nong, SL_Phoi_TG, SL_Phoi_Nguoi, Loai_Phoi, DDai_Phoi, Mac_Thep, Phoi_Ngan, '', Ca_SX
FROM #T_Import order by Ngay_Ct

UPDATE R05CTNX SET Create_Log = '080415:084525:NINHPS'
WHERE Ngay_Ct >= '20150408' AND Ma_Ct = 'PNSB'
SELECT CREATE_LOG FROM R05CTNX
WHERE Ngay_Ct = '20150407' AND Ma_Ct = 'PNSB'

SELECT * FROM R05CTNX WHERE Ma_Kho = '02cxl'

ALTER TABLE R05CTNXPHOI ADD Ngay_Xu_Ly DATETIME NOT NULL DEFAULT('')

ALTER TABLE R05CTNXPHOI ADD Ma_Vt01 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Ma_Vt02 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Ma_Vt03 VARCHAR(20) NOT NULL DEFAULT('')

ALTER TABLE R05CTNXPHOI ADD DDai_Phoi01 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD DDai_Phoi02 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD DDai_Phoi03 MONEY NOT NULL DEFAULT(0)

ALTER TABLE R05CTNXPHOI ADD So_Luong_Cay01 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD So_Luong_Cay02 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD So_Luong_Cay03 MONEY NOT NULL DEFAULT(0)

ALTER TABLE R05CTNXPHOI ADD So_Luong01 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD So_Luong02 MONEY NOT NULL DEFAULT(0)
ALTER TABLE R05CTNXPHOI ADD So_Luong03 MONEY NOT NULL DEFAULT(0)

ALTER TABLE R05CTNXPHOI ADD Phan_Loai_Phoi01 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Phan_Loai_Phoi02 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Phan_Loai_Phoi03 VARCHAR(20) NOT NULL DEFAULT('')

ALTER TABLE R05CTNXPHOI ADD Ma_Kho01 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Ma_Kho02 VARCHAR(20) NOT NULL DEFAULT('')
ALTER TABLE R05CTNXPHOI ADD Ma_Kho03 VARCHAR(20) NOT NULL DEFAULT('')

ALTER TABLE R80PH ADD Duyet_TCHC BIT NOT NULL DEFAULT (0)
ALTER TABLE R80PH ADD Duyet_TCHC_Log VARCHAR(50) NOT NULL DEFAULT ('')

--------

USE R50THEPMN3
GO

CREATE TABLE [dbo].[R05CTNXPHOI](
	[Ident00] [int] IDENTITY(1,1) NOT NULL,
	[Stt] [varchar](15) NOT NULL,
	[Stt0] [smallint] NOT NULL,
	[Ma_Nvu] [varchar](20) NOT NULL,
	[Ma_Ct] [varchar](5) NOT NULL,
	[Ngay_Ct] [date] NOT NULL,
	[So_Ct] [varchar](20) NOT NULL,
	[Ma_Tte] [varchar](5) NOT NULL,
	[Ty_Gia] [money] NOT NULL,
	[Ma_Dt] [varchar](20) NOT NULL,
	[Ong_Ba] [nvarchar](100) NOT NULL,
	[Dia_Chi] [nvarchar](100) NOT NULL,
	[Dien_Giai] [nvarchar](200) NOT NULL,
	[Ma_Kho] [varchar](20) NOT NULL,
	[Ma_Vt] [varchar](20) NOT NULL,
	[Dvt] [nvarchar](10) NOT NULL,
	[So_Luong] [money] NOT NULL,
	[Gia] [money] NOT NULL,
	[Gia_Nt] [money] NOT NULL,
	[Tien] [money] NOT NULL,
	[Tien_Nt] [money] NOT NULL,
	[Tk_No] [varchar](10) NOT NULL,
	[Tk_Co] [varchar](10) NOT NULL,
	[So_Luong9] [money] NOT NULL,
	[He_So9] [money] NOT NULL,
	[Gia_Nt9] [money] NOT NULL,
	[Tien_Nt9] [money] NOT NULL,
	[So_Ct0] [varchar](20) NOT NULL,
	[Ngay_Ct0] [date] NOT NULL,
	[So_Seri0] [varchar](20) NOT NULL,
	[Ma_KhoN] [varchar](20) NOT NULL,
	[Ma_Bp] [varchar](20) NOT NULL,
	[Ma_Km] [varchar](20) NOT NULL,
	[Ma_Hd] [varchar](50) NOT NULL,
	[Ma_Vt_Sp] [varchar](20) NOT NULL,
	[Ma_Job] [varchar](20) NOT NULL,
	[Posted] [bit] NOT NULL,
	[Auto_Cost] [bit] NOT NULL,
	[Stt_Org] [varchar](15) NOT NULL,
	[Ma_DvCs] [varchar](3) NOT NULL,
	[Create_Log] [varchar](35) NOT NULL,
	[LastModify_Log] [varchar](35) NOT NULL,
	[So_Luong_Cay] [money] NOT NULL,
	[So_Me] [varchar](15) NOT NULL,
	[SL_Phoi_Nong] [money] NOT NULL,
	[SL_Phoi_TG] [money] NOT NULL,
	[SL_Phoi_Nguoi] [money] NOT NULL,
	[Loai_Phoi] [varchar](10) NOT NULL,
	[DDai_Phoi] [money] NOT NULL,
	[Mac_Thep] [varchar](10) NOT NULL,
	[Phoi_Ngan] [bit] NOT NULL,
	[Ca_SX] [varchar](5) NOT NULL,
	[Xuat_Phoi_Nguoi] [bit] NOT NULL,
	[DDai_Phoi_Ngan] [money] NOT NULL,
	[Ma_Dt_CbNv] [varchar](20) NOT NULL,
	[Ghi_Chu] [nvarchar](100) NOT NULL,
	[Han_Tt] [int] NOT NULL,
	[Phan_Loai_Phoi] [varchar](20) NOT NULL,
	[Is_Tang_Me] [bit] NOT NULL,
	
 CONSTRAINT [PK__R05CTNXPHOI__352AA1BB58A712EB] PRIMARY KEY CLUSTERED 
(
	[Ident00] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[R05CTNXPHOI]  WITH CHECK ADD  CONSTRAINT [FK__R05CTNXPHOI__Ma_Ct__039170F0] FOREIGN KEY([Ma_Ct])
REFERENCES [dbo].[R00DMCT] ([Ma_Ct])
GO

ALTER TABLE [dbo].[R05CTNXPHOI] CHECK CONSTRAINT [FK__R05CTNXPHOI__Ma_Ct__039170F0]
GO

ALTER TABLE [dbo].[R05CTNXPHOI]  WITH CHECK ADD  CONSTRAINT [FK__R05CTNXPHOI__Ma_DvCs__029D4CB7] FOREIGN KEY([Ma_DvCs])
REFERENCES [dbo].[R00DMDVCS] ([Ma_DvCs])
GO

ALTER TABLE [dbo].[R05CTNXPHOI] CHECK CONSTRAINT [FK__R05CTNXPHOI__Ma_DvCs__029D4CB7]
GO
-------

EXEC SP_GETCOLUMNLIST 'R05CTNXPHOI'

INSERT INTO R05CTNXPHOI( Stt, Stt0, Ma_Nvu, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Ma_Dt, Ong_Ba, Dia_Chi, Dien_Giai, Ma_Kho, Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, Tk_No, Tk_Co, So_Luong9, He_So9, Gia_Nt9, Tien_Nt9, So_Ct0, Ngay_Ct0, So_Seri0, Ma_KhoN, Ma_Bp, Ma_Km, Ma_Hd, Ma_Vt_Sp, Ma_Job, Posted, Auto_Cost, Stt_Org, Ma_DvCs, Create_Log, LastModify_Log, So_Luong_Cay, So_Me, SL_Phoi_Nong, SL_Phoi_TG, SL_Phoi_Nguoi, Loai_Phoi, DDai_Phoi, Mac_Thep, Phoi_Ngan, Ca_SX, Xuat_Phoi_Nguoi, DDai_Phoi_Ngan, Ma_Dt_CbNv, Ghi_Chu, Han_Tt, Phan_Loai_Phoi, Is_Tang_Me)
SELECT  Stt, Stt0, Ma_Nvu, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Ma_Dt, Ong_Ba, Dia_Chi, Dien_Giai, Ma_Kho, Ma_Vt, Dvt, So_Luong, Gia, Gia_Nt, Tien, Tien_Nt, Tk_No, Tk_Co, So_Luong9, He_So9, Gia_Nt9, Tien_Nt9, So_Ct0, Ngay_Ct0, So_Seri0, Ma_KhoN, Ma_Bp, Ma_Km, Ma_Hd, Ma_Vt_Sp, Ma_Job, Posted, Auto_Cost, Stt_Org, Ma_DvCs, Create_Log, LastModify_Log, So_Luong_Cay, So_Me, SL_Phoi_Nong, SL_Phoi_TG, SL_Phoi_Nguoi, Loai_Phoi, DDai_Phoi, Mac_Thep, Phoi_Ngan, Ca_SX, Xuat_Phoi_Nguoi, DDai_Phoi_Ngan, Ma_Dt_CbNv, Ghi_Chu, Han_Tt, Phan_Loai_Phoi, Is_Tang_Me
FROM R05CTNX 
WHERE Ma_Ct IN ('PNSB', 'PXSB')

SELECT * INTO PHOI_TAM FROM R05CTNX WHERE Ma_Ct IN ('PNSB', 'PXSB')

DELETE FROM R05CTNX WHERE Ma_Ct IN ('PNSB', 'PXSB')



