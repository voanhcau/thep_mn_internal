/*Thủ tục trả về bảng Filter
EXEC sp_GetPH_Scale_TruckIn 'PXTH'
*/
ALTER PROCEDURE [dbo].[sp_GetPH_Scale_Truck_In]
(
	@Ma_Ct VARCHAR(5) = ''
)
AS
BEGIN	

	SELECT T1.*, T2.Ten_Dt, T3.Ten_Vt, T4.Ten_Dt AS Ten_Dt_CbNv_Vao
		FROM R80PH_SCALE T1 WITH(NOLOCK)
				LEFT JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt
				LEFT JOIN R81DMVT T3 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T3.Ma_Vt
				LEFT JOIN R81DMDT T4 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Vao = T4.Ma_Dt
		WHERE Ma_Ct = @Ma_Ct AND So_Luong_Vao > 0 AND So_Luong_Ra = 0
		ORDER BY Time_In DESC

END 
GO
