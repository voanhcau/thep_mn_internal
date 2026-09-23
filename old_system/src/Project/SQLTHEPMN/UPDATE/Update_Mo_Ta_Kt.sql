/*
DROP PROCEDURE Sp_UpdateTVP_Mo_Ta_Kt
EXEC sp_CreateTVPStructure 'R04CTPO', 'TVP_MO_TA_KT', 1

*/

CREATE PROCEDURE [dbo].[Sp_UpdateTVP_Mo_Ta_Kt]
(
	@TVP_Import TVP_Mo_Ta_Kt READONLY,
	@Ma_DvCs VARCHAR(3)
)
--WITH ENCRYPTION
AS
BEGIN
	
	SELECT  *
		INTO #T_Import
		FROM @TVP_Import 
	
	-- Update vao bảng R05CTNX
	UPDATE R81DMVT SET 	Thong_So_Kt = T2.Mo_Ta_Kt, Ten_Vt = T2.Ten_Vt, Dvt = T2.Dvt
		FROM R81DMVT T1 JOIN #T_Import T2 ON T1.Ma_Vt = T2.Ma_Vt AND T1.Ma_Vt <> '00000000'
		WHERE T1.Create_Log LIKE '%TRUNGPT%'
	
	
	
END
