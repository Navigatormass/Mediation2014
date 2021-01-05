USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspPrintNoResponse]    Script Date: 02/10/2015 12:10:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  PROCEDURE [dbo].[uspPrintNoResponse]
--@FromNoticeDate smalldatetime,
--@ToNoticeDate smalldatetime
@MediationCaseInformationID int
    /*
    (
    @parameter1 int = 5,
    @parameter2 datatype OUTPUT
    )
    */
AS
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.CertificateLenderName, dbo.LenderContact.LenderName, 
                      ISNULL(NULLIF (dbo.MediationCaseInformation.CertificateLenderName, ' '), dbo.LenderContact.LenderName) AS LenderAgencyName, 
                      dbo.MediationCaseInformation.LenderContactID, dbo.CertificateLetterContact.AgencyName AS CertLenderName, 
                      dbo.CertificateLetterContact.ContactName AS clcContactName, dbo.MediationCaseInformation.CertificateNoticePrintDate, 
                      dbo.MediationCaseInformation.MortgagorInformationID, dbo.MediationCaseInformation.ConfCallDeadlineDate, dbo.MediationCaseInformation.CoordinatorID, 
                      dbo.MediationCaseInformation.PenaltyAmount, dbo.MediationCaseInformation.PenaltyPaidDate, dbo.MediationCaseInformation.CertificateLetterContactID, 
                      dbo.CertificateLetterContact.ContactTitle AS clcContactTitle, dbo.CertificateLetterContact.Address_1 AS clcAddress1, 
                      dbo.CertificateLetterContact.Address_2 AS clcAddress2, dbo.CertificateLetterContact.City AS clcCity, dbo.CertificateLetterContact.State AS clcState, 
                      dbo.CertificateLetterContact.ZipCode AS clcZip, dbo.CertificateLetterContact.Email, dbo.CertificateLetterContact.OfficePhone, dbo.CertificateLetterContact.Extension, 
                      dbo.CertificateLetterContact.FaxNumber, dbo.CertificateLetterContact.UserID, dbo.MortgagorInformation.FirstName AS borrowerFirst, 
                      dbo.MortgagorInformation.LastName AS borrowerLast, dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_LastName, 
                      dbo.MortgagorInformation.Address_1 AS propertyAddress1, dbo.MortgagorInformation.Address_2 AS propertyAddress2, 
                      dbo.Coordinator.FirstName + ' ' + dbo.Coordinator.LastName AS StaffName, dbo.MortgagorInformation.City AS propertyCity, 
                      dbo.MortgagorInformation.ZipCode AS propertyZip, dbo.MortgagorInformation.State AS propertyState,dbo.MortgagorInformation.createdate as createdate,UPPER(dbo.MortgagorInformation.Address_1) AS Address, 
                      UPPER(dbo.MortgagorInformation.Address_2) AS Address_2, ISNULL(UPPER(dbo.MortgagorInformation.City) + ', ', '') + ISNULL(UPPER(dbo.MortgagorInformation.State)
                       + ' ', '') + ISNULL(dbo.MortgagorInformation.ZipCode, '') AS CityStateZip, UPPER(dbo.MortgagorInformation.Address_1) 
                      + (CASE WHEN MortgagorInformation.Address_2 > '' THEN ', ' + UPPER(MortgagorInformation.Address_2 + ', ') ELSE ', ' END) + UPPER(dbo.MortgagorInformation.City) 
                      + ', ' + UPPER(dbo.MortgagorInformation.State) + ' ' + UPPER(dbo.MortgagorInformation.ZipCode) AS AddressCityStateZip,  dbo.Counselor.CounselorID, 
                      dbo.Counselor.FirstName AS CounselorFirst, dbo.Counselor.LastName AS CounselorLast, ISNULL(UPPER(dbo.MortgagorInformation.FirstName), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.MiddleInitial), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.LastName), '') AS Name
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.MortgagorInformation ON dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.Counselor ON dbo.MediationCaseInformation.CounselorID = dbo.Counselor.CounselorID LEFT OUTER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID LEFT OUTER JOIN
                      dbo.CertificateLetterContact ON dbo.MediationCaseInformation.CertificateLetterContactID = dbo.CertificateLetterContact.CertificateLetterContactID LEFT OUTER JOIN
                      dbo.LenderContact ON dbo.MediationCaseInformation.LenderContactID = dbo.LenderContact.LenderContactID
                       WHERE   (dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL) AND (dbo.MediationCaseInformation.ConfCallDeadlineDate < GETDATE() - 1) AND 
                      (dbo.MediationCaseInformation.CounselorID IS NULL) AND (dbo.MediationCaseInformation.CertificateLetterContactID > 0) AND 
                      (dbo.MediationCaseInformation.PenaltyAmount > 0) AND (dbo.MediationCaseInformation.PenaltyPaidDate IS NOT NULL) OR
                      (dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL) AND (dbo.MediationCaseInformation.ConfCallDeadlineDate < GETDATE() - 1) AND 
                      (dbo.MediationCaseInformation.CounselorID IS NULL) AND (dbo.MediationCaseInformation.CertificateLetterContactID > 0) AND 
                      (dbo.MediationCaseInformation.PenaltyAmount = 0) AND (dbo.MediationCaseInformation.PenaltyPaidDate IS NULL) 
                ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
         -- ((DAY, MediationCaseInformation.CreateDate), GETDATE()) > 60) ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
          --((MediationCaseInformation.CreateDate,DATEPART(DAY,GETDATE())> 60) ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
           /* SET NOCOUNT ON */
    RETURN
GO

