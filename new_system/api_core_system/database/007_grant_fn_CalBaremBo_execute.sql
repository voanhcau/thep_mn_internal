USE [R50THEPMN3];
GO

-- Change [integration_api] if IntegrationHub connects with another SQL principal.
GRANT EXECUTE ON OBJECT::dbo.fn_CalBaremBo TO [integration_api];
GO
