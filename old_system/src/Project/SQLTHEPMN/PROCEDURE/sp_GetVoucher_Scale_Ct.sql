/*Thủ tục trả về bảng Filter
--EXEC sp_GetPH_Scale_Truck_Out 'PXTH', '20150101','20151231', 1
*/
ALTER PROCEDURE [dbo].[sp_GetVoucher_Scale_Ct]
(
	@Ma_Ct VARCHAR(5) = '',
	@Stt VARCHAR(15) = ''
)
AS
BEGIN	

	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	SET @_Key = @_Key + ' AND Stt = ''' + @Stt + ''''
	SET @_Key = @_Key + ' AND Ma_Ct = ''' + @Ma_Ct + ''''
	
	CREATE TABLE #T_Detail0(Stt VARCHAR(15))

	SET @_SQLExec =
		'SELECT Stt
			FROM R05CTX_BARCODE WITH(NOLOCK)
			WHERE ' + @_Key + '
			GROUP BY Stt'
	
	INSERT #T_Detail0(Stt)
	EXEC(@_SQLExec)

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ten_Size') IS NULL
		ALTER TABLE #T_Detail0 ADD Ten_Size NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Grade_ID') IS NULL
		ALTER TABLE #T_Detail0 ADD Grade_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Grade_Name') IS NULL
		ALTER TABLE #T_Detail0 ADD Grade_Name NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Standard_ID') IS NULL
		ALTER TABLE #T_Detail0 ADD Standard_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Standard_Name') IS NULL
		ALTER TABLE #T_Detail0 ADD Standard_Name NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ma_CL') IS NULL
		ALTER TABLE #T_Detail0 ADD Ma_CL VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ten_CL') IS NULL
		ALTER TABLE #T_Detail0 ADD Ten_CL NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ma_Ca') IS NULL
		ALTER TABLE #T_Detail0 ADD Ma_Ca VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ca') IS NULL
		ALTER TABLE #T_Detail0 ADD Ca NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Ngay_Nhap') IS NULL
		ALTER TABLE #T_Detail0 ADD Ngay_Nhap DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Detail0', 'Num_Lot') IS NULL
		ALTER TABLE #T_Detail0 ADD Num_Lot VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail0', 'So_Luong_Barcode') IS NULL
		ALTER TABLE #T_Detail0 ADD So_Luong_Barcode MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail0', 'Num_Bars_Barcode') IS NULL
		ALTER TABLE #T_Detail0 ADD Num_Bars_Barcode MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail0', 'Is_OutPut') IS NULL
		ALTER TABLE #T_Detail0 ADD Is_OutPut BIT NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail0', 'Length') IS NULL
		ALTER TABLE #T_Detail0 ADD Length MONEY NOT NULL DEFAULT(0)

	SELECT T1.*, T2.So_Luong_Barcode, T2.Num_Bars_Barcode,
			T2.Length, T2.Num_Lot, T2.Is_OutPut, T2.Ten_Size, T2.Grade_ID, T2.Grade_Name, T2.Standard_ID, T2.Standard_Name, T2.Ma_Ca,
			T2.Ca, T2.Ngay_Nhap, T2.Ma_CL, T2.Ten_CL
		INTO #T_Detail1
		FROM R05CTX_BARCODE T1 WITH(NOLOCK) JOIN #T_Detail0 T2 WITH(NOLOCK) ON T1.Stt = T2.Stt
	
	UPDATE T1 SET
			Ma_Size = T2.Ma_Size,
			Grade_ID = T2.Grade_ID,
			Standard_ID = T2.Standard_ID,
			Ma_CL = T2.Ma_CL,
			Ma_Ca = T2.Ma_Ca,
			Num_Lot = T2.Num_Lot,
			Is_OutPut = T2.Is_Output,
			Length = T2.Length,
			So_Luong_Barcode = T2.So_Luong,
			Num_Bars_Barcode = T2.Num_Bars
		FROM #T_Detail1 T1 WITH(NOLOCK) JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode

	SELECT T1.*, (T1.So_Luong_Barcode - ISNULL(T2.So_Luong, 0)) AS So_Luong_Current, (T1.Num_Bars_Barcode - ISNULL(T2.Num_Bars, 0)) AS Num_Bars_Current
		INTO #T_Detail
		FROM #T_Detail1 T1 LEFT JOIN
			(SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong, ISNULL(SUM(Num_Bars), 0) AS Num_Bars FROM R05CTX_BARCODE WITH(NOLOCK) WHERE Stt <> @Stt GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode

	UPDATE T1 SET Ten_Size = T2.Ten_Size
			FROM #T_Detail T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size

	UPDATE T1 SET Grade_Name = T2.Grade_Name
			FROM #T_Detail T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID
	
	UPDATE T1 SET Standard_Name = T2.Standard_Name
			FROM #T_Detail T1 JOIN R81DMSTANDARD T2 ON T1.Standard_ID = T2.Standard_ID

	UPDATE T1 SET Ca = T2.Ca, Ngay_Nhap = T2.Ngay_Sx
			FROM #T_Detail T1 JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca

	UPDATE T1 SET Ten_CL = T2.Ten_CL
			FROM #T_Detail T1 JOIN R81DMCL T2 ON T1.Ma_CL = T2.Ma_CL
	--Ct
	SELECT So_Luong_Current, Num_Bars_Current, So_Luong, Num_Bars, So_Luong_Barcode, Num_Bars_Barcode, *
		FROM #T_Detail
END 
GO
EXEC sp_GetVoucher_Scale_Ct 'PXTH', '116476'
