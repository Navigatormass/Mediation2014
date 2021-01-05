USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateFirstLetterSentDate]    Script Date: 02/10/2015 12:16:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bill Ryan>
-- Create date: 10/03/2014
-- Description:	Updates the FirstLetterSentDate column with current date
--              This procedure will excute after the Letters Have been printed 
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateFirstLetterSentDate]
	-- Add the parameters for the stored procedure here
	@RecordsAffected int Output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MediationCaseInformation
		SET MediationCaseInformation.FirstLetterSentDate = GETDATE()        
	WHERE
		(MediationCaseInformation.FirstLetterSentDate IS Null)

	SET @RecordsAffected = @@ROWCOUNT
									
END
GO

