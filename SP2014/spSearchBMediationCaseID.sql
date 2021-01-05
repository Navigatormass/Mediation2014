USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[spSearchBMediationCaseID]    Script Date: 02/10/2015 12:01:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[spSearchBMediationCaseID]

	-- Add the parameters for the stored procedure here
@MortgagorInformationID int
AS
select * from MediationCaseInformation where MortgagorInformationID=@MortgagorInformationID
    /* SET NOCOUNT ON */
    RETURN
GO

