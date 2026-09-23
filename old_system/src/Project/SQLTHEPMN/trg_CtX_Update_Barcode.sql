ALTER TRIGGER [dbo].[trg_CtX_Update_Barcode]
ON [dbo].[R05CTX_BARCODE]
AFTER DELETE, INSERT, UPDATE 
AS
BEGIN
	WITH T_Barcode AS
	(
		SELECT ISNULL(D.Barcode, I.Barcode) AS Barcode,
				SUM(ISNULL(D.So_Luong_OutPut, 0) + ISNULL(I.So_Luong_OutPut, 0)) AS So_Luong_OutPut,
				SUM(ISNULL(D.Num_Bars_OutPut, 0) + ISNULL(I.Num_Bars_OutPut, 0)) AS Num_Bars_OutPut
			FROM 
				(SELECT T1.BarCode,
						-SUM(CASE WHEN T3.Nh_Ct = 2 THEN ROUND(T1.So_Luong, 0) ELSE 0 END) AS So_Luong_OutPut,
						-SUM(CASE WHEN T3.Nh_Ct = 2 THEN ROUND(T1.Num_Bars, 0) ELSE 0 END) AS Num_Bars_OutPut
					FROM deleted T1 JOIN R80PH_SCALE T2 WITH (NOLOCK) ON T1.Stt = T2.Stt
									JOIN R00DMCT T3 WITH (NOLOCK) ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
					WHERE T1.Barcode <> ''
					GROUP BY T1.BarCode

				) D --Deleted
				FULL OUTER JOIN 
				(SELECT T1.BarCode,
						SUM(CASE WHEN T3.Nh_Ct = 2 THEN ROUND(T1.So_Luong, 0) ELSE 0 END) AS So_Luong_OutPut,
						SUM(CASE WHEN T3.Nh_Ct = 2 THEN ROUND(T1.Num_Bars, 0) ELSE 0 END) AS Num_Bars_OutPut
					FROM inserted T1 JOIN R80PH_SCALE T2 WITH (NOLOCK) ON T1.Stt = T2.Stt
									JOIN R00DMCT T3 WITH (NOLOCK) ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
					WHERE T1.Barcode <> ''
					GROUP BY T1.BarCode

				) I --Inserted

				ON D.Barcode = I.Barcode

			GROUP BY D.Barcode, I.Barcode
	)
	MERGE INTO R81DMBARCODE AS T 

	USING T_Barcode AS S ON (T.Barcode = S.Barcode) 

	WHEN MATCHED THEN
		UPDATE SET T.So_Luong_OutPut = T.So_Luong_OutPut + S.So_Luong_OutPut, Num_Bars_OutPut =  T.Num_Bars_OutPut + S.Num_Bars_OutPut;

END
