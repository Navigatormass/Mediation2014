USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspTermination]    Script Date: 02/10/2015 12:14:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- UPDATE date: <02/02/15,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspTermination] 


AS
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.AttorneyContactID, 
                      dbo.AttorneyContact.LawFirmName AS AttorneyAgencyName, dbo.AttorneyContact.AttorneyName AS AttorneyContactName, 
                      ISNULL(NULLIF (dbo.AttorneyContact.Address_1, ''), '') + ISNULL(', ' + NULLIF (dbo.AttorneyContact.Address_2, ''), '') AS AttorneyContactAddress1, 
                      ISNULL(dbo.AttorneyContact.City + ', ', '') + ISNULL(dbo.AttorneyContact.State + '  ', '') + dbo.AttorneyContact.ZipCode AS AttorneyContactAddress2, 
                      dbo.MediationCaseInformation.MediationContactID, dbo.MediationContact.AgencyName AS MediationAgencyName, 
                      dbo.MediationContact.MediationContactName, dbo.MediationContact.ContactTitle AS MediationContactTitle, 
                      ISNULL(NULLIF (dbo.MediationContact.Address_1, ''), '') + ISNULL(', ' + NULLIF (dbo.MediationContact.Address_2, ''), '') AS MediationContactAddress1, 
                      ISNULL(dbo.MediationContact.City + ', ', '') + dbo.MediationContact.State + '  ' + dbo.MediationContact.ZipCode AS MediationContactAddress2, 
                      dbo.MediationCaseInformation.MediationInvoiceID, dbo.MediationCaseInformation.ConfResolveDeadlineDate, 
                      dbo.MediationCaseInformation.ActualConferenceDate, dbo.MediationCaseInformation.ServicerContactID, 
                      dbo.ServicerContact.AgencyName AS ServicerAgencyName, dbo.ServicerContact.ServicerName AS ServiceContactName, 
                      dbo.ServicerContact.ServicerTitle AS ServiceContactTitle, ISNULL(NULLIF (dbo.ServicerContact.Address_1, ''), '') 
                      + ISNULL(', ' + NULLIF (dbo.ServicerContact.Address_2, ''), '') AS ServicerContactAddress1, ISNULL(dbo.ServicerContact.City + ', ', '') 
                      + ISNULL(dbo.ServicerContact.State + '  ', '') + dbo.ServicerContact.ZipCode AS ServicerContactAddress2, dbo.MediationInvoice.InvoiceSentDesc, 
                      dbo.MediationCaseInformation.RequestExtensionByDate, dbo.MediationCaseInformation.MortgageAccountNumber, 
                      dbo.MediationCaseInformation.MortgagorInformationID, dbo.MortgagorInformation.EstateOf, dbo.MortgagorInformation.Prefix AS Bo_Prefix, 
                      dbo.MortgagorInformation.FirstName AS Bo_FirstName, dbo.MortgagorInformation.MiddleInitial AS Bo_MiddleInitial, 
                      dbo.MortgagorInformation.LastName AS Bo_LastName, dbo.MortgagorInformation.Suffix AS Bo_Suffix, dbo.MortgagorInformation.Alias AS Bo_Alias, 
                      dbo.MortgagorInformation.CellPhone AS Bo_CellPhone, dbo.MortgagorInformation.PrimaryPhone AS Bo_PrimaryPhone, 
                      dbo.MortgagorInformation.Hispanic, dbo.MortgagorInformation.Email AS Bo_Email, dbo.MortgagorInformation.Gender AS Bo_Gender, 
                      dbo.MortgagorInformation.Co_Prefix, dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_MiddleInitial, 
                      dbo.MortgagorInformation.Co_LastName, dbo.MortgagorInformation.Co_Suffix, dbo.MortgagorInformation.Co_Alias, 
                      dbo.MortgagorInformation.Co_BorrowerPhone, dbo.MortgagorInformation.Address_1 AS PropertyAddress1, 
                      dbo.MortgagorInformation.Address_2 AS PropertyAddress2, dbo.MortgagorInformation.City AS PropertyCity, 
                      dbo.MortgagorInformation.State AS PropertyState, dbo.MortgagorInformation.ZipCode AS PropertyZipcode, 
                      dbo.MediationCaseInformation.CoordinatorID, dbo.Coordinator.FirstName AS CoordinatorFirst, dbo.Coordinator.LastName AS CoordinatorLast
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID INNER JOIN
                      dbo.MortgagorInformation ON 
                      dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.MediationInvoice ON dbo.MediationCaseInformation.MediationInvoiceID = dbo.MediationInvoice.MediationInvoiceID LEFT OUTER JOIN
                      dbo.AttorneyContact ON dbo.MediationCaseInformation.AttorneyContactID = dbo.AttorneyContact.AttorneyContactID LEFT OUTER JOIN
                      dbo.MediationContact ON dbo.MediationCaseInformation.MediationContactID = dbo.MediationContact.MediationContactID LEFT OUTER JOIN
                      dbo.ServicerContact ON dbo.MediationCaseInformation.ServicerContactID = dbo.ServicerContact.ServicerContactID
WHERE     (dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL) 
 --AND
                      --((dbo.MediationCaseInformation.CertificateNoticeID = 5) OR (dbo.MediationCaseInformation.CertificateNoticeID = 6))
GO

