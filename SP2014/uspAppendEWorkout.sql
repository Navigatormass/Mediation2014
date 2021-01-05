USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspAppendEWorkout]    Script Date: 02/10/2015 12:04:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- UPDATE date: <02/02/15,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspAppendEWorkout] 
@MediationCaseInformationID int
AS
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.CertificateLenderName, dbo.LenderContact.LenderName, 
                      dbo.CertificateLetterContact.AgencyName AS CertLenderName, dbo.CertificateLetterContact.ContactName AS clcContactName, 
                      dbo.MediationCaseInformation.CertificateNoticePrintDate, dbo.MediationCaseInformation.PenaltyAmount, 
                      dbo.MediationCaseInformation.PenaltyPaidDate, dbo.MediationCaseInformation.CertificateLetterContactID, 
                      dbo.CertificateLetterContact.ContactTitle AS clcContactTitle, dbo.CertificateLetterContact.Address_1 AS clcAddress1, 
                      dbo.CertificateLetterContact.Address_2 AS clcAddress2, dbo.CertificateLetterContact.City AS clcCity, dbo.MediationCaseInformation.CertificateNoticeID, 
                      dbo.MortgagorInformation.EstateOf, dbo.MortgagorInformation.FirstName AS borrowerFirst, dbo.MortgagorInformation.LastName AS borrowerLast, 
                      dbo.MortgagorInformation.Alias AS Bo_Alias, dbo.MortgagorInformation.PrimaryPhone AS Bo_PrimaryPhone, 
                      dbo.MortgagorInformation.CellPhone AS Bo_CellPhone, dbo.MortgagorInformation.Hispanic AS Bo_Hispanic, 
                      dbo.MortgagorInformation.Email AS Bo_Email, dbo.CertificateLetterContact.State AS clcState, dbo.CertificateLetterContact.ZipCode AS clcZip, 
                      dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_LastName, dbo.MortgagorInformation.Address_1 AS propertyAddress1, 
                      dbo.MortgagorInformation.Address_2 AS propertyAddress2, dbo.MortgagorInformation.Prefix AS Bo_Prefix, 
                      dbo.MortgagorInformation.MiddleInitial AS Bo_MiddleInitial, dbo.MortgagorInformation.Suffix AS Bo_Suffix, 
                      dbo.MortgagorInformation.Gender AS Bo_Gender, dbo.MortgagorInformation.UserID AS Bo_UserID, 
                      dbo.MortgagorInformation.CreateDate AS Bo_CreateDate, dbo.MortgagorInformation.Co_Alias, dbo.MortgagorInformation.Co_BorrowerPhone, 
                      dbo.MortgagorInformation.Co_Prefix, dbo.MortgagorInformation.Co_MiddleInitial, dbo.MortgagorInformation.Co_Suffix, 
                      dbo.MortgagorInformation.City AS propertyCity, dbo.MortgagorInformation.ZipCode AS propertyZip, dbo.MortgagorInformation.State AS propertyState, 
                      dbo.Coordinator.FirstName + ' ' + dbo.Coordinator.LastName AS StaffName, dbo.Counselor.CounselorID, dbo.Counselor.FirstName AS CounselorFirst, 
                      dbo.Counselor.LastName AS CounselorLast
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.MortgagorInformation ON 
                      dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.CertificateNotice ON dbo.MediationCaseInformation.CertificateNoticeID = dbo.CertificateNotice.CertificateNoticeID LEFT OUTER JOIN
                      dbo.Counselor ON dbo.MediationCaseInformation.CounselorID = dbo.Counselor.CounselorID LEFT OUTER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID LEFT OUTER JOIN
                      dbo.CertificateLetterContact ON 
                      dbo.MediationCaseInformation.CertificateLetterContactID = dbo.CertificateLetterContact.CertificateLetterContactID LEFT OUTER JOIN
                      dbo.LenderContact ON dbo.MediationCaseInformation.LenderContactID = dbo.LenderContact.LenderContactID
WHERE                 (dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL) AND 
                     



                      ((dbo.MediationCaseInformation.CertificateNoticeID = 3) OR (dbo.MediationCaseInformation.CertificateNoticeID = 4))


GO

