USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdate14DayLetterPrintDate]    Script Date: 02/10/2015 12:14:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jaheda Meman>
-- Create date: 01/28/2014
-- Description:	Updates the FirstLetterSentDate column with current date
--              This procedure will excute after the Letters Have been printed 

CREATE PROCEDURE [dbo].[uspUpdate14DayLetterPrintDate]
	@MediationCaseInformationID int 
--	@RecordsAffected int Output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MediationCaseInformation
		SET MediationCaseInformation.MedInvoiceLetterDate = GETDATE()        
	
	WHERE     (dbo.MediationCaseInformation.MediationInvoiceID > 0) AND (dbo.MediationCaseInformation.MedInvoiceLetterDate IS NULL) AND 
                      (dbo.MediationCaseInformation.ConfResolveDeadlineDate IS NOT NULL) AND (dbo.MediationCaseInformation.RequestExtensionByDate IS NOT NULL) 
                      AND (dbo.MediationCaseInformation.ActualConferenceDate IS NOT NULL)   

	--SET @RecordsAffected = @@ROWCOUNT
									
END
GO

