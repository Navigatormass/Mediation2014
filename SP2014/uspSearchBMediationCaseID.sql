USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspSearchBMediationCaseID]    Script Date: 02/10/2015 12:13:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspSearchBMediationCaseID]

	-- Add the parameters for the stored procedure here
@MortgagorInformationID int
AS
select * from MediationCaseInformation where MortgagorInformationID=@MortgagorInformationID
    /* SET NOCOUNT ON */
    RETURN
GO

