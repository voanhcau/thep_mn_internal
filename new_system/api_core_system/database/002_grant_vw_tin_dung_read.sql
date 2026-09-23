-- Run as a database administrator after creating the integration_api login/user.
-- Grants the finance.read adapter read-only access to the credit-limit view.
GRANT SELECT ON OBJECT::dbo.vw_Tin_Dung TO integration_api;
GO
