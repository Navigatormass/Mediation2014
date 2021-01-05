USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMediationDataByMortgagorID]    Script Date: 02/10/2015 12:07:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMediationDataByMortgagorID]
	-- Add the parameters for the stored procedure here
	@MortgagorInformationID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from MortgagorInformation where MortgagorInformationID=@MortgagorInformationID
END



GO

