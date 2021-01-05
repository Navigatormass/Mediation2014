USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMediationCaseNotesDetails]    Script Date: 02/10/2015 12:05:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	<Author,,Jaheda Meman>
-- Create date: <01/20/15,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMediationCaseNotesDetails]
	-- Add the parameters for the stored procedure here
	@MediationCaseInformationID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Notes where MediationCaseInformationID=@MediationCaseInformationID order by TimeStamp desc
END

GO

