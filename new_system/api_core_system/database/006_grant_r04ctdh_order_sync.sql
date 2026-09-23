USE [R50THEPMN3];
GO

-- Run as a database administrator. Change [integration_api] if the service
-- uses a different principal; the endpoint replaces only one web order at a time.
GRANT SELECT, INSERT, DELETE ON OBJECT::dbo.R04CTDH TO [integration_api];
GO
