-- Run as a database administrator after creating the integration_api login/user.
-- This grants only the permission required by the first master.read use case.
GRANT SELECT ON OBJECT::dbo.R81BAREMPHOI TO integration_api;
GO
