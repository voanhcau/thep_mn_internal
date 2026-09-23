ALTER FUNCTION dbo.fn_Split 
(
	@String Nvarchar(2000)
)
RETURNS TABLE
WITH ENCRYPTION
AS
RETURN 
(
	WITH Pieces(pn, start, stop) AS 
	(
		SELECT 1, 1, CHARINDEX(',', @String)
			UNION ALL
			SELECT pn + 1, stop + 1, CHARINDEX(',', @String, stop + 1)
				FROM Pieces
				WHERE stop > 0
	)
	SELECT RTRIM(LTRIM(SUBSTRING(@String, start, CASE WHEN stop > 0 THEN stop-start ELSE LEN(@String) END))) AS String
		FROM Pieces
		
)
GO