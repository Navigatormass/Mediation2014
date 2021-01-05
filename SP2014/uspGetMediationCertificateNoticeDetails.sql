USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMediationCertificateNoticeDetails]    Script Date: 02/10/2015 12:06:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
	
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMediationCertificateNoticeDetails]

	-- Add the parameters for the stored procedure here
	@CertificateNoticeID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  CertificateNoticeID,ISNULL(NoticeTypeDesc,'')+', '+Isnull(NoticeReasonDesc,'') as Name FROM CertificateNotice 
END

GO

