USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateNoticePrintDate]    Script Date: 02/10/2015 12:17:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Bill Ryan>
-- Create date: 12/19/2014
-- Description:	Updates the CertificateNoticePrintDate column with current date
--              This procedure will excute after the Notices Have been printed 
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateNoticePrintDate]
	-- Add the parameters for the stored procedure here
	@RecordsAffected int Output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MediationCaseInformation
	SET CertificateNoticeid = 1, CertificateNoticePrintDate = getdate()
	WHERE (MediationCaseInformation.CertificateNoticePrintDate IS NULL) AND
          (MediationCaseInformation.ConfCallDeadlineDate < GETDATE()) AND 
          (CounselorID IS NULL) AND
          (MediationCaseInformation.CertificateLetterContactID > 0) AND
          (MediationCaseInformation.PenaltyAmount > 0) AND
          (MediationCaseInformation.PenaltyPaidDate IS NOT NULL) OR (MediationCaseInformation.CertificateNoticePrintDate IS NULL) AND
          (MediationCaseInformation.ConfCallDeadlineDate < GETDATE()) AND 
          (CounselorID IS NULL) AND
          (MediationCaseInformation.CertificateLetterContactID > 0) AND
          (MediationCaseInformation.PenaltyAmount = 0) AND
          (MediationCaseInformation.PenaltyPaidDate IS NULL)
	
	SET @RecordsAffected = @@ROWCOUNT							
END
GO

