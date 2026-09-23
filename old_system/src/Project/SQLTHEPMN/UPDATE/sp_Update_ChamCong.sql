
/****** Object:  StoredProcedure [dbo].[sp_Update_ChamCong]    Script Date: 08/10/2017 07:54:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
DROP PROCEDURE sp_Update_ChamCong

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R10CHAMCONG', 'TVP_ChamCong', 1
*/
IF OBJECT_ID('sp_Update_ChamCong') IS NOT NULL DROP PROCEDURE sp_Update_ChamCong
GO 
create PROCEDURE [dbo].[sp_Update_ChamCong]
(
	@TVP_ChamCong TVP_ChamCong READONLY,
	@Ma_DvCs VARCHAR(5) = 'A01'
)
--WITH ENCRYPTION
AS
BEGIN
	
	SELECT  *
		INTO #T_Import
		FROM @TVP_ChamCong 
		
	EXEC sp_DefaultTable '#T_Import'

	-- Update vao bảng R10CHAMCONG
	INSERT INTO R10CHAMCONG(Ma_Dt_CbNv, Emp_ID, Ngay_Cham_Cong, Gio_Cham_Cong, Equipment_ID, Ma_Data)
	SELECT 'M'+ DBO.fn_PADL(Emp_ID,4,'0'), Emp_ID, Ngay_Cham_Cong, Gio_Cham_Cong, Equipment_ID, @Ma_DvCs FROM #T_Import
	
	--select * from R10CHAMCONG
	
END