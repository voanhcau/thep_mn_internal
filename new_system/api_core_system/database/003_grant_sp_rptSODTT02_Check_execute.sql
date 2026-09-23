USE [R50THEPMN3];
GO

-- Replace [integration_api] if the API uses a different database principal.
GRANT EXECUTE ON OBJECT::dbo.sp_rptSODTT02_Check TO [integration_api];
GO
