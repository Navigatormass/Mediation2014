USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateConfCallDeadlineDate]    Script Date: 02/10/2015 12:15:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bill Ryan>
-- Create date: 10/03/2014
-- Description:	Updates the ConferenceCallDeadlineDate column with Case Entered Date
--              + 60days.  
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateConfCallDeadlineDate]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MediationCaseInformation
		SET MediationCaseInformation.ConfCallDeadlineDate = DATEADD(Day, 60, CreateDate)        
	WHERE
		MediationCaseInformation.ConfCallDeadlineDate IS NULL       
									
END
GO

