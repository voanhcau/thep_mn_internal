USE R50THEPMN

ALTER TABLE R04CTSO ADD Mo_Ta_Kt NVARCHAR(100) NOT NULL DEFAULT ('')
ALTER TABLE R04CTSO ADD Ngay_Tt_Truoc DATETIME NOT NULL DEFAULT ('')
ALTER TABLE R04CTSO ADD Ngay_DkTt DATETIME NOT NULL DEFAULT ('')
ALTER TABLE R04CTSO ADD Muc_Dich NVARCHAR(100) NOT NULL DEFAULT ('')

ALTER TABLE R04CTSO ADD So_Luong_Ton MONEY NOT NULL DEFAULT (0)
ALTER TABLE R04CTSO ADD So_Luong_LD MONEY NOT NULL DEFAULT (0)
ALTER TABLE R04CTSO ADD So_Luong_DP MONEY NOT NULL DEFAULT (0)
ALTER TABLE R04CTSO ADD Stt_Org VARCHAR(15) NOT NULL DEFAULT ('')

ALTER TABLE R04CTSO ADD So_Luong0 MONEY NOT NULL DEFAULT (0)

ALTER TABLE R04CSGIA ADD Loai_Cs CHAR(1) NOT NULL DEFAULT ('')
ALTER TABLE R04CTSO ADD Ma_Dt_Mh VARCHAR(20) NOT NULL DEFAULT ('')

ALTER TABLE R04CTSO ADD So_Luong_KtCdAt MONEY NOT NULL DEFAULT (0)
ALTER TABLE R04CTSO ADD Vi_Tri_Sd NVARCHAR(100) NOT NULL DEFAULT ('')

INSERT INTO R00ZONE(Zone, Zone_Parent, Resize_Rate, Sortable, Description, Expand) VALUES(N'DMDTMH', N'LISTS', 0, 1, N'Đối tượng mua hàng', 0)

INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'DVT', 60, N'T', 0, 1, N'Đvt', 5, N'3', 1, 0)
INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'GIA', 100, N'N', 0, 1, N'Giá vốn', 6, N'3', 1, 0)
INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'MA_DT_MH', 100, N'T', 0, 1, N'Mã đối tượng mua hàng', 1, N'3', 1, 0)
INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'MA_VT', 100, N'T', 0, 1, N'Mã tài sản', 3, N'3', 1, 0)
INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'TEN_DT', 200, N'T', 0, 1, N'Tên đối tượng', 2, N'3', 1, 0)
INSERT INTO R00COLUMN(Zone, Column_ID, Width, Type, Scale, Resizable, Description, Stt, Show_Type, Visible, Is_Customize) VALUES(N'DMDTMH', N'TEN_VT', 100, N'T', 0, 1, N'Mặt hàng', 4, N'3', 1, 0)


INSERT INTO R00LOOKUP(ColumnID, Table_Lookup, Table_Alias, ColumnID_Lookup, ColumnName_Lookup, Assembly) VALUES(N'MA_DT_MH', N'VW_DMDT_MH', N'DMDTMH', N'MA_DT_MH', N'TEN_DT', N'Rosy.List:RosyList.frmDmDt_Ncc')


create VIEW [dbo].[vw_DmDt_Mh]
as

WITH CSGiaMax AS
	(
		SELECT Ma_Dt, Ma_Vt, MAX(Ngay_Ap) AS Ngay_Ap_Max
			FROM R04CSGIA WITH (NOLOCK)
			GROUP BY Ma_Dt, Ma_Vt
	)
SELECT T1.Ma_Dt AS Ma_Dt_Mh, T3.Ten_Dt, T1.Ma_Vt, T4.Ten_Vt, T1.Gia, T1.Ngay_Ap
FROM R04CSGIA T1 JOIN CSGiaMax T2 ON T1.Ma_Dt = T2.Ma_Dt AND T1.Ma_Vt = T2.Ma_Vt AND T1.Ngay_Ap = T2.Ngay_Ap_Max
				 LEFT JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt
				 LEFT JOIN R81DMVT T4 ON T1.Ma_Vt  = T4.Ma_Vt


GO
select Ghi_Chu from r04ctso

ALTER TABLE R80PH ADD Duyet_Tp BIT NOT NULL DEFAULT(0)
ALTER TABLE R80PH ADD Duyet_KtCdAt BIT NOT NULL DEFAULT(0)
ALTER TABLE R80PH ADD Duyet_KhVt BIT NOT NULL DEFAULT(0)
ALTER TABLE R80PH ADD Duyet_GiamDoc BIT NOT NULL DEFAULT(0)
