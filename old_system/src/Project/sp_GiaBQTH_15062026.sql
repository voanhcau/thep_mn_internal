use R50THEPMN3
go
/*
	SET DATEFORMAT DMY
*/
ALTER PROCEDURE [dbo].[sp_GiaBQTH]
(
	@Ngay_Ct1 DATE,
	@Ngay_Ct2 DATE,
	@Ma_Kho_List VARCHAR(4000) = '',
	@Ma_Vt VARCHAR(20) = '',
	@Ma_Kho VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V', 
	@Ma_DvCs VARCHAR(5)= 'A01'
)
--WITH ENCRYPTION
AS
BEGIN
	DECLARE @_SQLExec VARCHAR(MAX),
			@_Kho_List VARCHAR(4000) = '0 = 0 AND (Ma_Vt <> '''')',
			@_Key VARCHAR(4000) = ''

	
	IF (@Ma_Vt <> '')
		SET @_Kho_List = @_Kho_List + ' AND (Ma_Vt = ''' + @Ma_Vt + ''')'
	
	--tạo d
	SELECT String AS Ma_Kho INTO #T_DsKhoList0 
			FROM dbo.fn_Split(@Ma_Kho_List) OPTION (MAXRECURSION 1000)
	
	IF(@Ma_Kho_List <> '')
	BEGIN
		IF(charindex(',',@Ma_Kho_List) =0)
		SET @_Kho_List = @_Kho_List + ' AND (Ma_Kho LIKE ''' + @Ma_Kho_List + ''')'
		ELSE IF(charindex(',',@Ma_Kho_List) > 0 AND LEN(@Ma_Kho_List) < 100)
			SET @_Kho_List = @_Kho_List + ' AND (Ma_Kho LIKE ''' + REPLACE(@Ma_Kho_List, ',', '%'' OR Ma_Kho LIKE ''') + '%'')'
		ELSE
			SET @_Kho_List = @_Kho_List + 'AND Ma_Kho IN ('''+REPLACE(@Ma_Kho_List, ',',''',''')+''')'
	END
	--SELECT @_Kho_List RETURN
	
	--1 Lấy tồn kho dk

	--Tồn kho đầu
	SELECT Ma_Kho, Ma_Vt, Ton_Dau, Du_Dau, 
		CAST(0 AS MONEY) AS Sl_Nhap, CAST(0 AS MONEY) AS Tien_Nhap
		INTO #T_T1
		FROM R80SDV
		WHERE 0 = 1
	EXEC sp_DefaultTable '#T_T1'
	
	--LẤY TỒN ĐẨU THÁNG
	EXEC sp_TonDauList @Ngay_Ct1, @_Kho_List, '#T_T1', @Ma_DvCs
	
	--2. lấy DL nhập kho
	select Loai_Ct, Stt, Stt0, Auto_Cost, Ma_Ct, Ma_Kho, Ma_Vt, So_Luong, Tien, Tien_Nt,
		GIA, Gia_Nt
		into #t_TheKho FROM vw_TheKho where 0 = 1
	set @_Key = @_Kho_List + ' AND Loai_Ct = ''1'''
	
	exec sp_ScanTableTheKho @Ngay_Ct1, @Ngay_Ct2, @_Key, '#t_TheKho', @Ma_DvCs
	--select * from #t_TheKho where ma_vt = 'BD10021170'
	INSERT INTO #T_T1(Ma_Kho, Ma_Vt, Ton_Dau, Du_Dau, Sl_Nhap, Tien_Nhap)
	SELECT Ma_Kho, Ma_Vt, 0, 0, So_Luong, Tien 
		FROM #t_TheKho WHERE Loai_Ct = '1' --and  
		--Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2 --and Ma_Kho <> ''
		--and Ma_Kho in (select Ma_Kho from #T_DsKhoList0)
	--INSERT INTO #T_T1(Ma_Kho, Ma_Vt, Ton_Dau, Du_Dau, Sl_Nhap, Tien_Nhap)
	--SELECT Ma_Kho, Ma_Vt, 0, 0, So_Luong, Tien 
	--	FROM R02CTNM WHERE Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2 and Ma_Kho <> ''
	--	and Ma_Kho in (select Ma_Kho from #T_DsKhoList0)
	--	and Tk_No like '15%'
	--INSERT INTO #T_T1(Ma_Kho, Ma_Vt, Ton_Dau, Du_Dau, Sl_Nhap, Tien_Nhap)
	--SELECT Ma_Kho, Ma_Vt, 0, 0, So_Luong, Tien 
	--	FROM R05CTNX WHERE Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2 and Ma_Kho <> ''
	--	and Ma_Kho in (select Ma_Kho from #T_DsKhoList0)
	--	and Tk_No like '15%'
	--INSERT INTO #T_T1(Ma_Kho, Ma_Vt, Ton_Dau, Du_Dau, Sl_Nhap, Tien_Nhap)
	--SELECT Ma_KhoN, Ma_Vt, 0, 0, So_Luong, Tien 
	--	FROM R05CTNX WHERE Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2 and Ma_Kho <> ''
	--	and Ma_KhoN in (select Ma_Kho from #T_DsKhoList0)
	--	and Tk_No like '15%'
	
	--3. tính giá TB
	select Ma_Kho, Ma_Vt, sum(Du_Dau) + sum(Tien_Nhap) as Tien,
		sum(Ton_Dau) + sum(Sl_Nhap) as SL, cast(0 as money) as Gia_Tb into #T_GiaTb 
		from #T_T1 group by Ma_Kho, Ma_Vt
	
	DELETE FROM #T_GiaTb WHERE Tien = 0 AND SL = 0
	update #T_GiaTb set Gia_Tb = Tien/SL where SL > 0
	--SELECT * FROM #T_GiaTb RETURN
	--select * from #T_GiaTb where ma_vt = 'BD10021170' return
		
		--select * from  #T_GiaTb where ma_vt ='A00230023' return
	--4. cập nhật giá xuất
	ALTER TABLE R02CtNM DISABLE TRIGGER ALL
	ALTER TABLE R04CtHD DISABLE TRIGGER ALL
	ALTER TABLE R05CtNX DISABLE TRIGGER ALL
	ALTER TABLE R80PH DISABLE TRIGGER ALL
	
	UPDATE T1 SET Gia = T2.Gia_Tb, Gia_Nt = T2.Gia_Tb, Gia_Nt9 = T2.Gia_Tb,
		TIEN = So_Luong * T2.Gia_Tb, Tien_Nt = So_Luong * T2.Gia_Tb, 
		Tien_Nt9 = So_Luong * T2.Gia_Tb
		FROM R04CTHD T1 JOIN #T_GiaTb T2 ON T1.Ma_Kho = T2.Ma_Kho AND T1.Ma_Vt = T2.Ma_Vt
		WHERE Auto_Cost = 1 AND Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2 
		AND (TK_CO LIKE '15%')
	
	UPDATE T1 SET Gia = T2.Gia_Tb, Gia_Nt = T2.Gia_Tb, Gia_Nt9 = T2.Gia_Tb,
		TIEN = So_Luong * T2.Gia_Tb, Tien_Nt = So_Luong * T2.Gia_Tb, 
		Tien_Nt9 = So_Luong * T2.Gia_Tb
		FROM R05CTNX T1 JOIN #T_GiaTb T2 ON T1.Ma_Kho = T2.Ma_Kho AND T1.Ma_Vt = T2.Ma_Vt
		WHERE Auto_Cost = 1 AND Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2
		AND (TK_CO LIKE '152%' OR TK_CO LIKE '155%')
	
	UPDATE R80PH SET	
				TTien0 = T2.Tien,
				TTien_Nt0 = T2.Tien_Nt
			FROM R80PH T1 JOIN
				(SELECT Stt, ISNULL(SUM(Tien), 0) AS Tien, ISNULL(SUM(Tien_Nt), 0) AS Tien_Nt 
					FROM R05CTNX
					WHERE Auto_Cost = 1 AND Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2
					GROUP BY Stt) T2
			ON T1.Stt = T2.Stt	
	
	--5. xử lý hết lượng còn tiền
	--Tồn kho đầu
	SELECT Ma_Kho, Ma_Vt, Ton_Dau as Ton_cuoi, Du_Dau AS Du_Cuoi,
					CAST('' AS VARCHAR(30)) AS Stt_Stt0
		INTO #T_T2
		FROM R80SDV
		WHERE 0 = 1

	EXEC sp_DefaultTable '#T_T2'
	
	--LẤY TỒN cuối THÁNG
	EXEC sp_TonCuoiList_GiaBQTT @Ngay_Ct2, @_Kho_List, '#T_T2', @Ma_DvCs
	
	select Ma_Kho, Ma_Vt, Ton_cuoi, Du_Cuoi, Stt_Stt0, CAST('' AS VARCHAR(20)) AS Ma_Ct,
		cast('' AS varchar(20)) as Stt, cast('' AS int) as Stt0
	into #T_T3 from #T_T2 where Ton_cuoi = 0 and Du_Cuoi <> 0
	UPDATE #T_T3 set Stt = t2.Stt, Stt0 = t2.Stt0, Ma_Ct = t2.Ma_Ct
		from #T_T3 T1 JOIN (SELECT ma_ct, stt, Stt0, stt+replace(str(sTT0,5),' ','') as Stt_Stt0 
			from vw_TheKho WHERE Ngay_Ct >= @Ngay_Ct1 and Ngay_Ct <= @Ngay_Ct2) T2 ON T1.Stt_Stt0 = t2.Stt_Stt0
	
	IF(EXISTS(select * from #T_T3))
	BEGIN
		update T1 SET Tien = T1.Tien + T2.Du_Cuoi, Tien_Nt = T1.Tien_Nt + T2.Du_Cuoi
			FROM R04CTHD T1 JOIN #T_T3 T2 ON T1.Stt = T2.Stt  AND T1.STT0 = T2.Stt0 
			AND T1.MA_CT = T2.Ma_Ct AND Auto_Cost = 1
	
		update T1 SET Tien = T1.Tien + T2.Du_Cuoi, Tien_Nt = T1.Tien_Nt + T2.Du_Cuoi
			FROM R05CTNX T1 JOIN #T_T3 T2 ON T1.Stt = T2.Stt  AND T1.STT0 = T2.Stt0 
			AND T1.MA_CT = T2.Ma_Ct AND Auto_Cost = 1
			AND (TK_CO LIKE '152%' OR TK_CO LIKE '155%')

		UPDATE R80PH SET	
				TTien0 = TTien0 + T3.Du_Cuoi,
				TTien_Nt0 = TTien_Nt0 + T3.Du_Cuoi
			FROM R80PH T1 --JOIN
			--	(SELECT Stt, ISNULL(SUM(Tien), 0) AS Tien, ISNULL(SUM(Tien_Nt), 0) AS Tien_Nt 
			--		FROM R05CTNX
			--		WHERE Auto_Cost = 1 AND Ngay_Ct >= @Ngay_Ct1 AND Ngay_Ct <= @Ngay_Ct2) T2
			--ON T1.Stt = T2.Stt
				JOIN #T_T3 T3 ON T1.Stt = T3.Stt
	END
	ALTER TABLE R02CtNM ENABLE TRIGGER ALL
	ALTER TABLE R04CtHD ENABLE TRIGGER ALL
	ALTER TABLE R05CtNX ENABLE TRIGGER ALL
	ALTER TABLE R80PH ENABLE TRIGGER ALL
	--6. xóa bảng tạm
	drop table #t_TheKho
	drop table #T_T1
	drop table #T_T2
	drop table #T_T3
	drop table #T_GiaTb
	drop table #T_DsKhoList0
END

go
 --exec [dbo].[sp_GiaBQTH] '20260501','20260531', ''-- '022OXY' --9s
--'04TP' --3s
--'055POM1' --2s
--'052TMN' -- 4s
--'051CT,051D2,051NT,051P2' --3s
--'06BN,06CH,06CHBL1,06CHBL2,06CHCM,06CHCM1,06CHKG1,06CHLA1,06CHNT1,06CHTG1,06CHTV1,06CHTV2,06CHVL1,06CHVL2,06CKTG,06CKTGAG1,06CKTGCM1,06CKTGCT1,06CKTGCT2,06CKTGST1,06CL,06CNKK3,06CTN,06DT,06FICO,06HCM2,06HCM2AG1,06HCM2AG2,06HCM2AG3,06HCM2CM1,06HCM2CM2,06HCM2CT1,06HCM2CT2,06HCM2CT3,06HCM2CT4,06HCM2CT5,06HCM2KG1,06HCM2KG2,06HCM2KG3,06HCM2LA2,06HCM2LA3,06HCM2LA4,06HCM2LA5,06HCM2ST1,06HCM2ST2,06HCM3,06HCM4LA,06HCMLD,06HG,06HGBL,06HGCT,06HGCT2,06HGPQ,06HOSA,06HOSA1,06HOSA10,06HOSA11,06HOSA12,06HOSA2,06HOSA3,06HOSA4,06HOSA5,06HOSA6,06HOSA7,06HOSA8,06HOSA9,06HS,06HSVL,06HTLD,06HUTH,06HUTH1,06HUTH2,06HUTH3,06HUTH4,06HUTH5,06INDECO,06KH,06LKDN10,06LKDN12,06LKDN13,06LKDN9,06LKHCM1,06LKHCM11,06LKHCM2,06LKHCM3,06LKHCM4,06LKHCM5,06LKHCM6,06LKHCM7,06LKHCM8,06LTB,06MTG,06MTGDL,06MTGNT,06NAD,06NBAO,06PHG,06PHSDAG,06PHSDCT,06PHSDDT1,06PHSDDT2,06PHSDVL1,06PHSDVL2,06PHSDVL3,06PNKGKG1,06PNKGKG2,06PT,06PTBL1,06PTBT1,06PTNT1,06PTNT2,06PTNT3,06PTNT4,06PTNT5,06PTNT6,06PTNT7,06PTNT8,06PTNT9,06PTTG1,06QTBL1,06QTDT2,06QTHCM1,06QTKG1,06QTKG2,06QTLA1,06QTST1,06QTVL1,06SIMCO,06SLHCM1,06SLHCM2,06SLLA1,06SLTN,06SM,06SMCBC1,06SMCBR1,06SMCBTR1,06SMCBTR2,06SMCCM1,06SMCCM2,06SMCCT1,06SMCCT2,06SMCDT1,06SMCDT2,06SMCDT3,06SMCDT4,06SMCDT5,06SMCDT6,06SMCDT7,06SMCKG1,06SMCLA1,06SMCLA2,06SMCST1,06SMCTN1,06SMCVL1,06SMCVL2,06TD,06TDAG1,06TDBL1,06TDBT1,06TDBT2,06TDBT3,06TDCT1,06TDCT3,06TDCT4,06TDCT5,06TDDT1,06TDDT2,06TDDT3,06TDKG1,06TDKG2,06TDKG3,06TDKG4,06TDLA1,06TDTG1,06TDTV1,06TDTV2,06TDVL1,06TDVL2,06TH,06THP,06THPAG1,06THPBL1,06THPBT1,06THPCM1,06THPCT1,06THPDN1,06THPHCM1,06THPLA1,06THPTG1,06THPTG2,06THPTG3,06TKCM1,06TKCM2,06TKCM3,06TLLD1,06TLLD2,06TLLD3,06TONG1,06TP,06TP1,06TSCM1,06TT,06VA,06XTDN1'
--10s