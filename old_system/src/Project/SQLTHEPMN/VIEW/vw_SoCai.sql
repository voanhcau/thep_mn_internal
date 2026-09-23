SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vw_SoCai]
WITH ENCRYPTION
AS
	SELECT	Stt, Stt0, Stt_Nvu, Ma_Nvu, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Ong_Ba, Dien_Giai, Tk_No AS Tk, Tk_Co AS Tk_Du, Ma_Dt_No AS Ma_Dt, Ma_Dt_Co AS Ma_Dt_Du, 
			Ma_Vt_Sp_No AS Ma_Vt_Sp, Ma_Vt_Sp_Co AS Ma_Vt_Sp_Du, Tien AS Ps_No, Tien_Nt AS Ps_No_Nt, CAST(0 AS MONEY) AS Ps_Co, CAST(0 AS MONEY) AS Ps_Co_Nt, So_Luong, Gia,
			Ma_Bp_No AS Ma_Bp, Ma_Bp_Co AS Ma_Bp_Du, Ma_Km_No AS Ma_Km, Ma_Km_Co AS Ma_Km_Du, Ma_Hd_No AS Ma_Hd, Ma_Hd_Co AS Ma_Hd_Du, Ma_Job, 
			Ma_Vt, Ma_Kho, Ma_Kv, Ma_Dt_CbNv, Ma_Thue, Ngay_Ct0, So_Ct0, So_Seri0, Is_CLTG, Han_Tt, Is_UngTruoc, Ma_DvCs
		FROM dbo.vw_SoCai0 AS T1
		UNION
		SELECT Stt, Stt0, Stt_Nvu, Ma_Nvu, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Ong_Ba, Dien_Giai, Tk_Co AS Tk, Tk_No AS Tk_Du, Ma_Dt_Co AS Ma_Dt, Ma_Dt_No AS Ma_Dt_Du, 
				Ma_Vt_Sp_Co AS Ma_Vt_Sp, Ma_Vt_Sp_No AS Ma_Vt_Sp_Du, 0 AS Ps_No, 0 AS Ps_No_Nt, Tien AS Ps_Co, Tien_Nt AS Ps_Co_Nt, So_Luong, Gia,
				Ma_Bp_Co AS Ma_Bp, Ma_Bp_No AS Ma_Bp_Du, Ma_Km_Co AS Ma_Km, Ma_Km_No AS Ma_Km_Du, Ma_Hd_Co AS Ma_Hd, Ma_Hd_No AS Ma_Hd_Du, Ma_Job, 
				Ma_Vt, Ma_Kho, Ma_Kv, Ma_Dt_CbNv, Ma_Thue, Ngay_Ct0, So_Ct0, So_Seri0, Is_CLTG, Han_Tt, Is_UngTruoc, Ma_DvCs
		FROM dbo.vw_SoCai0 AS T2

