ALTER PROC sp_GetBarCode_NKKV
(
	@BarCode VARCHAR(20)
)
AS
BEGIN
SELECT T1.*, 
		T1.So_Luong  AS So_Luong_Current,
		T1.Num_Bars  AS Num_Bars_Current,
		 T1.So_Luong AS So_Luong_Barcode, T1.Num_Bars AS Num_Bars_Barcode,
		 T6.Grade_Name,  T7.Standard_Name, 
		 T8.Ten_CL,	T5.Ten_Size,				
	CASE WHEN T4.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T4.Ngay_Sx END AS Ngay_Nhap, CASE WHEN T4.Ca IS NULL THEN T1.Ma_Ca ELSE T4.Ca END AS Ca,
	T5.Ten_Size, T6.Grade_Name, T7.Standard_Name, T8.Ten_CL
	FROM R81DMBARCODE T1 WITH(NOLOCK)
		LEFT JOIN R81DMCA T4 WITH(NOLOCK) ON T1.Ma_Ca = T4.Ma_Ca
		LEFT JOIN R81DMSIZE T5 WITH(NOLOCK) ON T1.Ma_Size = T5.Ma_Size
		LEFT JOIN R81DMMACTHEP T6 WITH(NOLOCK) ON T1.Grade_ID = T6.Grade_ID
		LEFT JOIN R81DMSTANDARD T7 WITH(NOLOCK) ON T1.Standard_ID = T7.Standard_ID
		LEFT JOIN R81DMCL T8 WITH(NOLOCK) ON T1.Ma_CL = T8.Ma_CL
WHERE Try_ID <> '' AND Num_Bars <> 0 AND IS_OUTPUT = 1 AND  T1.Barcode = @BarCode
END
GO
EXEC sp_GetBarCode_NKKV	'01160136451'							